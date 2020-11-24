using OrderMyFood.RestaurantSearchApi.Data;
using OrderMyFood.RestaurantSearchApi.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderMyFood.RestaurantSearchApi.Business.Interfaces
{
    public interface IRestaurant
    {
        IQueryable<Restaurant> Search(string filter);

    }
}
