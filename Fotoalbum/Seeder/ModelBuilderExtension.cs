using Fotoalbum.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Fotoalbum.Seeder
{
    public static class ModelBuilderExtension
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            Dictionary<string, string> photoCategories = new()
            {
                { "travel", "Capture your adventures around the world." },
                { "nature", "Explore the beauty of the great outdoors." },
                { "food", "Savor delicious dishes from various cuisines." },
                { "portrait", "Capture the essence and personality of individuals." },
                { "architecture", "Discover stunning buildings and structures." }
            };

            for(int i = 0; i < photoCategories.Count; i++)
            {
                KeyValuePair<string, string> category = photoCategories.ElementAt(i);
                modelBuilder.Entity<Category>()
                    .HasData(
                        new Category { Id = i + 1, Name = category.Key, Description = category.Value }
                    );
            }

            modelBuilder.Entity<IdentityRole>().HasData(
                new IdentityRole { Id = "1", Name = "SUPERADMIN", NormalizedName = "SUPERADMIN", ConcurrencyStamp = "16/05/2023" },
                new IdentityRole { Id = "2", Name = "ADMIN", NormalizedName = "ADMIN", ConcurrencyStamp = "16/05/2023" },
                new IdentityRole { Id = "3", Name = "USER", NormalizedName = "USER", ConcurrencyStamp = "16/05/2023" }
                );
        }
    }
}
