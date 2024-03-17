using BookStore.Entities.DbSets;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Entity.Configuration;

public class OrderConfiguration : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder.Property(o => o.Count).IsRequired();
        builder.Property(o => o.BookId).IsRequired();
        builder.Property(o => o.CustomerId).IsRequired();

        builder.HasOne(o => o.Book)
               .WithMany(b => b.Orders)
               .HasForeignKey(o => o.BookId);

        builder.HasOne(o => o.Customer)
               .WithMany(c => c.Orders)
               .HasForeignKey(o => o.CustomerId);
    }
}
