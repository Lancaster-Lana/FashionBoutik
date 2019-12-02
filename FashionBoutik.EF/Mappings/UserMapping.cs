namespace FashionBoutik.Mappings
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using FashionBoutik.Entities;

    public class UserMapping : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(x => x.UserName).IsRequired();
            builder.Property(x => x.PasswordHash);
            builder.Property(x => x.Email);
            builder.HasMany(x => x.UsersGroups);//.WithOne(v=>v.Users);
            builder.ToTable("Users");
        }
    }
}