using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using BomBiEn.Domain.Users.Models;
using BomBiEn.Infrastructure.Commands;
using BomBiEn.AppServices.Core.Configs;
using BomBiEn.AppServices.Lnk.Services;
using Newtonsoft.Json.Converters;

namespace BomBiEn.AppServices.Lnk
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            // Add framework services.
            services.AddIdentity<User, Role>(
                identityOptions =>
                {
                    // Email settings
                    identityOptions.User.RequireUniqueEmail = true;

                    // Password settings
                    identityOptions.Password.RequiredLength = 8;
                    identityOptions.Password.RequireDigit = false;
                    identityOptions.Password.RequireNonAlphanumeric = false;
                    identityOptions.Password.RequireUppercase = false;
                    identityOptions.Password.RequireLowercase = false;

                    // Lockout settings
                    identityOptions.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(30);
                    identityOptions.Lockout.MaxFailedAccessAttempts = 10;

                    // Cookie settings
                    identityOptions.Cookies.ApplicationCookie.ExpireTimeSpan = TimeSpan.FromDays(365);
                    identityOptions.Cookies.ApplicationCookie.LoginPath = "/Account/Login";
                    identityOptions.Cookies.ApplicationCookie.LogoutPath = "/Account/Logout";
                })
                .AddDefaultTokenProviders();

            services.AddMvc()
                .AddJsonOptions(options =>
                {
                    options.SerializerSettings.Converters.Add(new StringEnumConverter());
                });

            //services.Configure<MenuConfig>(Configuration.GetSection("Menu"));

            //services.AddScoped<IMenuFactory, MenuFactory>();
            //services.AddScoped<IMenuItemInitializer, DefaultMenuItemInitializer>();

            services.AddScoped<ICommandBus, AdminPanelCommandBus>();

            services.AddSession();

            //services.AddSwaggerGen(c =>
            //{
            //    c.SwaggerDoc("v1", new Info { Title = "My API", Version = "v1" });
            //});

            services.AddCors(options =>
            {
                options.AddPolicy("MyPolicy",
                    builder => builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials());
            });

            return DIConfig.ConfigureServices(services, Configuration,
               containerBuilder =>
               { },
               (config, assetUrlResolver, queryBus) =>
               {
                   config.AddProfile(new Models.Account.AccountsAutoMapperConfig(queryBus));
               });
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

            app.UseStaticFiles();

            app.UseIdentity();
            app.UseSession();

            app.UseCors("MyPolicy");

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Flashcards}/{action=Index}/{id?}");
            });
        }
    }
}
