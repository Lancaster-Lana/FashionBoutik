using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using FashionBoutik.Entities;

namespace FashionBoutik.Mappings
{
    public class PriceMapping : IEntityTypeConfiguration<Price>
    {
        public void Configure(EntityTypeBuilder<Price> builder)
        {
            //builder.Property(x => x.Name).IsRequired(false);
            builder.HasKey(p => p.ProductId);

            builder.HasOne(x => x.Currency)
                .WithMany().HasForeignKey(p => p.CurrencyId)
                .OnDelete(DeleteBehavior.SetNull);

            //One-to-many Product->its price
            //builder.HasOne(x => x.Product)
            //    .WithOne(p => p.PricePerUnit).HasForeignKey<Product>(g => g.Id)
            //    .OnDelete(DeleteBehavior.SetNull);//? delete related product 

            builder.ToTable("Price");
        }
    }
}