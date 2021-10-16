using System.Threading.Tasks;
using GMapsServices.Tests.Common.Fixtures;
using Xunit;

namespace GMapsServices.IntegrationTest
{
    public class GMapsServiceTest : IClassFixture<TestServerFixture>
    {
        private readonly TestServerFixture _fixture;

        public GMapsServiceTest(TestServerFixture fixture)
        {
            _fixture = fixture;
        }

        [Fact]
        public async Task Requests_Should_Save_The_Database()
        {
            var canConnect = await _fixture.GMapsServicesContext.Database.CanConnectAsync();

            Assert.True(canConnect);
        }
    }
}