using Chinook.Db.Dev.DataContext;
using Microsoft.Extensions.DependencyInjection;

namespace Chinook.Service.Dev
{
    public static class ServiceRegister
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<DbContext>();

            services.AddScoped<ArtistService>();
            services.AddScoped<AlbumService>();
            services.AddScoped<GenreService>();
        }
    }
}
