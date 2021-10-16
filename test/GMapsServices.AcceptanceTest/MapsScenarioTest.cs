using System.Net;
using System.Text.Json;
using System.Threading.Tasks;
using GMapsServices.Api.Models;
using GMapsServices.Tests.Common.Fixtures;
using Xunit;

namespace GMapsServices.AcceptanceTest
{
    public class MapsScenarioTest : IClassFixture<TestServerFixture>
    {
        private readonly TestServerFixture _fixture;

        private const string PLACE_DETAIL_PATH = "/Maps/PlaceDetail";

        public MapsScenarioTest(TestServerFixture fixture)
        {
            _fixture = fixture;
        }
        
        [Theory]
        [InlineData("ChIJnZfXqa3HyhQRS7k1BjKX8fg")]
        public async Task PlaceDetail_When_Valid_PlaceId_Return_Valid_Detail(string placeId)
        {
            var @object = $"?placeid={placeId}";

            var url = PLACE_DETAIL_PATH + @object;

            var expectedStatusCode = HttpStatusCode.OK;

            var expectedResult = new ServiceResultModel<PlacesDetailDto>
            {
                data = new PlacesDetailDto
                {
                    result = new Result { formatted_address = "GÖZTEPE MH, Tütüncü Mehmet Efendi Cd. NO 10/C, 34010 Kadıköy/İstanbul, Turkey" }
                }
            };


            var response = await _fixture.Client.GetAsync(url);

            var actualStatusCode = response.StatusCode;

            var result = await response.Content.ReadAsStringAsync();

            var actualResult = JsonSerializer.Deserialize<ServiceResultModel<PlacesDetailDto>>(result);



            Assert.Equal(expectedResult.data.result.formatted_address, actualResult.data.result.formatted_address);

            Assert.Equal(expectedStatusCode, actualStatusCode);
        }
    }
}
