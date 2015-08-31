using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Commodities
{
    public class CommodityCategory
    {
        public CommodityCategory()
        {
            Commodities = new List<Commodity>();
        }

        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual List<Commodity> Commodities { get; set; }
    }
}
