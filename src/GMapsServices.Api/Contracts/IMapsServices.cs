using System.Threading;
using System.Threading.Tasks;
using GMapsServices.Api.Models;

namespace GMapsServices.Api.Contracts
{
    public interface IMapsServices 
    {
        Task<PlacesAutoCompleteDto> AutoCompleteAsync(string origin, string search, CancellationToken cancellationToken = default);

        Task<PlacesDetailDto> PlaceDetailAsync(string placeId, CancellationToken cancellationToken = default);

        Task<ReverseGeocodeDto> ReverseGeocodeAsync(string latlng, CancellationToken cancellationToken = default);

        Task<RouteDirectionDto> RouteAsync(string origin,string keyword, CancellationToken cancellationToken = default);
    }
}
