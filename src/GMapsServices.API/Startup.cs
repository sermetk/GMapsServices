using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.EntityFrameworkCore;
using Serilog;
using GMapsServices.Api.Components;
using GMapsServices.Api.Filters;
using GMapsServices.Api.Contracts;
using GMapsServices.Api.Services;
using GMapsServices.Api.Models;

namespace GMapsServices.Api
{
    public class Startup
    {
        private readonly IConfiguration _configuration;

        private readonly IHostEnvironment _environment;

        public Startup(IConfiguration configuration, IHostEnvironment environment)
        {
            _configuration = configuration;

            _environment = environment;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<GoogleMapsOptions>(options => _configuration.GetSection("Maps").Bind(options));

            services.AddTransient(typeof(IMapsServices), typeof(MapsService));

            services.AddTransient(typeof(IExternalHttpRequests), typeof(ExternalHttpRequests));

            services.AddHttpClient();

            services.AddControllers(options => options.Filters.Add(typeof(ServiceResultWrapper)));

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "GMaps Place Services",
                    Version = "1.0.0"
                });
            });

            services.AddDbContextPool<GMapsServicesContext>(options =>
            {
                options.UseNpgsql(_configuration.GetConnectionString("Database")).EnableSensitiveDataLogging(_environment.IsDevelopment());

                options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseSerilogRequestLogging(options => options.EnrichDiagnosticContext = (diagnosticContext, httpContext) =>
            {
                if (httpContext.Features.Get<IExceptionHandlerPathFeature>() != null)
                {
                    diagnosticContext.Set("Exception", httpContext.Features.Get<IExceptionHandlerPathFeature>().Error);
                }
            });


            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "GMapsServices v1");

                c.RoutePrefix = string.Empty;
            });

            app.UseRouting();

            app.UseEndpoints(endpoints => endpoints.MapControllers());

            //if (!env.IsEnvironment("Test"))
            //{
            //    gmapsServicesContext.Database.EnsureCreated();
            //}
        }      
    }
}
