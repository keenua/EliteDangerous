using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Data.Stations;

namespace Data.Systems
{
    public class Faction : INamedEntity
    {
        public Faction()
        {
            Systems = new HashSet<System>();
            Stations = new HashSet<Station>();
        }

        [Key]
        public int Id { get; set; }

        [MaxLength(100)]
        [Index("IX_FactionName")]
        public string Name { get; set; }

        public virtual ICollection<System> Systems { get; set; }
        public virtual ICollection<Station> Stations { get; set; } 
    }
}
