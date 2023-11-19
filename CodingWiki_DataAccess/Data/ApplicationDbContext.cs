using CodingWiki_Model.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingWiki_DataAccess.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<Genre> Genres { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-T7TMOUV\\SQLEXPRESS;DataBase=CodingWiki;TrustServerCertificate=True;Trusted_Connection=True;");
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>().Property(u => u.Price).HasPrecision(10, 5);

            modelBuilder.Entity<Book>().HasData(
                new Book { IdBook = 1, Title = "Spìder without Duty", ISBN = "123812", Price = 10.99m},
                new Book { IdBook = 2, Title = "Fortune of Time", ISBN = "11223812", Price = 11.99m }
                );

            var bookList = new Book[]
            {
                new Book { IdBook = 3, Title = "Fake Sunday", ISBN = "123812", Price = 20.99m},
                new Book { IdBook = 4, Title = "Cooklie Jar", ISBN = "CC123812", Price = 25.99m},
                new Book { IdBook = 5, Title = "Cloudy Forest", ISBN = "90311223812", Price = 40.99m }
            };

            modelBuilder.Entity<Book>().HasData(bookList);
            base.OnModelCreating(modelBuilder);
        }
    }
}
