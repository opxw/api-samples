// Copyright (c) 2026 - opx
using LinqToDB.Mapping;

namespace Chinook.Db.Dev.Domain
{
    public class Album
    {
        [PrimaryKey]
        public int AlbumId { get; set; }
        public string Title { get; set; } = "";
        public int ArtistId { get; set; }
    }
}
