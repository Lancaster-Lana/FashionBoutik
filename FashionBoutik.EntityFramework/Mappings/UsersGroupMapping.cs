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
            builder.HasMany(x => x.Users);
            //.OnDelete(DeleteBehavior.Cascade);//delete UsersGroup -> and related users

            builder.ToTable("UsersGroups");
        }
    }
}