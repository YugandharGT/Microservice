using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using OrderMyFood.RestaurantSearchApi.Business.Concrete;
using OrderMyFood.RestaurantSearchApi.Business.Interfaces;
using OrderMyFood.RestaurantSearchApi.Data;
using OrderMyFood.RestaurantSearchApi.Infrastructure.Filters;

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
            
            services.AddMvcCore(
                options => options.Filters.Add(typeof(HttpGlobalExceptionFilter))
                )
                 .AddJsonFormatters(
                  Options =>
                  {
                      Options.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                      Options.ContractResolver = new CamelCasePropertyNamesContractResolver();
                  }
               )
                 .AddApiExplorer();

            services.AddDbContext<RestaurantContext>(opt => opt.UseSqlServer(Configuration.GetConnectionString("RestaurantDB"), options => options.EnableRetryOnFailure()));

            services.AddSwaggerGen(options =>
            {
                options.DescribeAllEnumsAsStrings();
                options.SwaggerDoc("v1", new Swashbuckle.AspNetCore.Swagger.Info()
                {
                    Title = "OrderMyFood - RestaurantSearch HTTP API",
                    Version = "v1",
                    Description = "The Catalog Microservice HTTP API. This is a Data-Driven/CRUD microservice sample",
                    TermsOfService = "Terms Of Service"
                });
            });
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials());
            });

            //ConfigureAuthService(services);

            ConfigureObjectsDI(services);
        }

        private void ConfigureAuthService(IServiceCollection services)
        {
            // prevent from mapping "sub" claim to nameidentifier.
            JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear();

            var identityUrl = Configuration.GetValue<string>("IdentityUrl");

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

            }).AddJwtBearer(options =>
            {
                options.Authority = identityUrl;
                options.RequireHttpsMetadata = false;
                options.Audience = "restaurant";

            });
        }

        public void ConfigureObjectsDI(IServiceCollection services)
        {
            
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

            app.UseSwagger()
              .UseSwaggerUI(c =>
              {
                  c.SwaggerEndpoint($"/swagger/v1/swagger.json", "RestaurantApi V1");
                  c.ConfigureOAuth2("Restaurantswaggerui", "", "", "Restaurant Swagger UI");
              });

            app.UseCors("CorsPolicy");
            app.UseMvc();
            
        }
    }
}
