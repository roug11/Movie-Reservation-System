using Movie.Dto;
using Movie.Entity;
using Movie.Exceptions;
using Movie.Repository;
using Movie.Service;
using Moq;
using Xunit;

namespace Movie.Test
{
    public class MovieServiceTests : IClassFixture<DatabaseFixture>
    {
        private readonly DatabaseFixture _fixture;
        private readonly Mock<IMovieRepository> _repository;
        private readonly MovieService _service;

        public MovieServiceTests(DatabaseFixture fixture)
        {
            _fixture = fixture;
            _repository = new Mock<IMovieRepository>();
            _service = new MovieService(_repository.Object);
        }

        [Fact]
        public async Task GetMovie_WhenIdNotExists_ShouldThrowMovieNotFoundException()
        {
            // Arrange
            _repository.Setup(x => x.GetAsync(It.IsAny<CancellationToken>(), It.IsAny<int>()))
                .ThrowsAsync(new MovieNotFoundException("2"));

            // Act
            var task = async () => await _service.Get(CancellationToken.None, 2).ConfigureAwait(false);

            // Assert
            var exception = await Assert.ThrowsAsync<MovieNotFoundException>(task);
            Assert.Equal("Movie 2 not found", exception.Message);
        }

        [Fact]
        public async Task GetMovie_WhenIdExists_ShouldReturnOneMovie()
        {
            // Arrange
            var requestModel = new MovieRequestModel
            {
                Title = "Harry Potter",
                Description = "A story about a boy who lived",
            };

            var movieEntity = new MovieEntity
            {
                Id = 1,
                Title = requestModel.Title,
                Description = requestModel.Description,
            };

            _repository.Setup(x => x.CreateAsync(It.IsAny<CancellationToken>(), It.IsAny<MovieEntity>()))
                .Returns(Task.CompletedTask)
                .Callback<CancellationToken, MovieEntity>((ct, movie) => movie.Id = 1);

            _repository.Setup(x => x.GetAsync(It.IsAny<CancellationToken>(), 1))
                .ReturnsAsync(movieEntity);

            // Act
            await _service.Create(CancellationToken.None, requestModel).ConfigureAwait(false);
            var movie = await _service.Get(CancellationToken.None, 1).ConfigureAwait(false);

            // Assert
            Assert.NotNull(movie);
            Assert.Equal(1, movie.Id);
            Assert.Equal("Harry Potter", movie.Title);
            Assert.Equal("A story about a boy who lived", movie.Description);
            Assert.IsType<MovieResponseModel>(movie);
        }

        [Fact]
        public async Task CreateMovie_WhenDataIsValid_ShouldAddOneMovie()
        {
            //arrange
            var requestModel = new MovieRequestModel()
            {
                Title = "Harry Potter",
                Description = ""
            };

            var repository = new MovieRepository(_fixture.Context);
            var service = new MovieService(repository);
            var last = await service.GetAll(CancellationToken.None);

            //act
            await service.Create(CancellationToken.None, requestModel).ConfigureAwait(false);
            var @new = await service.GetAll(CancellationToken.None);

            //assety
            Assert.NotNull(@new);
            Assert.Equal(last.Count + 1, @new.Count);
        }

        [Fact]
        public async Task DeleteMovie_WhenIdNotExists_ShouldThrowMovieNotFoundException()
        {
            // Arrange
            int movieId = 2;
            _repository.Setup(x => x.GetAsync(It.IsAny<CancellationToken>(), movieId))
                .ThrowsAsync(new MovieNotFoundException($"Movie {movieId} not found"));

            // Act
            var task = async () => await _service.Delete(CancellationToken.None, movieId).ConfigureAwait(false);

            // Assert
            var exception = await Assert.ThrowsAsync<MovieNotFoundException>(task);
            Assert.Equal($"Movie {movieId} not found", exception.Message);
        }

        [Fact]
        public async Task GetAllMovies_ShouldReturnListOfMovies()
        {
            // Arrange
            var movies = new List<MovieEntity>
            {
                new MovieEntity { Id = 1, Title = "Harry Potter", Description = "A story about a boy who lived" },
                new MovieEntity { Id = 2, Title = "Lord of the Rings", Description = "A story about the one ring" }
            };

            _repository.Setup(x => x.GetAllAsync(It.IsAny<CancellationToken>()))
                .ReturnsAsync(movies);

            // Act
            var result = await _service.GetAll(CancellationToken.None).ConfigureAwait(false);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(2, result.Count);
        }
    }
}
