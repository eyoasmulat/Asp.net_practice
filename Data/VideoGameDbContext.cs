using System.Data.Entity;

namespace vidoGameapi.Data
{
    public class VideoGameDbContext(DbContextOptions<VideoGameDbContext> options) : DbContext(options)
    {
    }
}
