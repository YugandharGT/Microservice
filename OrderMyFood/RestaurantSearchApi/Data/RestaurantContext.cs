using Microsoft.EntityFrameworkCore;
using OrderMyFood.RestaurantSearchApi.Data.EntityDbMapping;
using OrderMyFood.RestaurantSearchApi.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderMyFood.RestaurantSearchApi.Data
{
    public class RestaurantContext : DbContext
    {
        public DbSet<Menu> Menus { get; set; }

        public DbSet<Restaurant> Restaurants  { get; set; }
        public RestaurantContext()
        {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }
        public RestaurantContext(DbContextOptions<RestaurantContext> options) : base(options)
        {
            
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            //ef core code first approach with Data source name is fix to 'Instance failure' Error
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Data Source=.\SQLEXPRESS;Initial Catalog=Restaurant;User Id=sa;Password=sekar8;");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Seed();
        }
    }
}
