using System.Net.Http;
using System.Net;
using System.Threading.Tasks;

namespace WebStoresParser.WinForms.Core
{
    class HtmlLoader
    {
        readonly HttpClient client;
        readonly string url;
        readonly bool isUTF8;
        public HtmlLoader(ParserSettings settings)
        {
            client = new HttpClient();
            url = $"{settings.BaseURL}/{settings.Prefix}";
            isUTF8 = settings.IsUTF8;
        }

        public async Task<string> GetSourceByProductName(string productName)
        {

            var currentUrl = url.Replace("{SearchProductName}", productName);
            var response = await client.GetAsync(currentUrl);
            string source = null;

            if (response != null && response.StatusCode == HttpStatusCode.OK)
            {
                if (isUTF8)
                    source = System.Text.Encoding.UTF8.GetString(await response.Content.ReadAsByteArrayAsync());
                else
                    source = await response.Content.ReadAsStringAsync();
            }

            return source;
        }

        public async Task<string> GetSourceByPageId(int id)
        {
            var currentUrl = url.Replace("{CurrentId}", id.ToString());
            var response = await client.GetAsync(currentUrl);
            string source = null;
            
            if(response != null && response.StatusCode == HttpStatusCode.OK)
            {
                source = await response.Content.ReadAsStringAsync();
            }

            return source;
        }
    }
}
