using System.Collections.Specialized;
using System.Threading.Tasks;

namespace GMapsServices.Common.Contracts
{
    public interface IExternalHttpRequestBusinessEngine
    {
        Task<T> GetAsync<T>(string baseUrl, string routeUrl, NameValueCollection param = null);
    }
}
