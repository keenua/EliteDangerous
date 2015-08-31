using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using Data;
using Data.Systems;
using Newtonsoft.Json.Linq;
using Parser.Parsers;
using System = Data.Systems.System;

namespace Parser.Parsers
{
    public class SystemsParser : JsonParser
    {
        public override string FileName
        {
            get { return "systems"; }
        }

        private Data.Systems.System ParseSystem(Db context, JToken systemJson)
        {
            var id = systemJson.Value<int>("id");
            var name = systemJson.Value<string>("name");
            var x = systemJson.Value<double>("x");
            var y = systemJson.Value<double>("y");
            var z = systemJson.Value<double>("z");
            var population = systemJson.Value<long?>("population");
            var needsPermit = systemJson.Value<int?>("needs_permit");
            var updatedAt = systemJson.Value<long>("updated_at");

            var system = context.Systems.FirstOrDefault(s => s.Id == id);

            if (system == null)
            {
                system = new Data.Systems.System {Id = id};
                context.Systems.Add(system);
            }

            system.Name = name;
            system.X = x;
            system.Y = y;
            system.Z = z;
            system.Population = population;
            system.NeedsPermit = (needsPermit == null) ? (bool?) null : (needsPermit == 1);
            system.UpdatedAt = updatedAt;

            return system;
        }

        protected override bool Parse(Db context, JObject systemJson, DateTime time)
        {
            var faction = ParseNamedEntity<Faction>(context, systemJson, "faction");
            var government = ParseNamedEntity<Government>(context, systemJson, "government");
            var allegiance = ParseNamedEntity<Allegiance>(context, systemJson, "allegiance");
            var state = ParseNamedEntity<State>(context, systemJson, "state");
            var security = ParseNamedEntity<Security>(context, systemJson, "security");
            var primaryEconomy = ParseNamedEntity<Economy>(context, systemJson, "primary_economy");

            var system = ParseSystem(context, systemJson);

            system.Faction = faction;
            system.Government = government;
            system.Allegiance = allegiance;
            system.State = state;
            system.Security = security;
            system.PrimaryEconomy = primaryEconomy;

            return true;
        }
    }
}