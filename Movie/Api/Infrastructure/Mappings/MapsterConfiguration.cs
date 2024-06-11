using Mapster;
using Movie.Dto;
using Movie.Entity;

namespace Movie.Mappings
{
    public static class MapsterConfiguration
    {

        public static void RegisterMaps(this IServiceCollection services)
        {
            TypeAdapterConfig<MovieRequestModel, MovieEntity>
            .NewConfig()
            .TwoWays();

            TypeAdapterConfig<MovieRequestModel, MovieResponseModel>
            .NewConfig()
            .TwoWays();
        }

    }
}
