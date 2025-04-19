using EComerce.Core.Entities.Product;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EComerce.Infrastructure.Data.Config
{
    public class ProductConfigration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Property(p => p.Id).IsRequired();
            builder.Property(p=>p.Name).IsRequired().HasMaxLength(50);
            builder.Property(p => p.Description).IsRequired().HasMaxLength(150);
            builder.Property(p => p.Price).HasColumnType("decimal(18,2)");
            builder.HasData(new Product()
            {
                Id=1,
                Name = "TV",
                Description = "TV has many programs",
                Price = 2550,
                CategoryId = 1
            });
        }
    }
}
