using Microsoft.AspNetCore.Mvc;
using Movie.Dto;
using Movie.Service;

namespace Movie.Controllers
{
    [Route("api/movie")]
    [ApiController]
    public class MovieController : ControllerBase
    {

        private readonly IMovieService _movieService;

        public MovieController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        [HttpGet]
        public async Task<List<MovieResponseModel>> GetAll(CancellationToken cancellationToken)
        {
            return await _movieService.GetAll(cancellationToken);
        }

        [HttpGet("{id}")]
        public async Task<MovieResponseModel> Get(CancellationToken cancellationToken, int id)
        {
            return await _movieService.Get(cancellationToken, id);
        }

        [HttpDelete("{id}")]
        public async Task Delete(CancellationToken cancellationToken, int id)
        {
            await _movieService.Delete(cancellationToken, id);
        }

        [HttpPost]
        public async Task Post(CancellationToken cancellationToken, MovieRequestModel request)
        {
            await _movieService.CreateAsync(cancellationToken, request);
        }

        [HttpPut]
        public async Task Put(CancellationToken cancellationToken, MovieRequestModel request)
        {
            await _movieService.Update(cancellationToken, request);
        }

    }
}
