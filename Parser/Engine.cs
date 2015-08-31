using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;
using Parser.Parsers;

namespace Parser
{
    public class Engine
    {
        private const string Dir = @"d:\Work\Projects\Elite Dangerous\Data\";

        private void CleanUp()
        {
            using (var db = new Db())
            {
                db.Database.ExecuteSqlCommand("DELETE FROM Listings");
                db.SaveChanges();
            }
        }

        public void Update()
        {
            CleanUp();

            var files = Directory.GetFiles(Dir, "*.json");

            foreach (var f in files)
            {
                var parser = ParserFactory.Instance.GetParser(f);

                if (parser != null)
                    parser.Parse(Dir, DateTime.Today);
            }
        }
    }
}
