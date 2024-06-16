using Movie.Repository;
using Movie.Service;

namespace Movie.Extensions
{
    public static class ServiceExtension
    {

        public static void AddService(this IServiceCollection services)
        {
            services.AddScoped<IMovieService, MovieService>();
        }

        public static void AddRepository(this IServiceCollection services)
        {
            services.AddScoped<IMovieRepository, MovieRepository>();
        }

    }
}
