using Microsoft.EntityFrameworkCore;


namespace vidoGameapi.Data
{
    public class VideoGameDbContext(DbContextOptions<VideoGameDbContext> options) : DbContext(options)
    {
        public DbSet<VideoGame> VideoGames => Set<VideoGame>();
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<VideoGame>().HasData(
                new VideoGame
                {
                    Id = 1,
                    Title = "spider-man 2",
                    Platform = "ps5",
                    Developer = "insomniac games",
                    Publisher = "sony interactive entertainment",
                },
            new VideoGame
            {
                Id = 2,
                Title = "the last of us part 1",
                Platform = "ps5",
                Developer = "naughty dog",
                Publisher = "sony interactive entertainment"
            },
            new VideoGame
            {
                Id = 3,
                Title = "the legend of zelda: breath of the wild",
                Platform = "nintendo switch",
                Developer = "nintendo",
                Publisher = "nintendo"
            }

                );
        }
    }
}
