using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Commodities;

namespace Data.Stations
{
    public class Listing
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        [ForeignKey("Station")]
        public int StationId { get; set; }

        [ForeignKey("Commodity")]
        public int CommodityId { get; set; }

        public int? Supply { get; set; }
        public int? BuyPrice { get; set; }
        public int? SellPrice { get; set; }
        public int? Demand { get; set; }
        public long CollectedAt { get; set; }
        public int? UpdateCount { get; set; }

        public virtual Station Station { get; set; }

        public virtual Commodity Commodity { get; set; }
    }
}
