using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MyResume.Domain;
using MyResume.Domain.Repositories;
using MyResume.Domain.Repositories.Abstract;
using MyResume.Domain.Repositories.EntityFramework;
using MyResume.Service;

namespace MyResume
{
    public class Startup
    {
        public IConfiguration Configuration { get;}

        public Startup(IConfiguration configuration) => Configuration = configuration;

        public void ConfigureServices(IServiceCollection services)
        {
            Configuration.Bind("Project", new Config());

            services.AddTransient<ITextFeldsRepository, EFTextFeldsRepository>();
            services.AddTransient<ISkillsRepository, EFSkillsRepository>();
            services.AddTransient<MailHelper>();
            services.AddTransient<DataManager>();

            services.AddDbContext<AppDbContext>(s => s.UseSqlServer(Config.ConnectionString));

            services.AddIdentity<IdentityUser, IdentityRole>(opts =>
            {
                opts.User.RequireUniqueEmail = true;
                opts.Password.RequiredLength = 8;
                opts.Password.RequireNonAlphanumeric = false;
                opts.Password.RequireLowercase = false;
                opts.Password.RequireUppercase = false;
                opts.Password.RequireDigit = false;
            }).AddEntityFrameworkStores<AppDbContext>().AddDefaultTokenProviders();

            services.ConfigureApplicationCookie(options =>
            {
                options.Cookie.Name = "MyResumeAuth";
                options.Cookie.HttpOnly = true;
                options.LoginPath = "/account/login";
                options.AccessDeniedPath = "/account/accessdenied";
                options.SlidingExpiration = true;
            });

            services.AddAuthorization(x =>
            {
                x.AddPolicy("AdminArea", policy => { policy.RequireRole("admin"); });
            });

            services.AddControllersWithViews(x =>
            {
                x.Conventions.Add(new AdminAreaAuthorization("Admin", "AdminArea"));
            }).SetCompatibilityVersion(CompatibilityVersion.Version_3_0).AddSessionStateTempDataProvider();

            services.AddControllersWithViews().SetCompatibilityVersion(CompatibilityVersion.Version_3_0).AddSessionStateTempDataProvider();

            services.AddSingleton<IActionContextAccessor, ActionContextAccessor>();

        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment()) 
                app.UseDeveloperExceptionPage();

            app.UseStaticFiles();

            app.UseRouting(); 

            app.UseCookiePolicy();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute("admin", "{area:exists}/{controller=Home}/{action=Index}/{id?}");
                endpoints.MapControllerRoute("default","{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
