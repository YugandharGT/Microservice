using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RestaurantSearchApi.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantSearchApi.Data.EntityDbMapping
{
    public class RestaurantMap
    {
        public RestaurantMap(EntityTypeBuilder<Restaurant> entityTypeBuilder)
        {
            entityTypeBuilder.HasKey(t => t.Name);
            entityTypeBuilder.Property(t => t.Location);
            entityTypeBuilder.Property(t => t.Distance);
            entityTypeBuilder.Property(t => t.Cuisine);
            entityTypeBuilder.Property(t => t.Ratings);
            entityTypeBuilder.Property(t => t.Budget);
        }
    }
}
