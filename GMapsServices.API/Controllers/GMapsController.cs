using System.Threading.Tasks;
using GMapsServices.Common.Contracts;
using GMapsServices.Common.Dtos.GooglePlaces;
using Microsoft.AspNetCore.Mvc;

namespace GMapsServices.API.Controllers
{
    public class GMapsController : Controller
    {
        private readonly IMapsBusinessEngine mapsBusinessEngine;
        public GMapsController(IMapsBusinessEngine mapsBusinessEngine)
        {
            this.mapsBusinessEngine = mapsBusinessEngine;
        }
        [HttpGet]
        [Route("/Maps/GetRoute")]
        public async Task<RouteDirectionDto> GetRoute(string origin, string destination)
        {
            return await mapsBusinessEngine.GetRouteAsync(origin, destination);
        }
        [HttpGet]
        [Route("/Maps/GetPlaceDetail")]
        public async Task<PlacesDetailDto> GetPlaceDetail(string placeId)
        {
            return await mapsBusinessEngine.GetPlaceDetailAsync(placeId);
        }
        [HttpGet]
        [Route("/Maps/GetAutoComplete")]
        public async Task<PlacesAutoCompleteDto> GetAutoComplete(string origin, string input)
        {
            return await mapsBusinessEngine.GetAutoCompleteAsync(origin, input);
        }
        [HttpGet]
        [Route("/Maps/GetReverseGeocode")]
        public async Task<ReverseGeocodeDto> GetReverseGeocode(string latlng)
        {
            return await mapsBusinessEngine.GetReverseGeocodeAsync(latlng);
        }
    }
}
