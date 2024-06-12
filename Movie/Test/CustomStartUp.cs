using Microsoft.AspNetCore.Authorization;
using Movie.Controllers;

namespace Movie.Test
{
    public class CustomStartup
    {
        public IConfiguration Configuration { get; set; }
        public IWebHostEnvironment Environment { get; set; }

        public CustomStartup(IConfiguration configuration, IWebHostEnvironment environment)
        {
            Configuration = configuration;
            Environment = environment;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers()
            .AddApplicationPart(typeof(MovieController).Assembly);
        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers().WithMetadata(new AllowAnonymousAttribute());
            });
        }

    }
}

