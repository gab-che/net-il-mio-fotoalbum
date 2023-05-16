using Fotoalbum.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Fotoalbum
{
    public class PhotoalbumContext : IdentityDbContext<IdentityUser>
    {
        public DbSet<PhotoEntry> PhotoEntries { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<Author> Authors { get; set; }

        public PhotoalbumContext(DbContextOptions<PhotoalbumContext>dbContext) : base(dbContext) { }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                IConfigurationRoot configuration = new ConfigurationBuilder()
                              .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                              .AddJsonFile("appsettings.json")
                              .Build();
                optionsBuilder.UseSqlServer(configuration.GetConnectionString("Photoalbum"));
            }
        }
    }

}
