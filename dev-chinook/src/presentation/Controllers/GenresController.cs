using Chinook.Service.Dev;
using Microsoft.AspNetCore.Mvc;

namespace Chinook.Api.Dev.Controllers
{
    [Route("api/genres")]
    public class GenresController : ApiController
    {
        private readonly GenreService _genreService;

        public GenresController(GenreService genreService)
        {
            _genreService = genreService;
        }

        [HttpGet]
        public Task GetGenres()
        {
            return OkOrFailAsync(_genreService.GetGenresAsync());
        }

        [HttpGet("{id:int}")]
        public Task GetGenre(int id)
        {
            return OkOrFailAsync(_genreService.GetGenreAsync(id));
        }
    }
}
