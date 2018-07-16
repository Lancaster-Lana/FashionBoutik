using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using FashionBoutik.Entities;
using FashionBoutik.Mappings;

namespace FashionBoutik.Data
{
    public class AppDbContext : IdentityDbContext<User, Role, int>
    {
        public DbSet<UsersGroup> UsersGroup { get; set; }

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

    public class IdentityContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    {
        public AppDbContext CreateDbContext(string[] args)
        {
            var identityConnectionStr = "Server=.;Database=FashionBoutikDB;Trusted_Connection=True;MultipleActiveResultSets=true";
            //Configuration.GetConnectionString("DefaultConnection")

            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
            optionsBuilder.UseSqlServer(identityConnectionStr);

            return new AppDbContext(optionsBuilder.Options);
        }
    }
}
