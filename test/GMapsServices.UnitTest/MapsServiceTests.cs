using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using GMapsServices.Api.Contracts;
using GMapsServices.Api.Models;
using GMapsServices.Api.Services;
using Microsoft.Extensions.Options;
using Moq;
using Xunit;

namespace Test
{
    public class MapsServiceTests
    {
        private readonly MapsService _mapsService;

        public MapsServiceTests()
        {
            var externalHttpRequests = new Mock<IExternalHttpRequests>();

            var googleMapsOptions = Options.Create(new GoogleMapsOptions { ApiKey = string.Empty });

            _mapsService = new MapsService(externalHttpRequests.Object, googleMapsOptions);
        }

        [Fact]
        public async Task PlaceDetailAsync_Given_Empty_Uri_Should_Return_Error()
        {
            var @object = string.Empty;

            await Assert.ThrowsAsync<ValidationException>(() => _mapsService.PlaceDetailAsync(@object));
        }
    }
}
