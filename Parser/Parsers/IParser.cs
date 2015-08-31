using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parser.Parsers
{
    public interface IParser
    {
        string FileName { get; }
        bool Parse(string directory, DateTime time);
    }
}
