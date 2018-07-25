using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Http.Features;
using Swashbuckle.AspNetCore.Swagger;
using AutoMapper;
using FashionBoutik.Data;
using FashionBoutik.Entities;
using FashionBoutik.DomainServices;
using FashionBoutik.EntityFramework.Repository;
using FashionBoutik.Core.Mappers;
using FashionBoutik.Core;
using FashionBoutik.Core.Messaging;

namespace FashionBoutik.Web
{
    public class Startup
    {
        public IConfigurationRoot Configuration { get; }

        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();

            //register auto mapper for models<->entities 
            MappingConfig.InitializeAutoMapper().CreateMapper();
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAutoMapper();

            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DBConnection")));

            services.AddIdentity<User, Role>(options =>
            {
                //Configure password requirements
                options.Password.RequireDigit = false;
                //options.Password.RequireNonAlphanumeric = false;
                //options.Password.RequireLowercase = false;
                //options.Password.RequireUppercase = false;
                options.Password.RequiredLength = 5;
            })
            .AddEntityFrameworkStores<AppDbContext>()
            .AddDefaultTokenProviders();

            services.Configure<FormOptions>(options =>
            {
                options.MultipartBodyLengthLimit = 100000000; //increase request symbols count
            });

            //INIT AUTHENTICATION with social networks
            services.AddAuthentication()
                .AddTwitter(twOptions =>
                {
                    twOptions.ConsumerKey = Configuration["Authentication:Twitter:ConsumerKey"];
                    twOptions.ConsumerSecret = Configuration["Authentication:Twitter:ConsumerSecret"];
                })
                .AddFacebook(facebookOptions =>
                {
                    facebookOptions.AppId = Configuration["Authentication:Facebook:AppId"];
                    facebookOptions.AppSecret = Configuration["Authentication:Facebook:AppSecret"];
                })
                .AddGoogle(googleOptions =>
                {
                    googleOptions.ClientId = Configuration["Authentication:Google:ClientId"];
                    googleOptions.ClientSecret = Configuration["Authentication:Google:ClientSecret"];
                });

            //services.Configure<FacebookOptions>(Configuration.GetSection("Facebook"));
            //services.Configure<GoogleOptions>(Configuration.GetSection("Google"));

            //services.Configure<ConfirmEmailDataProtectionTokenProviderOptions>(options =>
            //{
            //    options.TokenLifespan = TimeSpan.FromDays(180);
            //});

            //services.AddAuthorization(options =>
            //{
            //    options.AddPolicy("EmployeesOnly", policy => policy.RequireClaim("EmployeeId"));
            //});

            //REPOS and services   
            services.AddScoped(typeof(IRepository<,>), typeof(Repository<,>));

            services.AddTransient<IUsersGroupRepository, UsersGroupRepository>();
            services.AddTransient<IUsersGroupManager, UsersGroupManager>();

            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<ICategoryManager, CategoryManager>();

            services.AddScoped<IBrandRepository, BrandRepository>();
            services.AddScoped<IBrandManager, BrandManager>();

            services.AddScoped<ICurrencyRepository, CurrencyRepository>();
            services.AddScoped<ICurrencyManager, CurrencyManager>();

            services.AddScoped<IColorRepository, ColorRepository>();
            services.AddScoped<IColorManager, ColorManager>();

            services.AddScoped<ISizeRepository, SizeRepository>();
            services.AddScoped<ISizeManager, SizeManager>();

            services.AddScoped<IImageRepository, ImageRepository>();

            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IProductManager, ProductManager>();
            //services.AddScoped<IProductManager, CachedProductManager>();

            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IOrderManager, OrderManager>();

            services.AddScoped<IRetailerRepository, RetailerRepository>();
            services.AddScoped<IRetailerManager, RetailerManager>();

            // Email services 
            //services.Configure<EmailSettings>(Configuration.GetSection("EmailSettings"));
            services.AddScoped<IEmailSender, EmailService>();
            services.AddScoped<ISmsSender, EmailService>(); //SmsSender

            //Configuration Redis cash
            //services.AddDistributedRedisCache(options =>
            //{
            //    options.Configuration = Configuration.GetConnectionString("Redis");
            //    options.InstanceName = "master";
            //});

            services.AddDistributedMemoryCache();

            //INIT Session (also can be accessed by DI with IHttpContextAccessor in non-controller class)
            services.AddSession(options =>
            {
                //options.Cookie.HttpOnly = true;
                //options.Cookie.Name = ".Fiver.Session";
                options.Cookie.SecurePolicy = CookieSecurePolicy.Always;
                options.IdleTimeout = TimeSpan.FromMinutes(10);
            });

            //To get session from HttpContext
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            // If you want to tweak Identity cookies, they're no longer part of IdentityOptions.
            //services.ConfigureApplicationCookie(options =>
            //{
            //options.LoginPath = "/Account/Login";
            //options.Cookie.HttpOnly = true;
            //options.Cookie.Expiration = TimeSpan.FromHours(1);
            //options.SlidingExpiration = true;
            //});

            services.AddMvc(options =>
            {
                //options.OutputFormatters.Add(new PdfFormatter());
            });

            services.AddSwaggerGen(options =>
            {
                options.DescribeAllEnumsAsStrings();
                options.SwaggerDoc("v1", new Info
                {
                    Title = "FashionBoutik",
                    Version = "v1",
                    Description = "The Web app for online dhopping",
                    TermsOfService = "Terms Of Service"
                });
                //options.AddSecurityDefinition("oauth2", new OAuth2Scheme
                //{
                //    Type = "oauth2",
                //    Flow = "implicit",
                //    AuthorizationUrl = $"{Configuration.GetValue<string>("IdentityUrlExternal")}/connect/authorize",
                //    TokenUrl = $"{Configuration.GetValue<string>("IdentityUrlExternal")}/connect/token",
                //    Scopes = new Dictionary<string, string>()
                //    {
                //        { "mobileshoppingagg", "Shopping Aggregator for Mobile Clients" }
                //    }
                //});
                //options.OperationFilter<AuthorizeCheckOperationFilter>();
            });
            
            //services.AddCors(options =>
            //{
            //    options.AddPolicy("CorsPolicy",
            //        builder => builder.AllowAnyOrigin()
            //        .AllowAnyMethod()
            //        .AllowAnyHeader()
            //        .AllowCredentials());
            //});
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles(new StaticFileOptions()
            {
                OnPrepareResponse = context =>
                {
                    string path = context.File.PhysicalPath;
                    if (path.EndsWith(".css") || path.EndsWith(".js")
                        || path.EndsWith(".gif") || path.EndsWith(".jpg")
                        || path.EndsWith(".png") || path.EndsWith(".svg")
                        || path.EndsWith(".ico"))
                    {
                        context.Context.Response.Headers["Cache-Control"] = "private, max-age=43200";

                        context.Context.Response.Headers["Expires"] = DateTime.UtcNow.AddHours(12).ToString("R");
                    }
                }
            });

            //app.UseEmbeddedFiles();

            app.UseAuthentication(); //app.UseIdentity();

            // IMPORTANT: This session call MUST go before UseMvc()
            app.UseSession();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "areaRoute",
                    template: "{area:exists}/{controller=User}/{action=Index}");

                routes.MapRoute(
                    name: "Default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });

            app.UseSwagger().UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "FashionBoutik V1");
            });
        }
    }
}
