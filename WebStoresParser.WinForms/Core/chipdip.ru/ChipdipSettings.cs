
namespace WebStoresParser.WinForms.Core.Chipdip
{
    class ChipdipSettings : ParserSettings
    {
        public ChipdipSettings()
        {
        }
        public string BaseURL { get; set; } = "https://www.chipdip.ru/";
        public string Prefix { get; set; } = "search?searchtext={SearchProductName}";
    }
}
