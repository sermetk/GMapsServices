using GMapsServices.Common.Constants;
using GMapsServices.Common.Contracts;
using GMapsServices.Common.Dtos.GooglePlaces;
using System.Collections.Specialized;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace GMapsServices.BusinessEngine
{
    public class MapsBusinessEngine : IMapsBusinessEngine
    {
        private readonly IExternalHttpRequestBusinessEngine externalHttpRequestBusinessEngine;
        public MapsBusinessEngine(IExternalHttpRequestBusinessEngine externalHttpRequestBusinessEngine)
        {
            this.externalHttpRequestBusinessEngine = externalHttpRequestBusinessEngine;
        }

        public Task<PlacesAutoCompleteDto> GetAutoCompleteAsync(string origin, string input)
        {
            if (string.IsNullOrEmpty(origin))
                throw new ValidationException("Origin cannot be null");
            if (string.IsNullOrEmpty(input))
                throw new ValidationException("Input cannot be null");
            return Task.Run(() =>
            {
                var parameters = new NameValueCollection
                {
                    { "input", input },
                    { "language", "tr" },
                    { "origin", origin },
                    { "location",  origin },
                    { "radius", "3000" },
                    { "strictbounds", string.Empty },
                    { "key", Consts.GMAPS_API_KEY }
                };
                return externalHttpRequestBusinessEngine.GetAsync<PlacesAutoCompleteDto>(Consts.GMAPS_BASE_URL, Consts.AUTOCOMPLETE_END_POINT, parameters);
            });
        }
        public Task<PlacesDetailDto> GetPlaceDetailAsync(string placeId)
        {
            if(string.IsNullOrEmpty(placeId))
                throw new ValidationException("PlaceId cannot be null");
            return Task.Run(() =>
            {
                var parameters = new NameValueCollection
                {
                    { "placeid", placeId },
                    { "key", Consts.GMAPS_API_KEY }
                };
                return externalHttpRequestBusinessEngine.GetAsync<PlacesDetailDto>(Consts.GMAPS_BASE_URL,Consts.PLACE_DETAIL_END_POINT, parameters);
            });
        }
        public Task<ReverseGeocodeDto> GetReverseGeocodeAsync(string latlng)
        {
            if (string.IsNullOrEmpty(latlng))
                throw new ValidationException("Latlng cannot be null");
            return Task.Run(() =>
            {
                var parameters = new NameValueCollection
                {
                    { "latlng", latlng },
                    { "key", Consts.GMAPS_API_KEY }
                };
                return externalHttpRequestBusinessEngine.GetAsync<ReverseGeocodeDto>(Consts.GMAPS_BASE_URL,Consts.REVERSE_GEOCODE_END_POINT,parameters);
            });
        }
        public Task<RouteDirectionDto> GetRouteAsync(string origin,string destination)
        {
            if (string.IsNullOrEmpty(origin))
                throw new ValidationException("Origin cannot be null");
            if (string.IsNullOrEmpty(destination))
                throw new ValidationException("Destination cannot be null");
            return Task.Run(() =>
            {
                var parameters = new NameValueCollection
                {
                    { "origin", origin },
                    { "destination", destination },
                    { "key", Consts.GMAPS_API_KEY }
                };
                return externalHttpRequestBusinessEngine.GetAsync<RouteDirectionDto>(Consts.GMAPS_BASE_URL,Consts.ROUTE_DIRECTION_END_POINT,parameters);
            });
        }    
    }
}
