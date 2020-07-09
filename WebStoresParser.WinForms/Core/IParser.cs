using AngleSharp.Html.Dom;

namespace WebStoresParser.WinForms.Core
{
    interface IParser<T> where T: class
    {
        T Parse(IHtmlDocument document);
    }
}
