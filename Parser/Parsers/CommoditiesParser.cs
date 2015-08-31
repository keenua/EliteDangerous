using System;
using System.Linq;
using Data;
using Data.Commodities;
using Newtonsoft.Json.Linq;

namespace Parser.Parsers
{
    public class CommoditiesParser : JsonParser
    {
        public override string FileName
        {
            get { return "commodities"; }
        }

        private CommodityCategory ParseCategory(Db context, JToken categoryJson)
        {
            var name = categoryJson.Value<string>("name");
            var id = categoryJson.Value<int>("id");

            var category = context.CommodityCategories.FirstOrDefault(x => x.Id == id);
            if (category == null)
            {
                category = new CommodityCategory {Id = id};
                context.CommodityCategories.Add(category);
            }
            category.Name = name;

            return category;
        }

        private Commodity ParseCommodity(Db context, CommodityCategory category, JToken commodityJson)
        {
            var name = commodityJson.Value<string>("name");
            var id = commodityJson.Value<int>("id");

            var commodity = context.Commodities.FirstOrDefault(x => x.Id == id);
            if (commodity == null)
            {
                commodity = new Commodity {Id = id};
                context.Commodities.Add(commodity);
            }

            commodity.Name = name;
            commodity.Category = category;

            return commodity;
        }

        private CommodityAveragePrice ParserAveragePrice(Db context, Commodity commodity, DateTime time,
            JToken commodityJson)
        {
            var averagePrice = commodityJson.Value<int?>("average_price");

            if (averagePrice == null) return null;

            var lastAverage = commodity.AveragePrices.OrderBy(x => x.Date).LastOrDefault();

            if (lastAverage == null || (lastAverage.Date < time && lastAverage.Price != averagePrice))
            {
                var price = new CommodityAveragePrice {Commodity = commodity, Date = time, Price = averagePrice.Value};
                context.CommodityAveragePrices.Add(price);

                return price;
            }

            return lastAverage;
        }

        protected override bool Parse(Db context, JObject commodityJson, DateTime time)
        {
            var category = ParseCategory(context, commodityJson["category"]);
            var commodity = ParseCommodity(context, category, commodityJson);
            var price = ParserAveragePrice(context, commodity, time, commodityJson);

            return true;
        }
    }
}