using Microsoft.EntityFrameworkCore;

namespace SalimBlazorECommerce.Server.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    Id = 1,
                    Title = "Un jour à New York",
                    Description = "Un jour à New York (On the Town) est un film musical américain réalisé par Stanley Donen et Gene Kelly, sorti en 1949.",
                    ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/thumb/c/c8/On_the_Town_%281949_poster%29_crop.jpg/435px-On_the_Town_%281949_poster%29_crop.jpg",
                    Price = 9.99m
                },
            new Product
            {
                Id = 2,
                Title = "Alien Breed",
                Description = "Alien Breed est une série de jeux vidéo créée par la société britannique Team17, apparue en 1991 sur ordinateur Commodore Amiga.",
                ImageUrl = "https://upload.wikimedia.org/wikipedia/fr/3/39/Alien_Breed_Logo.png",
                Price = 12.99m
            },
            new Product
            {
                Id = 3,
                Title = "Râle à joues brunes",
                Description = "Le Râle à joues brunes (Rallus indicus) est une espèce d'oiseaux de la famille des Rallidae. Elle était et est encore souvent considérée comme une sous-espèce du Râle d'eau (R. aquaticus).",
                ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/thumb/e/eb/RallusIndicusNeale.jpg/435px-RallusIndicusNeale.jpg",
                Price = 6.99m
            }
           );
        }

        public DbSet<Product> Products { get; set; }
    }
}
