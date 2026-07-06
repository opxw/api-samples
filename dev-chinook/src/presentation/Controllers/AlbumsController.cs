using Chinook.Service.Dev;
using Microsoft.AspNetCore.Mvc;

namespace Chinook.Api.Dev.Controllers
{
    [Route("api/albums")]
    public class AlbumsController : ApiController
    {
        private readonly AlbumService _albumService;

        public AlbumsController(AlbumService albumService)
        {
            _albumService = albumService;
        }

        [HttpGet]
        public Task GetAlbums()
        {
            return OkOrFailAsync(_albumService.GetAlbumsAsync());
        }

        [HttpGet("{id:int}")]
        public Task GetAlbum(int id)
        {
            return OkOrFailAsync(_albumService.GetAlbumAsync(id));
        }
    }
}
