using AutoMapper;
using DreamsBytes.ECommerce.Business.Containers.MicrosoftIoC;
using DreamsBytes.ECommerce.DataAccess.Concrete.EntityFrameworkCore.Context;
using DreamsBytes.ECommerce.Entities.Concrete;
using DreamsBytes.ECommerce.WebUI.CustomIdentityExtension;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using System.IO;

namespace DreamsBytes.ECommerce.WebUI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddDependencies();
            services.AddDbContext<DatabaseContext>();            
            services.AddCustomIdentity();
            services.AddAutoMapper(typeof(Startup));
            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, UserManager<AppUser> userManager, RoleManager<AppRole> roleManager)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            IdentityInitializer.SeedData(userManager, roleManager).Wait();

            app.UseStaticFiles();

            app.UseEndpoints(endpoints =>
            {              
                endpoints.MapControllerRoute(
                   name: "areas",
                   pattern: "{area}/{controller=Home}/{action=Index}/{id?}"
                   );

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}"
                    );
            });
        }
    }
}
