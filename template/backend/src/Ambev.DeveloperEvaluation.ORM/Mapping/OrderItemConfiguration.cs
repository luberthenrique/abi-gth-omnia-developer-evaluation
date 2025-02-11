using Ambev.DeveloperEvaluation.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ambev.DeveloperEvaluation.ORM.Mapping;

public class OrderItemConfiguration : IEntityTypeConfiguration<OrderItem>
{
    public void Configure(EntityTypeBuilder<OrderItem> builder)
    {
        builder.ToTable("OrderItems");

        builder.HasKey(u => u.Id);
        builder.Property(u => u.Id).HasColumnType("uuid").HasDefaultValueSql("gen_random_uuid()");

        builder.Property(u => u.OrderId).IsRequired();
        builder.Property(u => u.ProductId).IsRequired();
        builder.Property(u => u.Quantity).IsRequired().HasPrecision(10, 2);
        builder.Property(u => u.UnitPrice).IsRequired().HasPrecision(10, 2);
        builder.Property(u => u.Discount).IsRequired().HasPrecision(10, 2);
        builder.Property(u => u.TotalPrice).IsRequired().HasPrecision(10, 2);

        builder.HasOne(c => c.Order)
            .WithMany(c => c.OrderItems)
            .HasForeignKey(c => c.OrderId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(c => c.Product)
            .WithMany(c => c.OrderItems)
            .HasForeignKey(c => c.ProductId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
