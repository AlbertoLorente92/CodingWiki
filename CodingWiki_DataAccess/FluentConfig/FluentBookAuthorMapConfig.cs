using CodingWiki_Model.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingWiki_DataAccess.FluentConfig
{
    public class FluentBookAuthorMapConfig : IEntityTypeConfiguration<Fluent_BookAuthorMap>
    {
        public void Configure(EntityTypeBuilder<Fluent_BookAuthorMap> modelBuilder)
        {
            modelBuilder.ToTable("Fluent_BookAuthorMaps");
            modelBuilder.HasKey(u => new { u.Author_Id, u.Book_Id });

            // 1 to many relation from BookAuthorMap to books
            modelBuilder.HasOne(b => b.Book).WithMany(b => b.BookAuthorMap)
                .HasForeignKey(u => u.Book_Id);
            // 1 to many relation from BookAuthorMap to Authors
            modelBuilder.HasOne(b => b.Author).WithMany(b => b.BookAuthorMap)
                .HasForeignKey(u => u.Author_Id);
        }
    }
}
