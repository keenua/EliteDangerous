using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Commodities
{
    public class CommodityAveragePrice
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int Price { get; set; }
        [ForeignKey("Commodity")]
        public int CommodityId { get; set; }

        public virtual Commodity Commodity { get; set; }
    }
}
