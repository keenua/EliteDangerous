﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Stations;

namespace Data.Systems
{
    public class State : INamedEntity
    {
        public State()
        {
            Systems = new HashSet<System>();
            Stations = new HashSet<Station>();
        }

        [Key]
        public int Id { get; set; }

        [MaxLength(100)]
        [Index("IX_StateName")]
        public string Name { get; set; }

        public virtual ICollection<System> Systems { get; set; }
        public virtual ICollection<Station> Stations { get; set; } 
    }
}
