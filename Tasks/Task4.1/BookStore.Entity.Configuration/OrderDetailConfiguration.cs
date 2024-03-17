using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using BookStore.Entities.DbSets;

namespace BookStore.Entity.Configuration;

public class OrderDetailConfiguration : IEntityTypeConfiguration<OrderDetail>
{
    public void Configure(EntityTypeBuilder<OrderDetail> builder)
    {
        builder.Property(od => od.Count).IsRequired();
        builder.Property(od => od.PaidPrice).IsRequired().HasColumnType("decimal(18,2)");

        builder.HasOne(od => od.Book)
               .WithMany()
               .HasForeignKey(od => od.BookId)
               .IsRequired();
    }
}
