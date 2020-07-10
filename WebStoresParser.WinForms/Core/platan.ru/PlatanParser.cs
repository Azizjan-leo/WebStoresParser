using AngleSharp.Html.Dom;
using System.Collections.Generic;
using System.Linq;

namespace WebStoresParser.WinForms.Core.Platan
{
    class PlatanParser : IParser<string[]>
    {
        public string[] Parse(IHtmlDocument document)
        {
            var list = new List<string>();
            
            var items = document.QuerySelectorAll("a").Where(item => item.Attributes["href"] != null && item.Attributes["href"].Value.Contains("cgi-bin/qwery.pl/id="));
            
            foreach (var item in items)
            {
                list.Add(item.TextContent);
            }

            return list.ToArray();
        }
    }
}
