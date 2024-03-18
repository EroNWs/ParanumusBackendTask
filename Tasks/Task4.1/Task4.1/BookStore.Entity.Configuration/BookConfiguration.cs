using BookStore.Entities.DbSets;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Entity.Configuration;

public class BookConfiguration : IEntityTypeConfiguration<Book>
{
    public void Configure(EntityTypeBuilder<Book> builder)
    {

        builder.Property(b => b.Title).IsRequired().HasMaxLength(256);
        builder.Property(b => b.Author).IsRequired().HasMaxLength(128);
        builder.Property(b => b.Isbn).IsRequired().HasMaxLength(13);
        builder.Property(b => b.ListPrice).IsRequired().HasColumnType("decimal(18,2)");

        builder.HasMany(b => b.OrderDetails)
               .WithOne(od => od.Book)
               .HasForeignKey(od => od.BookId);
    }
}