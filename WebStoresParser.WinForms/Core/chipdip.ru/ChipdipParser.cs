using AngleSharp.Html.Dom;
using System.Collections.Generic;
using System.Linq;

namespace WebStoresParser.WinForms.Core.Chipdip
{
    class ChipdipParser : IParser<string[]>
    {
        public string[] Parse(IHtmlDocument document)
        {
            var list = new List<string>();
            var items = document.QuerySelectorAll("a").Where(item => item.Attributes["href"] != null && !item.Attributes["href"].Value.Contains("help") && item.Attributes["href"].Value.Contains("product"));

            foreach (var item in items)
            {
                list.Add(item.TextContent);
            }

            return list.ToArray();
        }
    }
}
