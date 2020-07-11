
namespace WebStoresParser.WinForms.Core.Habra
{
    class EleksnabSettings : ParserSettings
    {
        public EleksnabSettings(int start, int end)
        {
            StartPoint = start;
            EndPoint = end;
        }
        public string BaseURL { get; set; } = "http://eleksnab.ru";
        public string Prefix { get; set; } = "page{CurrentId}";
        public int StartPoint { get; set; }
        public int EndPoint { get; set; }
    }
}
