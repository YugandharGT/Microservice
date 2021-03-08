using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using OrderMyFood.TokenApi.Data;
using OrderMyFood.TokenApi.Models;

namespace TokenApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //var host = 
                CreateWebHostBuilder(args).Run(); //.Run();

            //using (var scope = host.Services.CreateScope())
            //{
            //    var services = scope.ServiceProvider;
            //    try
            //    {
            //        var context = services.GetRequiredService<IdentityAppContext>();
            //        var userManager = services.GetRequiredService<UserManager<ApplicationUser>>();
            //        IdentityDbInit.Initialize(context, userManager);
            //    }
            //    catch (Exception ex)
            //    {
            //        var logger = services.GetRequiredService<ILogger<Program>>();
            //        logger.LogError(ex, "An error occurred whle seeding the AuthorzationServer");
            //        throw;
            //    }
            //}
        }
        //IWebHostBuilder
        public static IWebHost CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .Build();
    }
}
