﻿// <auto-generated />
using CodingWiki_DataAccess.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CodingWiki_DataAccess.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20231120182248_updateGenreTableAndColumnName")]
    partial class updateGenreTableAndColumnName
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CodingWiki_Model.Models.Book", b =>
                {
                    b.Property<int>("IdBook")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdBook"));

                    b.Property<string>("ISBN")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasPrecision(10, 5)
                        .HasColumnType("decimal(10,5)");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdBook");

                    b.ToTable("Books");

                    b.HasData(
                        new
                        {
                            IdBook = 1,
                            ISBN = "123812",
                            Price = 10.99m,
                            Title = "Spìder without Duty"
                        },
                        new
                        {
                            IdBook = 2,
                            ISBN = "11223812",
                            Price = 11.99m,
                            Title = "Fortune of Time"
                        },
                        new
                        {
                            IdBook = 3,
                            ISBN = "123812",
                            Price = 20.99m,
                            Title = "Fake Sunday"
                        },
                        new
                        {
                            IdBook = 4,
                            ISBN = "CC123812",
                            Price = 25.99m,
                            Title = "Cooklie Jar"
                        },
                        new
                        {
                            IdBook = 5,
                            ISBN = "90311223812",
                            Price = 40.99m,
                            Title = "Cloudy Forest"
                        });
                });

            modelBuilder.Entity("CodingWiki_Model.Models.Genre", b =>
                {
                    b.Property<int>("GenreId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("GenreId"));

                    b.Property<int>("DisplayOrder")
                        .HasColumnType("int");

                    b.Property<string>("GenreName")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Name");

                    b.HasKey("GenreId");

                    b.ToTable("tb_genres");
                });
#pragma warning restore 612, 618
        }
    }
}
