using EShop.Domain.Entities.Orders;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EShop.Infrastructure.Persistence.Context.ConfigurationEntity
{
    public class ConfigureOrder : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasKey(o => o.Id);


            builder.Property(o => o.Number)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(o => o.TotalPrice)
                .IsRequired();

            builder.Property(o => o.Date)
                .IsRequired();

            builder.HasMany(o => o.OrderLines)
                .WithOne(ol => ol.Order)
                .HasForeignKey(ol => ol.OrderId);
        }
    }
}
