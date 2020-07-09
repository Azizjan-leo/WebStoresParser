using AngleSharp.Html.Dom;
using System.Collections.Generic;
using System.Linq;

namespace WebStoresParser.WinForms.Core.Habra
{
    class EleksnabParser : IParser<string[]>
    {
        public string[] Parse(IHtmlDocument document)
        {
            var list = new List<string>();
            var items = document.QuerySelectorAll("span").Where(item => item.ClassName != null && item.ClassName.Contains("catalog-item-price"));

            foreach (var item in items)
            {
                list.Add(item.TextContent);
            }

            return list.ToArray();
        }
    }
}
