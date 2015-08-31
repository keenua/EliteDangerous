using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Systems
{
    public class PowerControlFaction : INamedEntity
    {
        public PowerControlFaction()
        {
            Systems = new HashSet<System>();
        }

        [Key]
        public int Id { get; set; }

        [MaxLength(100)]
        [Index("IX_PowerControlFactionName")]
        public string Name { get; set; }

        public virtual ICollection<System> Systems { get; set; }
    }
}