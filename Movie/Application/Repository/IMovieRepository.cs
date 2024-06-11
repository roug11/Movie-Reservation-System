using Movie.Entity;

namespace Movie.Repository
{
    public interface IMovieRepository
    {

        Task<List<MovieEntity>> GetAllAsync(CancellationToken cancellationToken);
        Task<MovieEntity> GetAsync(CancellationToken cancellationToken, int id);
        Task CreateAsync(CancellationToken cancellationToken, MovieEntity movie);
        Task UpdateAsync(CancellationToken cancellationToken, MovieEntity movie);
        Task DeleteAsync(CancellationToken cancellationToken, int id);
        Task<bool> Exists(CancellationToken cancellationToken, int id);

    }
}
