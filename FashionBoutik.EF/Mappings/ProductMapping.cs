using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using FashionBoutik.Entities;

namespace FashionBoutik.Mappings
{
    public class ProductMapping : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Property(x => x.Name).IsRequired();

            //builder.HasMany(ci => ci.Brand)
            //        .WithMany()
            //        .HasForeignKey(ci => ci.BrandId);

            builder.HasOne(x => x.Category)
                .WithMany().HasForeignKey(p => p.CategoryId)
                .OnDelete(DeleteBehavior.SetNull);

            //One-to-one Product->its price
            builder.HasOne(x => x.PricePerUnit)
                .WithOne(p => p.Product).HasForeignKey<Price>(g => g.ProductId)
                .OnDelete(DeleteBehavior.Cascade);//? delete related 

            builder.ToTable("Products");
        }
    }
}