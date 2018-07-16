using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using FashionBoutik.Entities;

namespace FashionBoutik.Mappings
{
    public class OrderMapping : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.Property(x => x.Name).IsRequired();

            //builder.HasOne(x => x.ShippingAddress)
                //.WithOne(y => y.Order).HasForeignKey(p => p.UsersGroupId)
            //    .OnDelete(DeleteBehavior.Cascade);//delete UsersGroup -> and related users

            builder.ToTable("Orders");
        }
    }
}