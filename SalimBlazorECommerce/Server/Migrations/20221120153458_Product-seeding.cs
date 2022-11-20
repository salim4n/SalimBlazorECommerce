using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SalimBlazorECommerce.Server.Migrations
{
    public partial class Productseeding : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Description", "ImageUrl", "Price", "Title" },
                values: new object[] { 1, "Un jour à New York (On the Town) est un film musical américain réalisé par Stanley Donen et Gene Kelly, sorti en 1949.", "https://upload.wikimedia.org/wikipedia/commons/thumb/c/c8/On_the_Town_%281949_poster%29_crop.jpg/435px-On_the_Town_%281949_poster%29_crop.jpg", 9.99m, "Un jour à New York" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Description", "ImageUrl", "Price", "Title" },
                values: new object[] { 2, "Alien Breed est une série de jeux vidéo créée par la société britannique Team17, apparue en 1991 sur ordinateur Commodore Amiga.", "https://upload.wikimedia.org/wikipedia/fr/3/39/Alien_Breed_Logo.png", 12.99m, "Alien Breed" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Description", "ImageUrl", "Price", "Title" },
                values: new object[] { 3, "Le Râle à joues brunes (Rallus indicus) est une espèce d'oiseaux de la famille des Rallidae. Elle était et est encore souvent considérée comme une sous-espèce du Râle d'eau (R. aquaticus).", "https://upload.wikimedia.org/wikipedia/commons/thumb/e/eb/RallusIndicusNeale.jpg/435px-RallusIndicusNeale.jpg", 6.99m, "Râle à joues brunes" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
