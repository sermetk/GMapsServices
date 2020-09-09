using GMapsServices.Common.Dtos.GooglePlaces;
using System.Threading.Tasks;

namespace GMapsServices.Common.Contracts
{
    public interface IMapsBusinessEngine 
    {
        Task<PlacesAutoCompleteDto> GetAutoCompleteAsync(string origin, string search);
        Task<PlacesDetailDto> GetPlaceDetailAsync(string placeId);
        Task<ReverseGeocodeDto> GetReverseGeocodeAsync(string latlng);
        Task<RouteDirectionDto> GetRouteAsync(string origin,string keyword);
    }
}
