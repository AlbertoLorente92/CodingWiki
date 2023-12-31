﻿using CodingWiki_DataAccess.FluentConfig;
using CodingWiki_Model.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
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
        public DbSet<Category> Categories { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Publisher> Publishers { get; set; }
        public DbSet<Subcategory> Subcategories { get; set; }
        public DbSet<BookDetail> BookDetails { get; set; }
        public DbSet<BookAuthorMap> BookAuthorMaps { get; set; }
        public DbSet<Fluent_BookDetail> BookDetails_fluent { get; set; }
        public DbSet<Fluent_Book> Books_fluent { get; set; }
        public DbSet<Fluent_Author> Authors_fluent { get; set; }
        public DbSet<Fluent_Publisher> Publishers_fluent { get; set; }
        public DbSet<Fluent_BookAuthorMap> BookAuthorMap_fluent { get; set; }

        public DbSet<MainBookDetails> MainBookDetails { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer("Server=DESKTOP-T7TMOUV\\SQLEXPRESS;DataBase=CodingWiki;TrustServerCertificate=True;Trusted_Connection=True;")
            //    .LogTo(Console.WriteLine, new[] {DbLoggerCategory.Database.Command.Name}, LogLevel.Information);

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new FluentAuthorConfig());
            modelBuilder.ApplyConfiguration(new FluentBookAuthorMapConfig());
            modelBuilder.ApplyConfiguration(new FluentBookConfig());
            modelBuilder.ApplyConfiguration(new FluentBookDetailConfig());
            modelBuilder.ApplyConfiguration(new FluentPublisherConfig());

            modelBuilder.Entity<MainBookDetails>().HasNoKey().ToView("GetMainBookDetails");
            

            modelBuilder.Entity<Book>().Property(u => u.Price).HasPrecision(10, 5);

            modelBuilder.Entity<BookAuthorMap>().HasKey(u => new { u.Author_Id, u.Book_Id});

            modelBuilder.Entity<Publisher>().HasData(
                new Publisher { Publisher_Id = 1, Name = "tryme1" },
                new Publisher { Publisher_Id = 2, Name = "tryme2" },
                new Publisher { Publisher_Id = 3, Name = "tryme3" }
                );

            modelBuilder.Entity<Book>().HasData(
                new Book { IdBook = 1, Title = "Spìder without Duty", ISBN = "123812", Price = 10.99m, Publisher_id = 1},
                new Book { IdBook = 2, Title = "Fortune of Time", ISBN = "11223812", Price = 11.99m, Publisher_id = 1 }
                );

            var bookList = new Book[]
            {
                new Book { IdBook = 3, Title = "Fake Sunday", ISBN = "123812", Price = 20.99m, Publisher_id = 2},
                new Book { IdBook = 4, Title = "Cooklie Jar", ISBN = "CC123812", Price = 25.99m, Publisher_id = 2},
                new Book { IdBook = 5, Title = "Cloudy Forest", ISBN = "90311223812", Price = 40.99m, Publisher_id = 3 }
            };

            

            modelBuilder.Entity<Book>().HasData(bookList);
            base.OnModelCreating(modelBuilder);
        }
    }
}
