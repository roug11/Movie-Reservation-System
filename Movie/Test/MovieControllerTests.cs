using System.Net;
using System.Text;
using System.Text.Json;
using FluentAssertions;
using FluentAssertions.Execution;
using Movie.Dto;
using Xunit;

namespace Movie.Test
{
    public class MovieControllerTests : IClassFixture<MovieWebApplicationFactory>
    {
        private readonly HttpClient _httpClient;
        private readonly string _baseRequestUrl;
        private readonly JsonSerializerOptions _jsonSerializerOptions = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };

        public MovieControllerTests(MovieWebApplicationFactory factory)
        {
            _httpClient = factory.CreateClient();
            _baseRequestUrl = "movies";
        }

        [Fact]
        public async Task GetMovie_WhenIdExists_ShouldReturnOneMovie()
        {
            // Arrange
            var expectedMovie = new MovieResponseModel
            {
                Id = 1,
                Title = "Lord of the rings",
                Description = ""
            };

            // Act
            var response = await _httpClient.GetAsync($"{_baseRequestUrl}/1").ConfigureAwait(false);
            var content = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
            var actualMovie = JsonSerializer.Deserialize<MovieResponseModel>(content, _jsonSerializerOptions);

            // Assert
            using (new AssertionScope())
            {
                response.StatusCode.Should().Be(HttpStatusCode.OK);
                actualMovie.Should().BeEquivalentTo(expectedMovie);
            }
        }

        [Fact]
        public async Task CreateMovie_WithValidData_ShouldReturnOk()
        {
            // Arrange
            var model = new MovieRequestModel
            {
                Title = "New Movie",
                Description = ""
            };

            var json = JsonSerializer.Serialize(model);
            var data = new StringContent(json, Encoding.UTF8, "application/json");

            // Act
            var response = await _httpClient.PostAsync($"{_baseRequestUrl}", data).ConfigureAwait(false);

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Fact]
        public async Task UpdateMovie_WithValidData_ShouldReturnOk()
        {
            // Arrange
            var idToUpdate = 1; // Specify the ID of the movie to update

            var model = new MovieRequestModel
            {
                Title = "Updated Movie",
                Description = ""
            };

            var json = JsonSerializer.Serialize(model);
            var data = new StringContent(json, Encoding.UTF8, "application/json");

            // Act
            var response = await _httpClient.PutAsync($"{_baseRequestUrl}/{idToUpdate}", data).ConfigureAwait(false);

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Fact]
        public async Task DeleteMovie_WhenIdExists_ShouldReturnOk()
        {
            // Arrange
            var idToDelete = 1;

            // Act
            var response = await _httpClient.DeleteAsync($"{_baseRequestUrl}/{idToDelete}").ConfigureAwait(false);

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }
    }
}