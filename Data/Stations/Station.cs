using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Commodities;
using Data.Systems;

namespace Data.Stations
{
    public class Station
    {
        public Station()
        {
            ImportCommodities = new HashSet<Commodity>();
            ExportCommodities = new HashSet<Commodity>();
            ProhibitedCommodities = new HashSet<Commodity>();
            Economies = new HashSet<Economy>();
            Listings = new HashSet<Listing>();
        }

        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        public string Name { get; set; }

        [ForeignKey("System")]
        public int SystemId { get; set; }

        public string MaxLandingPadSize { get; set; }
        public long? DistanceToStar { get; set; }

        [ForeignKey("Faction")]
        public int? FactionId { get; set; }
        [ForeignKey("Government")]
        public int? GovernmentId { get; set; }
        [ForeignKey("Allegiance")]
        public int? AllegianceId { get; set; }
        [ForeignKey("State")]
        public int? StateId { get; set; }
        [ForeignKey("StationType")]
        public int? StationTypeId { get; set; }

        public bool HasBlackMarket { get; set; }
        public bool HasCommodities { get; set; }
        public bool HasRefuel { get; set; }
        public bool HasRepair { get; set; }
        public bool HasRearm { get; set; }
        public bool HasOutfitting { get; set; }
        public bool HasShipyard { get; set; }

        public long UpdatedAt { get; set; }

        public virtual Systems.System System { get; set; }
        public virtual Faction Faction { get; set; }
        public virtual Government Government { get; set; }
        public virtual Allegiance Allegiance { get; set; }
        public virtual State State { get; set; }
        public virtual StationType StationType { get; set; }

        public virtual ICollection<Commodity> ImportCommodities { get; set; }
        public virtual ICollection<Commodity> ExportCommodities { get; set; }
        public virtual ICollection<Commodity> ProhibitedCommodities { get; set; }
        public virtual ICollection<Economy> Economies { get; set; }
        public virtual ICollection<Listing> Listings { get; set; } 
    }
}