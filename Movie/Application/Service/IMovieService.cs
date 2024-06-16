using Movie.Dto;

namespace Movie.Service
{
    public interface IMovieService
    {

        Task<MovieResponseModel> Create(CancellationToken cancellationToken, MovieRequestModel movie);
        Task<List<MovieResponseModel>> GetAll(CancellationToken cancellationToken);
        Task<MovieResponseModel> Get(CancellationToken cancellationToken, int id);
        Task Update(CancellationToken cancellationToken, int id, MovieRequestModel movie);
        Task Delete(CancellationToken cancellationToken, int id);

    }
}