using Mapster;
using Movie.Dto;
using Movie.Entity;
using Movie.Exceptions;
using Movie.Repository;

namespace Movie.Service
{
    public class MovieService : IMovieService
    {

        private readonly IMovieRepository _repository;

        public MovieService(IMovieRepository repository)
        {
            _repository = repository;
        }
        public async Task<MovieResponseModel> Create(CancellationToken cancellationToken, MovieRequestModel movie)
        {
            var movieToInsert = movie.Adapt<MovieEntity>();
            await _repository.CreateAsync(cancellationToken, movieToInsert);

            var responseModel = movieToInsert.Adapt<MovieResponseModel>();
            return responseModel;
        }

        public async Task Delete(CancellationToken cancellationToken, int id)
        {
            if (!await _repository.ExistsAsync(cancellationToken, id))
                throw new MovieNotFoundException(id.ToString());

            await _repository.DeleteAsync(cancellationToken, id);
        }

        public async Task<MovieResponseModel> Get(CancellationToken cancellationToken, int id)
        {
            var result = await _repository.GetAsync(cancellationToken, id);

            if (result == null)
                throw new MovieNotFoundException(id.ToString());
            else
                return result.Adapt<MovieResponseModel>();
        }

        public async Task<List<MovieResponseModel>> GetAll(CancellationToken cancellationToken)
        {
            var result = await _repository.GetAllAsync(cancellationToken);

            return result.Adapt<List<MovieResponseModel>>();
        }

        public async Task Update(CancellationToken cancellationToken, int id, MovieRequestModel movie)
        {
            if (!await _repository.ExistsAsync(cancellationToken, id))
                throw new MovieNotFoundException(id.ToString());

            var movieToUpdate = movie.Adapt<MovieEntity>();

            movieToUpdate.Id = id;

            await _repository.UpdateAsync(cancellationToken, movieToUpdate);
        }

    }
}
