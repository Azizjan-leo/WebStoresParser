
namespace WebStoresParser.WinForms.Core
{
    abstract class ParserSettings
    {
        public string BaseURL { get; set; }
        public string Prefix { get; set; }
        public bool IsUTF8 { get; set; } = false;
    }
}
