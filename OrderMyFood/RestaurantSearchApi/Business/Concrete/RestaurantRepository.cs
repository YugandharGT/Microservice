using RestaurantSearchApi.Business.Interfaces;
using RestaurantSearchApi.Data;
using RestaurantSearchApi.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantSearchApi.Business.Concrete
{
    public class RestaurantRepository : IRestaurant
    {
        readonly RestaurantContext db;
        public RestaurantRepository(RestaurantContext context)
        {
            this.db = context;
        }

        public IEnumerable<Restaurant> Search(string filter)
        {
            if (db != null)
            {
                var result = db.Set<Restaurant>().Where(x => x.Name == filter).ToList();
                return result;

            }
            return null;
        }
    }
}
