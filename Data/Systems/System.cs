using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Data.Stations;

namespace Data.Systems
{
    public class System
    {
        public System()
        {
            Stations = new HashSet<Station>();
        }

        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        public string Name { get; set; }

        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }
        [ForeignKey("Faction")]
        public int? FactionId { get; set; }
        public long? Population { get; set; }
        [ForeignKey("Government")]
        public int? GovernmentId { get; set; }
        [ForeignKey("Allegiance")]
        public int? AllegianceId { get; set; }
        [ForeignKey("State")]
        public int? StateId { get; set; }
        [ForeignKey("Security")]
        public int? SecurityId { get; set; }
        [ForeignKey("PrimaryEconomy")]
        public int? PrimaryEconomyId { get; set; }
        public bool? NeedsPermit { get; set; }
        public long UpdatedAt { get; set; }
        [ForeignKey("PowerControlFaction")]
        public int? PowerControlFactionId { get; set; }

        public virtual Faction Faction { get; set; }
        public virtual Government Government { get; set; }
        public virtual Allegiance Allegiance { get; set; }
        public virtual State State { get; set; }
        public virtual Security Security { get; set; }
        public virtual Economy PrimaryEconomy { get; set; }
        public virtual PowerControlFaction PowerControlFaction { get; set; }

        public virtual ICollection<Station> Stations { get; set; }
    }
}
