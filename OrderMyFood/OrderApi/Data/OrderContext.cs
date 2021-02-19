using Microsoft.EntityFrameworkCore;
using System;
using OrderMyFood.Services.OrderApi.Model;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace OrderMyFood.Services.OrderApi.Data
{
    public class OrderContext : DbContext
    {
        public DbSet<FoodMenuModel> foodMenus { get; set; }
        public DbSet<Customer> customers  { get; set; }
        public DbSet<Order>  Orders { get; set; }
        public DbSet<OrderStatus> Statuses  { get; set; }
        public DbSet<OrderDetails> OrderDetails  { get; set; }
        public OrderContext()
        {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }
        public OrderContext(DbContextOptions<OrderContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            //ef core code first approach with Data source name is fix to 'Instance failure' Error
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Data Source=.\SQLEXPRESS;Initial Catalog=Restaurant;Integrated Security=true;");
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
