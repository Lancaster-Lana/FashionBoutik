using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using FashionBoutik.Entities;

namespace FashionBoutik.Mappings
{
    public class BrandMapping : IEntityTypeConfiguration<Brand>
    {
        public void Configure(EntityTypeBuilder<Brand> builder)
        {
            builder.Property(x => x.Name).IsRequired();

            //builder.HasMany(x => x.Categories)
            //    .WithMany(y => y.Brands).HasForeignKey(p => p.UsersGroupId)
            //     .OnDelete(DeleteBehavior.SetNull);

            builder.ToTable("Brands");
        }
    }
}