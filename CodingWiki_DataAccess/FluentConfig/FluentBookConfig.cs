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
    public class FluentBookConfig : IEntityTypeConfiguration<Fluent_Book>
    {
        public void Configure(EntityTypeBuilder<Fluent_Book> modelBuilder)
        {
            modelBuilder.ToTable("Fluent_Books");
            modelBuilder.Property(u => u.ISBN).HasMaxLength(20);
            modelBuilder.Property(u => u.ISBN).IsRequired();
            modelBuilder.Ignore(u => u.PriceRange);
            modelBuilder.HasKey(u => u.IdBook);

            // 1 to many relation from book to publishers
            modelBuilder.HasOne(b => b.Publisher).WithMany(b => b.Books)
                .HasForeignKey(u => u.Publisher_id);
        }
    }
}
