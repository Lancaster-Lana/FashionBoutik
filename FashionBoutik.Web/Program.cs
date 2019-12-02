using System;
using FashionBoutik.EF.DBModel;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Debug;

namespace FashionBoutik.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = BuildWebHost(args);

            //Seed DB (NOTE: if DB is Microsoft.EntityFrameworkCore.DbContext, not System.Data.Entity.DbContext) 
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var loggerFactory = services.GetRequiredService<ILoggerFactory>();
                var logger = services.GetRequiredService<ILogger<Program>>();
                //var log = services.CreateLogger<Seeder>();
                try
                {
                    var context = services.GetRequiredService<AppDbContext>();

                    Seeder.SeedAsync(context, loggerFactory).Wait();
                }
                catch (Exception ex)
                {
                    logger.LogError(ex, "An error occurred while seeding the database.");
                }
            }
            host.Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .ConfigureLogging(logging => logging
                               .AddFilter("System", LogLevel.Debug).AddFilter<DebugLoggerProvider>("Microsoft", LogLevel.Trace)
                               .SetMinimumLevel(LogLevel.Warning))
                .Build();
    }
}
