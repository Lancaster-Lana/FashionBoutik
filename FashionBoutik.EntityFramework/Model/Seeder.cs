using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using FashionBoutik.Data;
using FashionBoutik.Entities;

namespace DataFashionBoutik.Data
{
    public class Seeder
    {
        public static async Task SeedAsync(AppDbContext dbContext, ILoggerFactory loggerFactory, int? retry = 0)
        {
            int retryForAvailability = retry.Value;
            try
            {
                // TODO: Only run this if using a real database
                // context.Database.Migrate();

                //if (!dbContext.Roles.Any())
                //{
                //    dbContext.Roles.AddRange(
                //        GetPreconfiguredRoles());

                //    await dbContext.SaveChangesAsync();
                //}

                if (!dbContext.Currencies.Any())
                {
                    dbContext.Currencies.AddRange(
                        GetPreconfiguredCurrencies());

                    await dbContext.SaveChangesAsync();
                }

                if (!dbContext.Brands.Any())
                {
                    dbContext.Brands.AddRange(
                        GetPreconfiguredCatalogBrands());

                    await dbContext.SaveChangesAsync();
                }

                if (!dbContext.Categories.Any())
                {
                    dbContext.Categories.AddRange(
                        GetPreconfiguredProductsCategories());

                    await dbContext.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                if (retryForAvailability < 10)
                {
                    retryForAvailability++;

                    var logger = loggerFactory.CreateLogger<Seeder>();
                    logger.LogError(ex.Message);

                    await SeedAsync(dbContext, loggerFactory, retryForAvailability);
                }
            }
        }

        static IEnumerable<Currency> GetPreconfiguredCurrencies()
        {
            return new List<Currency>()
            {
                new Currency() { Name = "Dollar", CurrencyCode="USD", Symbol = "$", CurrencyBase=1, Decimals =2,  CreatedDate =DateTime.Now},
                new Currency() { Name = "EURO", CurrencyCode="EUR", Symbol = "€", CurrencyBase=1,  Decimals =2,  CreatedDate =DateTime.Now },
                new Currency() { Name = "Japanese yen", CurrencyCode="JPY", Symbol = "¥", CurrencyBase=1,  Decimals =0,  CreatedDate =DateTime.Now},
            };
        }

        static IEnumerable<Category> GetPreconfiguredProductsCategories()
        {
            return new List<Category>()
            {
                new Category() { Name = "Shirts"},
                new Category() { Name = "Jackets" },
                new Category() { Name = "Suites" },
                new Category() { Name = "Hats" },
                new Category() { Name = "Skates" },
                new Category() { Name = "Shoes" },
                new Category() { Name = "Gloves" },
            };
        }

        static IEnumerable<Brand> GetPreconfiguredCatalogBrands()
        {
            return new List<Brand>()
            {
                new Brand() { Name = "Gucci"},
                new Brand() { Name = "Armani" },
                new Brand() { Name = "Anre" },
            };
        }
    }
}
