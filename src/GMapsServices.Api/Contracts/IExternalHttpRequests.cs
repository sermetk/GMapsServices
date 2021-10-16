using System.Collections.Specialized;
using System.Threading;
using System.Threading.Tasks;

namespace GMapsServices.Api.Contracts
{
    public interface IExternalHttpRequests
    {
        Task<T> GetAsync<T>(string baseUrl, string routeUrl, NameValueCollection param = null, CancellationToken cancellationToken = default);
    }
}
