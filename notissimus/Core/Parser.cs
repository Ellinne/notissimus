using AngleSharp.Html.Dom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace notissimus.Core
{
    interface Parser<T> where T : class
    {
        T Parse(IHtmlDocument document);
    }
}
