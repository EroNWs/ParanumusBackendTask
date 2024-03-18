using BookStore.Entities.DbSets;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Entity.Configuration;

public class OrderConfiguration : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder.Property(o => o.TotalPrice).IsRequired().HasColumnType("decimal(18,2)");
        builder.Property(o => o.PaidPrice).IsRequired().HasColumnType("decimal(18,2)");
        builder.Property(o => o.DiscountRatio).IsRequired().HasColumnType("decimal(18,2)");

        builder.HasMany(o => o.OrderDetails)
               .WithOne(od => od.Order)
               .HasForeignKey(od => od.OrderId);

    }
}
