using GMapsServices.Common.Contracts;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using System.Web;

namespace GMapsServices.BusinessEngine
{
    public class ExternalHttpRequestBusinessEngine : IExternalHttpRequestBusinessEngine
    {
        private readonly IHttpClientFactory httpClientFactory;
        public ExternalHttpRequestBusinessEngine(IHttpClientFactory httpClientFactory)
        {
            this.httpClientFactory = httpClientFactory;
        }
        public async Task<T> GetAsync<T>(string baseUrl, string routeUrl, NameValueCollection param = null)
        {
            string parameters = string.Empty;
            if (param != null)
            {
                var nameValueCollection = (from key in param.AllKeys
                                           from value in param.GetValues(key)
                                           select string.Format("{0}={1}", HttpUtility.UrlEncode(key), HttpUtility.UrlEncode(value))).ToArray();
                parameters = "?" + string.Join("&", nameValueCollection);
            }          
            var client = httpClientFactory.CreateClient();
            var response = await client.GetAsync(baseUrl + routeUrl + parameters);
            using var stream = await response.Content.ReadAsStreamAsync();
            return await JsonSerializer.DeserializeAsync<T>(stream);
        }
    }
}
