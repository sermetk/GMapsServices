using DotNet.Testcontainers.Containers.Builders;
using DotNet.Testcontainers.Containers.Configurations.Databases;
using DotNet.Testcontainers.Containers.Modules.Databases;
using GMapsServices.Api;
using GMapsServices.Api.Components;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Serilog;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace GMapsServices.Tests.Common.Fixtures
{
    public class TestServerFixture : WebApplicationFactory<Startup>, IAsyncLifetime
    {
        public readonly GMapsServicesContext GMapsServicesContext;

        public HttpClient Client { get; }

        private readonly PostgreSqlTestcontainer _postgreSqlTestcontainer;

        private readonly TestServer _testServer;

        public TestServerFixture()
        {
            var databaseBuilder = new TestcontainersBuilder<PostgreSqlTestcontainer>()
                .WithName($"postgres-integration-{DateTime.Now.Ticks}")
                .WithCleanUp(true)
                .WithDatabase(new PostgreSqlTestcontainerConfiguration("postgres:13")
                {
                    Password = "rPNuXjgDa98R",
                    Database = "gmapsservicestestdb",
                    Username = "postgres",
                    Port = 5432
                });

            var builder = new WebHostBuilder()
                .UseEnvironment("Test")
                .UseConfiguration(new ConfigurationBuilder()
                .AddJsonFile("appsettings.test.json")
                .Build())
                .UseStartup<Startup>()
                .UseSerilog((hostingContext, loggerConfiguration) => loggerConfiguration.ReadFrom.Configuration(hostingContext.Configuration));

            _testServer = new TestServer(builder) { AllowSynchronousIO = true };

            GMapsServicesContext = _testServer.Services.GetService(typeof(GMapsServicesContext)) as GMapsServicesContext;

            Client = _testServer.CreateClient();

            _postgreSqlTestcontainer = databaseBuilder.Build();
        }

        public async Task InitializeAsync()
        {
            await _postgreSqlTestcontainer.StartAsync();

            await GMapsServicesContext.Database.EnsureCreatedAsync();
        }

        public async Task DisposeAsync()
        {
            await _postgreSqlTestcontainer.StopAsync();

            Client.Dispose();

            _testServer.Dispose();
        }
    }
}
