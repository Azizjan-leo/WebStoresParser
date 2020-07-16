
namespace WebStoresParser.WinForms.Core.Zip
{
    class ZipSettings : ParserSettings
    {
        public ZipSettings()
        {
            BaseURL = "http://www.zip-2002.ru";
            Prefix = "?search={SearchProductName}";
        }
    }
}
