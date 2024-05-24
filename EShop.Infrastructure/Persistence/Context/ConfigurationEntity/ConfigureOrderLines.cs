using EShop.Domain.Entities.OrderLines;
using EShop.Domain.Entities.Products;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShop.Infrastructure.Persistence.Context.ConfigurationEntity
{
    public class ConfigureOrderLines : IEntityTypeConfiguration<OrderLine>
    {
        public void Configure(EntityTypeBuilder<OrderLine> builder)
        {
            builder.HasKey(ol => ol.Id);

            builder.Property(ol => ol.Quantity)
                .IsRequired();

            builder.Property(ol => ol.Price)
                .IsRequired();

            builder.HasOne(ol => ol.Product)
                .WithMany(p => p.OrderLines)
                .HasForeignKey(ol => ol.ProductId);

            builder.HasOne(ol => ol.Order)
    .WithMany(p => p.OrderLines)
    .HasForeignKey(ol => ol.OrderId);
        }
    }
}
