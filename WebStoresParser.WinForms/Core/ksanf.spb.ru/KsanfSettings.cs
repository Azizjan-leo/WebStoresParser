﻿
namespace WebStoresParser.WinForms.Core.Ksanf
{
    class KsanfSettings : ParserSettings
    {
        public KsanfSettings()
        {
        }
        public string BaseURL { get; set; } = "http://ksanf.spb.ru";
        public string Prefix { get; set; } = "index.php?searchstring={SearchProductName}";
    }
}
