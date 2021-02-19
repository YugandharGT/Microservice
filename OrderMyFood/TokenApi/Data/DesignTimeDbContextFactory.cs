using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using OrderMyFood.TokenApi.Data;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace OrderMyFood.TokenApi.Data
{
    /// <summary>
    /// Fix to generate migration for identity
    /// </summary>
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<IdentityAppContext>
    {
        public IdentityAppContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
            var builder = new DbContextOptionsBuilder<IdentityAppContext>();
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            builder.UseSqlServer(connectionString);
            return new IdentityAppContext(builder.Options);
        }
    }
}
