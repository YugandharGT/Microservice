using Microsoft.EntityFrameworkCore;
using OrderMyFood.Services.OrderApi.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderMyFood.Services.OrderApi
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OrderStatus>().HasData(new OrderStatus
            {
              StatusId = 1,
              StatusName = "Ordering"
            },
            new OrderStatus
            {
                StatusId = 2,
                StatusName = "Preparing"
            },
            new OrderStatus
            {
                StatusId = 3,
                StatusName = "Checking"
            },
            new OrderStatus
            {
                StatusId = 4,
                StatusName = "Prepared"
            },
            new OrderStatus
            {
                StatusId = 5,
                StatusName = "Delivered"
            },
            new OrderStatus
            {
                StatusId = 6,
                StatusName = "Cancelled"
            });

        }
    }
}
