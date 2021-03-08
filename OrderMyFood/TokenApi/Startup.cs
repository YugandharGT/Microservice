using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdentityServer4;
using IdentityServer4.Stores;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.Facebook;
using Microsoft.AspNetCore.Authentication.Google;
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
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using OrderMyFood.TokenApi.Data;
using OrderMyFood.TokenApi.Models;
using OrderMyFood.TokenApi.Services;

namespace TokenApi
{
    public class Startup
    {
        public IHostingEnvironment Environment { get; }
        public IConfiguration Configuration { get; }

        public Startup(IHostingEnvironment environment, IConfiguration configuration)
        {
            Environment = environment;
            Configuration = configuration;
        }


        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddEntityFrameworkSqlServer()
                   .AddDbContext<IdentityAppContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            //configure identity 
            services.AddIdentity<ApplicationUser, IdentityRole>(i => i.User.RequireUniqueEmail = true)
                     .AddEntityFrameworkStores<IdentityAppContext>()
                    .AddDefaultTokenProviders();

            //Framework
            services.AddMvc();


            services.Configure<IISOptions>(options =>
            {
                options.AutomaticAuthentication = false;
                options.AuthenticationDisplayName = "Windows";
            });

            #region Identity Server 4 configuration
            var builder = services.AddIdentityServer(options =>
            {
                options.Events.RaiseErrorEvents = true;
                options.Events.RaiseInformationEvents = true;
                options.Events.RaiseFailureEvents = true;
                options.Events.RaiseSuccessEvents = true;
            })
            .AddAspNetIdentity<ApplicationUser>()
            // in-memory, code config
            .AddInMemoryIdentityResources(Config.GetIdentityResources())
            .AddInMemoryApiResources(Config.GetApiResources())
            .AddInMemoryClients(Config.GetClients(Config.GetUrls(Configuration)));


            if (Environment.IsDevelopment())
            {
                builder.AddDeveloperSigningCredential();
            }
            else
            {
                throw new Exception("need to configure key material");
            }

            //.AddInMemoryCaching()
            //     .AddClientStore<InMemoryClientStore>()
            //     .AddDeveloperSigningCredential()
            //    .AddInMemoryPersistedGrants()
            #endregion


            #region Configure External Identity Providers
            ConfigureExternalIdentityProviders(services);
            #endregion


            // Add application services.
            //services.AddTransient<IEmailSender, EmailSender>();


        }

        private void ConfigureExternalIdentityProviders(IServiceCollection services)
        {
            var autBuilder = services.AddAuthentication();

            // Google
            autBuilder.AddGoogle(GoogleDefaults.AuthenticationScheme, "Google Login", options => SetGoolgeOptions(options));

            // Facebook
            autBuilder.AddFacebook(FacebookDefaults.AuthenticationScheme, "Facebook Login", options => SetFacebookOptions(options));

            //Azure AD
            //autBuilder.AddAzureAd(options => Configuration.Bind("AzureAd", options));
        }

        private void SetGoolgeOptions(GoogleOptions options)
        {
            options.SignInScheme = IdentityServerConstants.ExternalCookieAuthenticationScheme;
            options.ClientId = "";
            options.ClientSecret = "";
        }

        private void SetFacebookOptions(FacebookOptions options)
        {
            options.SignInScheme = IdentityServerConstants.ExternalCookieAuthenticationScheme;
            options.AppId = "1011951322547349";
            options.AppSecret = "ee4e82c725bf7eab6f6a41fac4bf1855";
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseIdentityServer();
            app.UseStaticFiles();
            app.UseMvcWithDefaultRoute();
        }
    }
}
