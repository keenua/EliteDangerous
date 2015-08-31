using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parser.Parsers
{
    public class ParserFactory
    {
        #region Singleton

        private static readonly Lazy<ParserFactory> LazyInstance = new Lazy<ParserFactory>(() => new ParserFactory());

        public static ParserFactory Instance
        {
            get { return LazyInstance.Value; }
        }

        private ParserFactory()
        {
        }

        #endregion

        private List<IParser> Parsers = new List<IParser>
        {
            new StationsParser(),
            new CommoditiesParser(),
            new SystemsParser()
        };


        public IParser GetParser(string file)
        {
            var fileName = Path.GetFileNameWithoutExtension(file.ToLower());

            return Parsers.FirstOrDefault(x => x.FileName.ToLower() == fileName.ToLower());
        }
    }
}