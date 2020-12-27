using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OrderMyFood.Web.WebRazor;
using OrderMyFood.Web.WebRazor.Business;
using OrderMyFood.Web.WebRazor.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebRazor
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
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddMvc()
                //.AddRazorPagesOptions( pg =>
                //{
                //    pg.Conventions.AddPageRoute("/Restaurant", "");
                //})
                .AddRazorOptions(options =>
                {
                    options.PageViewLocationFormats.Add("/Pages/Shared/{0}.cshtml");
                })
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            //For Ajax Requests
            services.AddAntiforgery(o => o.HeaderName = "XSRF-TOKEN");
            //services.AddRazorPages().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.Configure<AppSettings>(Configuration);
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddTransient<IHttpClient, CustomHttpClient>();
            services.AddTransient<IRestaurantService, RestaurantService>();
            services.AddTransient<IReviewService, ReviewService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
            }

            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseMvc();
            
        }
    }
}
