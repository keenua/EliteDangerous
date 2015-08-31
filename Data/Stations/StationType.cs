using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Systems;

namespace Data.Stations
{
    public class StationType : INamedEntity
    {
        public StationType()
        {
            Stations = new HashSet<Station>();
        }

        [Key]
        public int Id { get; set; }

        [MaxLength(100)]
        [Index("IX_StationName")]
        public string Name { get; set; }

        public virtual ICollection<Station> Stations { get; set; }
    }
}