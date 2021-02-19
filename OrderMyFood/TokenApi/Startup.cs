using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using OrderMyFood.TokenApi.Data;
using OrderMyFood.TokenApi.Models;
using OrderMyFood.TokenApi.Services;

namespace TokenApi
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

            services.Configure<CookiePolicyOptions>(opt =>
            {
                opt.CheckConsentNeeded = context => true;
                opt.MinimumSameSitePolicy = Microsoft.AspNetCore.Http.SameSiteMode.None;
            });
            //Framework
            services.AddMvc();

            //External Authorization
            //services.AddAuthentication().AddFacebook(facebookOptions =>
            //{
            //    facebookOptions.AppId = Configuration["Authentication:Facebook:AppId"];
            //    facebookOptions.AppSecret = Configuration["Authentication:Facebook:AppSecret"];
            //});

            //configure identity 
            services.AddIdentity<ApplicationUser, IdentityRole>(i => i.User.RequireUniqueEmail = true)
              .AddEntityFrameworkStores<IdentityAppContext>();
            //.AddDefaultTokenProviders();
            services.AddEntityFrameworkSqlServer()
                    .AddDbContext<IdentityAppContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
         

            //configure identity server with in-memory stores, keys, clients and scopes
            //services.AddIdentityServer()
            //    .AddDeveloperSigningCredential()
            //    .AddInMemoryPersistedGrants()
            //    .AddInMemoryIdentityResources(Config.GetIdentityResources())
            //    .AddInMemoryApiResources(Config.GetApiResources())
            //    .AddInMemoryClients(Config.GetClients(Config.GetUrls(Configuration)));
                //.AddAspNetIdentity<ApplicationUser>();



            // Add application services.
            //services.AddTransient<IEmailSender, EmailSender>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                //app.UseBrowserLink();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();
            app.UseAuthentication();
            
            
            // app.UseIdentity(); // not needed, since UseIdentityServer adds the authentication middleware
           // app.UseIdentityServer();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Account}/{action=Login}/{id?}");
                
            });
        }
    }
}
