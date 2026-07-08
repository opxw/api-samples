// Copyright (c) 2026 - opx
using Chinook.Db.Dev.DataContext;
using Chinook.Dto.Dev;
using Opx.Api.Infrastructure.Service;

namespace Chinook.Service.Dev
{
    public class ArtistService : AppService
    {
        private readonly DbContext _dbContext;

        public ArtistService(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task<AppResult> GetArtistsAsync()
        {
            return ExecuteAsync(async () =>
            {
                var query = _dbContext.Artist
                    .OrderBy(artist => artist.Name)
                    .AsQueryable();
                var artists = await LinqToDB.Async.AsyncExtensions.ToListAsync(query);

                return Success(artists);
            });
        }

        public Task<AppResult> GetArtistAsync(int id)
        {
            return ExecuteAsync(async () =>
            {
                var query = _dbContext.Artist
                    .Where(artist => artist.ArtistId == id)
                    .Take(1)
                    .AsQueryable();
                var artist = (await LinqToDB.Async.AsyncExtensions.ToListAsync(query)).FirstOrDefault();

                if (artist is null)
                {
                    return ValidationError("Artist not found");
                }

                return Success(artist);
            });
        }

        public Task<AppResult> GetArtistsWithAlbumsAsync()
        {
            return ExecuteAsync(async () =>
            {
                var query =
                    from artist in _dbContext.Artist
                    join album in _dbContext.Album on artist.ArtistId equals album.ArtistId into albums
                    from album in albums.DefaultIfEmpty()
                    orderby artist.Name, album.Title
                    select new
                    {
                        artist.ArtistId,
                        artist.Name,
                        AlbumId = album != null ? album.AlbumId : 0,
                        AlbumTitle = album != null ? album.Title : null
                    };

                var rows = await LinqToDB.Async.AsyncExtensions.ToListAsync(query);
                var artists = rows
                    .GroupBy(row => new { row.ArtistId, row.Name })
                    .Select(group => new ArtistAlbumsDto
                    {
                        ArtistId = group.Key.ArtistId,
                        Name = group.Key.Name,
                        Albums = group
                            .Where(row => row.AlbumId > 0)
                            .Select(row => new AlbumDto
                            {
                                AlbumId = row.AlbumId,
                                Title = row.AlbumTitle ?? ""
                            })
                            .ToList()
                    })
                    .ToList();

                return Success(artists);
            });
        }
    }
}
