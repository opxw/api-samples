namespace Chinook.Dto.Dev
{
    public class ArtistAlbumsDto
    {
        public int ArtistId { get; set; }
        public string Name { get; set; } = "";
        public List<AlbumDto> Albums { get; set; } = [];
    }
}
