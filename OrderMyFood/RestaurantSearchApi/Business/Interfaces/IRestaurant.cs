using RestaurantSearchApi.Data;
using RestaurantSearchApi.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantSearchApi.Business.Interfaces
{
    public interface IRestaurant
    {
        IEnumerable<Restaurant> Search(string filter);
    }
}
