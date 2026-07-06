using Chinook.Service.Dev;
using Microsoft.AspNetCore.Mvc;

namespace Chinook.Api.Dev.Controllers
{
    [Route("api/artists")]
    public class ArtistsController : ApiController
    {
        private readonly ArtistService _artistService;

        public ArtistsController(ArtistService artistService)
        {
            _artistService = artistService;
        }

        [HttpGet]
        public Task GetArtists()
        {
            return OkOrFailAsync(_artistService.GetArtistsAsync());
        }

        [HttpGet("{id:int}")]
        public Task GetArtist(int id)
        {
            return OkOrFailAsync(_artistService.GetArtistAsync(id));
        }

        [HttpGet("with-albums")]
        public Task GetArtistsWithAlbums()
        {
            return OkOrFailAsync(_artistService.GetArtistsWithAlbumsAsync());
        }
    }
}
