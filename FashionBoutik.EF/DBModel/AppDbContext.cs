using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using FashionBoutik.Entities;
using FashionBoutik.Mappings;

namespace FashionBoutik.EF.DBModel
{
    public class IdentityContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    {
        const string DBConnectionStr = "Server=.;Database=FashionBoutikDB;Trusted_Connection=True;MultipleActiveResultSets=true";

        public AppDbContext CreateDbContext(string[] args)
        {
            //Configuration.GetConnectionString("DefaultConnection")

            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
            optionsBuilder.UseSqlServer(DBConnectionStr);

            return new AppDbContext(optionsBuilder.Options);
        }
    }
    public class AppDbContext : IdentityDbContext<User, Role, int>
    {
        public DbSet<UsersGroup> UsersGroup { get; set; }

        public DbSet<UserToUsersGroup> UsersToUsersGroup { get; set; }

        public DbSet<Address> Address { get; set; }

        public DbSet<Currency> Currencies { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Brand> Brands { get; set; }

        public DbSet<ColorPallet> Colors { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<BinaryObject> BinaryObjects { get; set; }

        public DbSet<Retailer> Retailers { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<CartItem> OrderItems { get; set; }

        public DbSet<Price> Price { get; set; }

        public DbSet<Size> Sizes { get; set; }

        //public DbSet<Units> Units { get; set; }

        public DbSet<Payment> Payments { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //Special configuration for supplemantary table UsersToUsersGroup
            modelBuilder.Entity<UsersGroup>().HasKey(x => x.Id);
            modelBuilder.Entity<UserToUsersGroup>().HasKey(x => new { x.UserId, x.UsersGroupId });

            modelBuilder.ApplyConfiguration(new UserMapping());
            modelBuilder.ApplyConfiguration(new UsersGroupMapping());
            modelBuilder.ApplyConfiguration(new RoleMapping());

            modelBuilder.ApplyConfiguration(new BrandMapping());
            //modelBuilder.ApplyConfiguration(new CategoryMapping());
            modelBuilder.ApplyConfiguration(new CurrencyMapping());
            modelBuilder.ApplyConfiguration(new ProductMapping());

            modelBuilder.ApplyConfiguration(new OrderMapping());

        }
    }


}
