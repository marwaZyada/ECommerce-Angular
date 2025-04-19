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
    public class CategoryConfigration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.Property(c => c.Id).IsRequired();
            builder.Property(c=>c.Name).IsRequired().HasMaxLength(50);
            builder.Property(c => c.Description).HasMaxLength(150);
            builder.HasData(new Category()
            {
                Id=1,
                Name= "Electronics",
                Description= "Electronics has many devices"
            });
        }
    }
}
