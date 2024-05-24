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
    public class ConfigurProduct : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {


            builder.HasKey(p => p.Id);

            builder.Property(p => p.Title)
                .HasMaxLength(100);

            builder.HasMany(p => p.OrderLines)
             .WithOne(ol => ol.Product)
             .HasForeignKey(ol => ol.ProductId);
        }
    }
}
