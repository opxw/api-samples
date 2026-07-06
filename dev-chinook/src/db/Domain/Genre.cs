using LinqToDB.Mapping;

namespace Chinook.Db.Dev.Domain
{
    public class Genre
    {
        [PrimaryKey]
        public int GenreId { get; set; }
        public string Name { get; set; } = "";
    }
}
