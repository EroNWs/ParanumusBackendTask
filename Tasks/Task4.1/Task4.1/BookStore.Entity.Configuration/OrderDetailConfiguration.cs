using BookStore.Entities.DbSets;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookStore.Entity.Configuration;

public class OrderDetailConfiguration : IEntityTypeConfiguration<OrderDetail>
{
    public void Configure(EntityTypeBuilder<OrderDetail> builder)
    {
        builder.Property(od => od.Count).IsRequired();
        builder.Property(od => od.TotalPriceForBooks).IsRequired().HasColumnType("decimal(18,2)");

        builder.HasOne(od => od.Book)
               .WithMany(b => b.OrderDetails)
               .HasForeignKey(od => od.BookId);

        builder.HasOne(od => od.Order)
               .WithMany(o => o.OrderDetails)
               .HasForeignKey(od => od.OrderId);
    }
}
