using Ambev.DeveloperEvaluation.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ambev.DeveloperEvaluation.ORM.Mapping;

public class OrderConfiguration : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder.ToTable("Orders");

        builder.HasKey(u => u.Id);
        builder.Property(u => u.Id).HasColumnType("uuid").HasDefaultValueSql("gen_random_uuid()");

        builder.Property(u => u.SalesNumber).IsRequired().HasMaxLength(50);
        builder.Property(u => u.Client).IsRequired().HasMaxLength(150);
        builder.Property(u => u.Branch).IsRequired().HasMaxLength(150);
        builder.Property(u => u.TotalPrice).IsRequired().HasPrecision(10, 2);
        builder.Property(u => u.IsCancelled).IsRequired();
    }
}
