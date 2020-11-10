using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using RestaurantSearchApi.Business.Concrete;
using RestaurantSearchApi.Business.Interfaces;
using RestaurantSearchApi.Data;

namespace RestaurantSearchApi
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddDbContext<RestaurantContext>(opt => opt.UseSqlServer(Configuration.GetConnectionString("RestaurantDB"), options => options.EnableRetryOnFailure()));
            ConfigureObjectsDI(services);
        }

        public void ConfigureObjectsDI(IServiceCollection services)
        {
            //services.AddScoped<IRestaurant, RestaurantRepository>();
            // DP Version

            //services.AddScoped<IRestaurant, RestaurantName>();
            //services.AddScoped<IRestaurant, RestaurantLocation>();
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
                app.UseHsts();
            }

            //if (env.IsProduction() || env.IsStaging() || env.IsEnvironment("Staging_2"))
            //{
            //    app.UseExceptionHandler("/Error");
            //}
           
            app.UseMvc();
            
        }
    }
}
