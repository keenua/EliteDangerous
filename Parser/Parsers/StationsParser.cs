using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using Data;
using Data.Migrations;
using Data.Stations;
using Data.Systems;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Parser.Parsers;

namespace Parser.Parsers
{
    public class StationsParser : JsonParser
    {
        public override string FileName
        {
            get { return "stations"; }
        }

        private Station ParseStation(Db context, JToken json)
        {
            var id = json.Value<int>("id");
            var name = json.Value<string>("name");
            var systemId = json.Value<int>("system_id");
            var maxLandingPadSize = json.Value<string>("max_landing_pad_size");
            var distnaceToStar = json.Value<long?>("distance_to_star");
            var hasBlackMarket = json.Value<int>("has_blackmarket");
            var hasCommodities = json.Value<int>("has_commodities");
            var hasRefuel = json.Value<int>("has_refuel");
            var hasRepair = json.Value<int>("has_repair");
            var hasRearm = json.Value<int>("has_rearm");
            var hasOutfitting = json.Value<int>("has_outfitting");
            var hasShipyard = json.Value<int>("has_shipyard");
            var updatedAt = json.Value<long>("updated_at");

            var station = context.Stations.FirstOrDefault(x => x.Id == id);

            if (station == null)
            {
                station = new Station {Id = id};
                context.Stations.Add(station);
            }

            station.SystemId = systemId;
            station.Name = name;
            station.MaxLandingPadSize = maxLandingPadSize;
            station.DistanceToStar = distnaceToStar;
            station.HasShipyard = hasBlackMarket == 1;
            station.HasCommodities = hasCommodities == 1;
            station.HasRefuel = hasRefuel == 1;
            station.HasRepair = hasRepair == 1;
            station.HasRearm = hasRearm == 1;
            station.HasOutfitting = hasOutfitting == 1;
            station.HasShipyard = hasShipyard == 1;
            station.UpdatedAt = updatedAt;

            return station;
        }

        private void FillNamedEntitiesCollection<T>(ICollection<T> collection, Db context, JToken stationJson,
            string token) where T : class, INamedEntity, new()
        {
            collection.Clear();

            var array = (JArray)stationJson[token];

            foreach (var item in array)
            {
                var itemName = item.Value<string>();

                var entity = GetCachedEntity<T>(context, itemName);
                if (entity == null) continue;

                collection.Add(entity);
            }
        }

        private void ParseListings(Station station, Db context, JToken stationJson)
        {
            var array = (JArray)stationJson["listings"];

            foreach (var item in array)
            {
                var id = item.Value<int>("id");
                var stationId = item.Value<int>("station_id");
                var commodityId = item.Value<int>("commodity_id");
                var supply = item.Value<int?>("supply");
                var buyPrice = item.Value<int?>("buy_price");
                var sellPrice = item.Value<int?>("sell_price");
                var demand =  item.Value<int?>("demand");
                var collectedAt = item.Value<long>("collected_at");
                var updatedCount = item.Value<int?>("update_count");

                var listing = new Listing
                {
                    Id = id,
                    StationId = stationId,
                    CommodityId = commodityId,
                    Supply = supply,
                    BuyPrice = buyPrice,
                    SellPrice = sellPrice,
                    Demand = demand,
                    CollectedAt = collectedAt,
                    UpdateCount = updatedCount
                };

                context.Listings.Add(listing);
            }
        }

        protected override bool Parse(Db context, JObject stationJson, DateTime time)
        {
            var faction = ParseNamedEntity<Faction>(context, stationJson, "faction");
            var government = ParseNamedEntity<Government>(context, stationJson, "government");
            var allegiance = ParseNamedEntity<Allegiance>(context, stationJson, "allegiance");
            var state = ParseNamedEntity<State>(context, stationJson, "state");
            var stationType = ParseNamedEntity<StationType>(context, stationJson, "type");

            var station = ParseStation(context, stationJson);

            station.Faction = faction;
            station.Government = government;
            station.Allegiance = allegiance;
            station.State = state;
            station.StationType = stationType;

            FillNamedEntitiesCollection(station.ImportCommodities, context, stationJson, "import_commodities");
            FillNamedEntitiesCollection(station.ExportCommodities, context, stationJson, "export_commodities");
            FillNamedEntitiesCollection(station.ProhibitedCommodities, context, stationJson, "prohibited_commodities");
            FillNamedEntitiesCollection(station.Economies, context, stationJson, "economies");

            ParseListings(station, context, stationJson);

            return true;
        }
    }
}