using Microsoft.EntityFrameworkCore;
using Movie.Context;

namespace Movie.Test
{
    public class DatabaseFixture : IDisposable
    {
        public MovieContext Context;

        public DatabaseFixture()
        {
            var options = new DbContextOptionsBuilder<MovieContext>()
                .UseInMemoryDatabase(databaseName: "movie").Options;

            Context = new MovieContext(options);
        }

        public void Dispose()
        {
            Context.Dispose();
        }
    }
}
