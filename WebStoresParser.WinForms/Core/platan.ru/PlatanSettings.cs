
namespace WebStoresParser.WinForms.Core.Platan
{
    class PlatanSettings : ParserSettings
    {
        public PlatanSettings()
        {
        }
        public string BaseURL { get; set; } = "http://platan.ru";
        public string Prefix { get; set; } = "cgi-bin/qwery_i.pl?code={SearchProductName}";
    }
}
