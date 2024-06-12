using Movie.Entity;
using Movie.Repository;

namespace Movie.Test
{
    public class MockMovieRepository : IMovieRepository
    {
        private readonly List<MovieEntity> _movies;

        public MockMovieRepository()
        {
            _movies = new List<MovieEntity>();
        }

        public Task CreateAsync(CancellationToken cancellationToken, MovieEntity movie)
        {
            if (movie == null)
                throw new ArgumentNullException(nameof(movie));

            // Simulate adding a new movie and assign an ID
            movie.Id = _movies.Count > 0 ? _movies.Max(m => m.Id) + 1 : 1;
            _movies.Add(movie);
            return Task.CompletedTask;
        }

        public Task DeleteAsync(CancellationToken cancellationToken, int id)
        {
            var movieToRemove = _movies.FirstOrDefault(m => m.Id == id);
            if (movieToRemove != null)
                _movies.Remove(movieToRemove);
            return Task.CompletedTask;
        }

        public Task<bool> Exists(CancellationToken cancellationToken, int id)
        {
            var movieExists = _movies.Any(m => m.Id == id);
            return Task.FromResult(movieExists);
        }

        public Task<List<MovieEntity>> GetAllAsync(CancellationToken cancellationToken)
        {
            return Task.FromResult(_movies);
        }

        public Task<MovieEntity> GetAsync(CancellationToken cancellationToken, int id)
        {
            var movie = _movies.FirstOrDefault(m => m.Id == id);
            return Task.FromResult(movie);
        }

        public Task UpdateAsync(CancellationToken cancellationToken, MovieEntity movie)
        {
            if (movie == null)
                throw new ArgumentNullException(nameof(movie));

            var existingMovie = _movies.FirstOrDefault(m => m.Id == movie.Id);
            if (existingMovie != null)
            {
                existingMovie.Title = movie.Title;
                existingMovie.Description = movie.Description;
            }
            return Task.CompletedTask;
        }
    }
}
