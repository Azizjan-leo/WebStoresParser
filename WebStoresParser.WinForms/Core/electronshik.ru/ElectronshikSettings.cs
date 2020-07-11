
namespace WebStoresParser.WinForms.Core.Electronshik
{
    class ElectronshikSettings : ParserSettings
    {
        public ElectronshikSettings()
        {
            IsUTF8 = true;
            BaseURL = "https://www.electronshik.ru";
            Prefix = "search/?query={SearchProductName}";
        }
    }
}
