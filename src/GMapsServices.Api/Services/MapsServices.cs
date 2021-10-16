using System.Collections.Specialized;
using System.ComponentModel.DataAnnotations;
using System.Threading;
using System.Threading.Tasks;
using GMapsServices.Api.Components;
using GMapsServices.Api.Contracts;
using GMapsServices.Api.Models;
using Microsoft.Extensions.Options;

namespace GMapsServices.Api.Services
{
    public class MapsService : IMapsServices
    {
        private readonly IExternalHttpRequests _externalHttpRequests;

        private readonly GoogleMapsOptions _googleMapsOptions;

        public MapsService(IExternalHttpRequests externalHttpRequests, IOptions<GoogleMapsOptions> googleMapsOptions)
        {
            _externalHttpRequests = externalHttpRequests;

            _googleMapsOptions = googleMapsOptions.Value;
        }

        public async Task<PlacesAutoCompleteDto> AutoCompleteAsync(string origin, string input, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrEmpty(origin))
                throw new ValidationException("Origin cannot be null");

            if (string.IsNullOrEmpty(input))
                throw new ValidationException("Input cannot be null");

            var parameters = new NameValueCollection
            {
                { "input", input },
                { "language", "tr" },
                { "origin", origin },
                { "location",  origin },
                { "radius", "3000" },
                { "strictbounds", string.Empty },
                { "key", _googleMapsOptions.ApiKey }
            };

            return await _externalHttpRequests.GetAsync<PlacesAutoCompleteDto>(Consts.GMAPS_BASE_URL, Consts.AUTOCOMPLETE_END_POINT, parameters, cancellationToken);
        }

        public async Task<PlacesDetailDto> PlaceDetailAsync(string placeId, CancellationToken cancellationToken = default)
        {
            if(string.IsNullOrEmpty(placeId))
                throw new ValidationException("PlaceId cannot be null");

            var parameters = new NameValueCollection
            {
                { "placeid", placeId },
                { "key", _googleMapsOptions.ApiKey }
            };

            return await _externalHttpRequests.GetAsync<PlacesDetailDto>(Consts.GMAPS_BASE_URL, Consts.PLACE_DETAIL_END_POINT, parameters, cancellationToken);
        }

        public async Task<ReverseGeocodeDto> ReverseGeocodeAsync(string latlng, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrEmpty(latlng))
                throw new ValidationException("Latlng cannot be null");

            var parameters = new NameValueCollection
            {
                { "latlng", latlng },
                { "key", _googleMapsOptions.ApiKey }
            };

            return await _externalHttpRequests.GetAsync<ReverseGeocodeDto>(Consts.GMAPS_BASE_URL, Consts.REVERSE_GEOCODE_END_POINT, parameters, cancellationToken);
        }

        public async Task<RouteDirectionDto> RouteAsync(string origin,string destination, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrEmpty(origin))
                throw new ValidationException("Origin cannot be null");

            if (string.IsNullOrEmpty(destination))
                throw new ValidationException("Destination cannot be null");

            var parameters = new NameValueCollection
            {
                { "origin", origin },
                { "destination", destination },
                { "key", _googleMapsOptions.ApiKey }
            };

            return await _externalHttpRequests.GetAsync<RouteDirectionDto>(Consts.GMAPS_BASE_URL, Consts.ROUTE_DIRECTION_END_POINT, parameters, cancellationToken);
        }
    }
}
