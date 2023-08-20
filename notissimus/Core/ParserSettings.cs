using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace notissimus.Core
{
    interface ParserSettings
    {
        string BaseUrl { get; set; }
        string Prefix { get; set; }
        int Start { get; set; }
        int End { get; set; }
    }
}
