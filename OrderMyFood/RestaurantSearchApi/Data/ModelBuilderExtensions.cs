using Microsoft.EntityFrameworkCore;
using OrderMyFood.RestaurantSearchApi.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderMyFood.RestaurantSearchApi.Data
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Menu>().HasData(new Menu
            {
                MenuId = 1,
                Name = "Chicken Biryani",
                Price = 250m,
                RestaurantId = 1,
            },
             new Menu
             {
                 MenuId = 2,
                 Name = "Chicken Korma",
                 Price = 200m,
                 RestaurantId = 2,
             },
             new Menu
             {
                 MenuId = 3,
                 Name = "Shahi Paneer",
                 Price = 250m,
                 RestaurantId = 3,
             },
             new Menu
             {
                 MenuId = 4,
                 Name = "Tandoori Roti",
                 Price = 250m,
                 RestaurantId = 1,
             },
             new Menu
             {
                 MenuId = 5,
                 Name = "Choley Bhaturey",
                 Price = 100m,
                 RestaurantId = 2,
             });

            modelBuilder.Entity<Restaurant>().HasData(new Restaurant
            {
                RestaurantId = 1,
                Name = "Barbequnation",
                Location = "JP Nagar, Bangalore 560006",
                Distance = 20,
                Ratings = 5,
                Budget = 1000m,
                Cuisine = "Indian",

            },
            new Restaurant
            {
                RestaurantId = 2,
                Name = "Paradize",
                Location = "Koramangala",
                Distance = 5,
                Ratings = 4,
                Budget = 600m,
                Cuisine = "Indian",

            },
            new Restaurant
            {
                RestaurantId = 3,
                Name = "Thirteenth floor",
                Location = "Brigade Road",
                Distance = 12,
                Ratings = 2,
                Budget = 800m,
                Cuisine = "Italian",

            },
             new Restaurant
             {
                 RestaurantId = 4,
                 Name = "Mango Tree",
                 Location = "JP Nagar, Bangalore 560009",
                 Distance = 18,
                 Ratings = 4,
                 Budget = 1200m,
                 Cuisine = "Caribbean",

             },
            new Restaurant
            {
                RestaurantId = 5,
                Name = "Brewsky",
                Location = "JP Nagar, Bangalore 564555",
                Distance = 25,
                Ratings = 5,
                Budget = 1500m,
                Cuisine = "German",
            });
        }
    }
}
