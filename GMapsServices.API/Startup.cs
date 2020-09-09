using GMapsServices.BusinessEngine;
using GMapsServices.Common.Contracts;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace GMapsServices.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public IConfiguration Configuration { get; }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient(typeof(IHttpContextAccessor), typeof(HttpContextAccessor));
            services.AddScoped(typeof(IMapsBusinessEngine), typeof(MapsBusinessEngine));  
            services.AddScoped(typeof(IExternalHttpRequestBusinessEngine), typeof(ExternalHttpRequestBusinessEngine));
            services.AddHttpClient();
            services.AddControllers().AddJsonOptions(opt => opt.JsonSerializerOptions.PropertyNamingPolicy = null);
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "GMaps Place Services",
                    Version = "1.0.0"
                });
            });
        }
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization(); 
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            if (env.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "GMapsServices");
                    c.RoutePrefix = "docs";
                    c.DocumentTitle = "GMapsServices API";
                });
            }
        }      
    }
}
