using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using FashionBoutik.Entities;

namespace FashionBoutik.Mappings
{
    public class UsersGroupMapping : IEntityTypeConfiguration<UsersGroup>
    {
        public void Configure(EntityTypeBuilder<UsersGroup> builder)
        {
            builder.Property(x => x.Name).IsRequired();

            builder.HasMany(x => x.Users)
                .WithOne(y => y.UsersGroup).HasForeignKey(p => p.UsersGroupId)
                .OnDelete(DeleteBehavior.Cascade);//delete UsersGroup -> and related users

            builder.ToTable("UsersGroups");
        }
    }
}