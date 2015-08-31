using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Data.Stations;

namespace Data.Commodities
{
    //{ "id": 1, "name": "Explosives", "category_id": 1, "average_price": 269, "category": { "id": 1, "name": "Chemicals" } }
    public class Commodity : INamedEntity
    {
        public Commodity()
        {
            AveragePrices = new HashSet<CommodityAveragePrice>();
            StationsImport = new HashSet<Station>();
            StationsExport = new HashSet<Station>();
            StationsProhibit = new HashSet<Station>();
        }

        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        public string Name { get; set; }

        [ForeignKey("Category"), DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CategoryId { get; set; }

        public virtual CommodityCategory Category { get; set; }
        public virtual ICollection<CommodityAveragePrice> AveragePrices { get; set; }

        public virtual ICollection<Station> StationsImport { get; set; }
        public virtual ICollection<Station> StationsExport { get; set; }
        public virtual ICollection<Station> StationsProhibit { get; set; }
    }
}