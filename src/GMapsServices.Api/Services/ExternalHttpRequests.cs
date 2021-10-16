using System.Collections.Specialized;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using GMapsServices.Api.Contracts;

namespace GMapsServices.Api.Services
{
    public class ExternalHttpRequests : IExternalHttpRequests
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ExternalHttpRequests(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<T> GetAsync<T>(string baseUrl, string routeUrl, NameValueCollection param = null,  CancellationToken cancellationToken = default)
        {
            string parameters = string.Empty;

            if (param != null)
            {
                var nameValueCollection = (from key in param.AllKeys
                                           from value in param.GetValues(key)
                                           select string.Format("{0}={1}", HttpUtility.UrlEncode(key), HttpUtility.UrlEncode(value))).ToArray();
                parameters = "?" + string.Join("&", nameValueCollection);
            }
            
            var client = _httpClientFactory.CreateClient();

            var response = await client.GetAsync(baseUrl + routeUrl + parameters, cancellationToken);

            using var stream = await response.Content.ReadAsStreamAsync(cancellationToken);

            return await JsonSerializer.DeserializeAsync<T>(stream, cancellationToken: cancellationToken);
        }
    }
}
