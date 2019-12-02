using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using FashionBoutik.Entities;

namespace FashionBoutik.Mappings
{
    public class CurrencyMapping : IEntityTypeConfiguration<Currency>
    {
        public void Configure(EntityTypeBuilder<Currency> builder)
        {
            builder.Property(x => x.Name).IsRequired(false);
            builder.Property(x => x.CurrencyCode).IsRequired();

            builder.ToTable("Currencies");
        }
    }
}