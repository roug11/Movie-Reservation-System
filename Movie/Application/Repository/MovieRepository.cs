using Movie.Context;
using Movie.Entity;

namespace Movie.Repository
{
    public class MovieRepository : BaseRepository<MovieEntity>, IMovieRepository
    {

        public MovieRepository(MovieContext context) : base(context)
        {

        }

        public async Task<MovieEntity> GetAsync(CancellationToken cancellationToken, int id)
        {
            return await base.GetAsync(cancellationToken, id);
        }

        public async Task<List<MovieEntity>> GetAllAsync(CancellationToken cancellationToken)
        {
            return await base.GetAllAsync(cancellationToken);
        }

        public async Task CreateAsync(CancellationToken cancellationToken, MovieEntity movie)
        {
            await base.AddAsync(cancellationToken, movie);
        }

        public async Task UpdateAsync(CancellationToken cancellationToken, MovieEntity movie)
        {
            await base.UpdateAsync(cancellationToken, movie);
        }

        public async Task DeleteAsync(CancellationToken cancellationToken, int id)
        {
            await base.RemoveAsync(cancellationToken, id);
        }

        public async Task<bool> Exists(CancellationToken cancellationToken, int id)
        {
            return await base.AnyAsync(cancellationToken, x => x.Id == id);
        }
    }
}
