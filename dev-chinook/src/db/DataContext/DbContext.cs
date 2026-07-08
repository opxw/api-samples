// Copyright (c) 2026 - opx
using Chinook.Db.Dev.Domain;
using LinqToDB;
using MySqlConnector;
using Opx.Api.Infrastructure.Database;

namespace Chinook.Db.Dev.DataContext
{
    public class DbContext : AppDbContext
    {
        public DbContext()
        {
            var cs = new MySqlConnectionStringBuilder()
            {
                UserID = "root",
                Password = "root",
                Database = "Chinook",
                Server = "localhost",
                Port = 3306,
            };
            this.Setup(ProviderName.MariaDB10MySqlConnector, cs.ConnectionString);
        }

        public ITable<Album> Album  =>  GetTable<Album>();
        public ITable<Artist> Artist => GetTable<Artist>();
        public ITable<Genre> Genre => GetTable<Genre>();

        public async Task WarmupAsync()
        {
            await LinqToDB.Async.AsyncExtensions.ToListAsync(Artist.Take(1).AsQueryable());
            await LinqToDB.Async.AsyncExtensions.ToListAsync(Album.Take(1).AsQueryable());
            await LinqToDB.Async.AsyncExtensions.ToListAsync(Genre.Take(1).AsQueryable());
        }
    }
}
