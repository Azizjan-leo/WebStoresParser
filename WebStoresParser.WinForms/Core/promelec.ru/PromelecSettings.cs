
namespace WebStoresParser.WinForms.Core.Promelec
{
    class PromelecSettings : ParserSettings
    {
        public PromelecSettings()
        {
        }
        public string BaseURL { get; set; } = "https://www.promelec.ru";
        public string Prefix { get; set; } = "search/?query={SearchProductName}";
    }
}
