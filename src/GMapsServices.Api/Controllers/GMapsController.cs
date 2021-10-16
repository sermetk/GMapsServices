using System.Threading;
using System.Threading.Tasks;
using GMapsServices.Api.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace GMapsServices.Api.Controllers
{
    public class GMapsController : Controller
    {
        private readonly IMapsServices _mapsServices;

        public GMapsController(IMapsServices mapsServices)
        {
            _mapsServices = mapsServices;
        }

        [HttpGet]
        [Route("/Maps/Route")]
        public async Task<IActionResult> Route(string origin, string destination, CancellationToken cancellationToken)
        {
            var result = await _mapsServices.RouteAsync(origin, destination, cancellationToken);

            return Ok(result);
        }

        [HttpGet]
        [Route("/Maps/PlaceDetail")]
        public async Task<IActionResult> PlaceDetail(string placeId, CancellationToken cancellationToken)
        {
            var result = await _mapsServices.PlaceDetailAsync(placeId, cancellationToken);

            return Ok(result);
        }

        [HttpGet]
        [Route("/Maps/AutoComplete")]
        public async Task<IActionResult> AutoComplete(string origin, string input, CancellationToken cancellationToken)
        {
            var result = await _mapsServices.AutoCompleteAsync(origin, input, cancellationToken);

            return Ok(result);
        }

        [HttpGet]
        [Route("/Maps/ReverseGeocode")]
        public async Task<IActionResult> ReverseGeocode(string latlng, CancellationToken cancellationToken)
        {
            var result = await _mapsServices.ReverseGeocodeAsync(latlng, cancellationToken);

            return Ok(result);
        }
    }
}
