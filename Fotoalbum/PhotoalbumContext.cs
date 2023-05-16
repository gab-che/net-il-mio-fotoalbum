using Fotoalbum.Models;
using Microsoft.EntityFrameworkCore;

namespace Fotoalbum
{
    public class PhotoalbumContext : DbContext
    {
        public DbSet<PhotoEntry> PhotoEntries { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<Author> Authors { get; set; }

        public PhotoalbumContext(DbContextOptions<PhotoalbumContext>dbContext) : base(dbContext) { }

    }

}
