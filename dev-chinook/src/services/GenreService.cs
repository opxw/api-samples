using Chinook.Db.Dev.DataContext;
using Opx.Api.Infrastructure.Service;

namespace Chinook.Service.Dev
{
    public class GenreService : AppService
    {
        private readonly DbContext _dbContext;

        public GenreService(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task<AppResult> GetGenresAsync()
        {
            return ExecuteAsync(async () =>
            {
                var query = _dbContext.Genre
                    .OrderBy(genre => genre.Name)
                    .AsQueryable();
                var genres = await LinqToDB.Async.AsyncExtensions.ToListAsync(query);

                return Success(genres);
            });
        }

        public Task<AppResult> GetGenreAsync(int id)
        {
            return ExecuteAsync(async () =>
            {
                var query = _dbContext.Genre
                    .Where(genre => genre.GenreId == id)
                    .Take(1)
                    .AsQueryable();
                var genre = (await LinqToDB.Async.AsyncExtensions.ToListAsync(query)).FirstOrDefault();

                if (genre is null)
                {
                    return ValidationError("Genre not found");
                }

                return Success(genre);
            });
        }
    }
}
