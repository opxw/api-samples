using LinqToDB.Mapping;

namespace Chinook.Db.Dev.Domain
{
    public class Artist
    {
        [PrimaryKey]
        public int ArtistId { get; set; }
        public string Name { get; set; } = "";
    }
}
