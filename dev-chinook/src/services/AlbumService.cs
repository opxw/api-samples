using Chinook.Db.Dev.DataContext;
using Opx.Api.Infrastructure.Service;

namespace Chinook.Service.Dev
{
    public class AlbumService : AppService
    {
        private readonly DbContext _dbContext;

        public AlbumService(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task<AppResult> GetAlbumsAsync()
        {
            return ExecuteAsync(async () =>
            {
                var query = _dbContext.Album
                    .OrderBy(album => album.Title)
                    .AsQueryable();
                var albums = await LinqToDB.Async.AsyncExtensions.ToListAsync(query);

                return Success(albums);
            });
        }

        public Task<AppResult> GetAlbumAsync(int id)
        {
            return ExecuteAsync(async () =>
            {
                var query = _dbContext.Album
                    .Where(album => album.AlbumId == id)
                    .Take(1)
                    .AsQueryable();
                var album = (await LinqToDB.Async.AsyncExtensions.ToListAsync(query)).FirstOrDefault();

                if (album is null)
                {
                    return ValidationError("Album not found");
                }

                return Success(album);
            });
        }
    }
}
