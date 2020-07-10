using AngleSharp.Html.Dom;
using System.Collections.Generic;
using System.Linq;

namespace WebStoresParser.WinForms.Core.Promelec
{
    class PromelecParser : IParser<string[]>
    {
        public string[] Parse(IHtmlDocument document)
        {
            var list = new List<string>();
            var items = document.QuerySelectorAll("a").Where(item => item.ClassName != null && item.ClassName.Contains("product-preview__title"));

           

            foreach (var item in items)
            {
                list.Add(item.TextContent);
            }

            return list.ToArray();
        }
    }
}
