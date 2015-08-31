using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;
using Parser.Parsers;

namespace Parser
{
    class Program
    {
        static void Main(string[] args)
        {
            var engine = new Engine();
            engine.Update();
        }
    }
}
