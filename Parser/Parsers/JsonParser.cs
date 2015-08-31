using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Data;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Parser.Parsers
{
    public abstract class JsonParser : IParser
    {
        public abstract string FileName { get; }
        protected abstract bool Parse(Db context, JObject json, DateTime time);

        private readonly Dictionary<string, Dictionary<string, object>> _cache = new Dictionary<string, Dictionary<string, object>>();
        protected T GetCachedEntity<T>(Db context, string name) where T : class, INamedEntity
        {
            var type = typeof (T).Name;

            if (!_cache.ContainsKey(type)) _cache[type] = new Dictionary<string, object>();

            object result;

            if (_cache[type].TryGetValue(name, out result))
                return (T) result;
            {
                var entity = context.Set<T>().FirstOrDefault(x => x.Name == name);

                if (entity != null)
                    _cache[type][name] = entity;

                return entity;
            }
        }

        protected T ParseNamedEntity<T>(Db context, JToken systemJson, string token)
            where T : class, INamedEntity, new()
        {
            var name = systemJson.Value<string>(token);

            if (string.IsNullOrEmpty(name)) return null;

            var entity = GetCachedEntity<T>(context, name);

            if (entity == null)
            {
                entity = new T {Name = name};
                context.Set<T>().Add(entity);
            }

            return entity;
        }

        public virtual bool Parse(string directory, DateTime time)
        {
            var path = string.Format("{0}/{1}.json", directory, FileName);

            int index = 0;

            var context = new Db();
            context.Configuration.AutoDetectChangesEnabled = false;

            using (var streamReader = new StreamReader(path))
            using (var reader = new JsonTextReader(streamReader))
            {
                while (reader.Read())
                {
                    if (reader.TokenType == JsonToken.StartObject)
                    {
                        var obj = JObject.Load(reader);
                        Parse(context, obj, time);

                        if (++index%100 == 0)
                        {
                            context.SaveChanges();
                            context.Dispose();
                            context = new Db();
                        }

                        Console.WriteLine(index);
                    }
                }
            }

            context.SaveChanges();
            context.Dispose();

            return true;
        }
    }
}