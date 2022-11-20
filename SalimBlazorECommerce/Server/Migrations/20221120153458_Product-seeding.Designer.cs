﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SalimBlazorECommerce.Server.Data;

#nullable disable

namespace SalimBlazorECommerce.Server.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20221120153458_Product-seeding")]
    partial class Productseeding
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("SalimBlazorECommerce.Shared.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Un jour à New York (On the Town) est un film musical américain réalisé par Stanley Donen et Gene Kelly, sorti en 1949.",
                            ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/thumb/c/c8/On_the_Town_%281949_poster%29_crop.jpg/435px-On_the_Town_%281949_poster%29_crop.jpg",
                            Price = 9.99m,
                            Title = "Un jour à New York"
                        },
                        new
                        {
                            Id = 2,
                            Description = "Alien Breed est une série de jeux vidéo créée par la société britannique Team17, apparue en 1991 sur ordinateur Commodore Amiga.",
                            ImageUrl = "https://upload.wikimedia.org/wikipedia/fr/3/39/Alien_Breed_Logo.png",
                            Price = 12.99m,
                            Title = "Alien Breed"
                        },
                        new
                        {
                            Id = 3,
                            Description = "Le Râle à joues brunes (Rallus indicus) est une espèce d'oiseaux de la famille des Rallidae. Elle était et est encore souvent considérée comme une sous-espèce du Râle d'eau (R. aquaticus).",
                            ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/thumb/e/eb/RallusIndicusNeale.jpg/435px-RallusIndicusNeale.jpg",
                            Price = 6.99m,
                            Title = "Râle à joues brunes"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}