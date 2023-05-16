using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Fotoalbum.Seeder
{
    public static class ModelBuilderExtension
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<IdentityRole>().HasData(
                new IdentityRole { Id = "1", Name = "SUPERADMIN", NormalizedName = "SUPERADMIN", ConcurrencyStamp = "16/05/2023" },
                new IdentityRole { Id = "2", Name = "ADMIN", NormalizedName = "ADMIN", ConcurrencyStamp = "16/05/2023" },
                new IdentityRole { Id = "3", Name = "USER", NormalizedName = "USER", ConcurrencyStamp = "16/05/2023" }
                );
        }
    }
}
