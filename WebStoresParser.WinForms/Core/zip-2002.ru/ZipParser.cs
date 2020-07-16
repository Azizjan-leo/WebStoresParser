using AngleSharp.Html.Dom;
using System.Collections.Generic;
using System.Linq;

namespace WebStoresParser.WinForms.Core.Zip
{
    class ZipParser : IParser<string[]>
    {
        public string[] Parse(IHtmlDocument document)
        {
            var t = document.Body.TextContent;
            var list = new List<string>();
            var items = document.QuerySelectorAll("div.obolochka").ToList();

            

            foreach (var item in items)
            {
                list.Add(item.TextContent);
            }

            return list.ToArray();
        }
    }
}
