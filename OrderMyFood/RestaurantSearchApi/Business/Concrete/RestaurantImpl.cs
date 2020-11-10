using Microsoft.EntityFrameworkCore.ValueGeneration.Internal;
using RestaurantSearchApi.Business.Interfaces;
using RestaurantSearchApi.Data;
using RestaurantSearchApi.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantSearchApi.Business.Concrete
{
    public enum SearchTypes
    {
        Name,

        Location,

        Distance, 

        Cuisine,

        Budget, 

        Ratings, 
    }

    /// <summary>
    /// Implement Strategy pattern
    /// </summary>
    public class RestaurantImpl 
    {
        IRestaurant selectedStrategy;
        Dictionary<SearchTypes, IRestaurant> strategies = null;
        //var restaurantName = new Lazy<IRestaurant>(() => new RestaurantName());

       
        public RestaurantImpl()
        {
            strategies = new Dictionary<SearchTypes, IRestaurant>() {
            { SearchTypes.Name, new RestaurantName() },
            { SearchTypes.Location, new RestaurantLocation() },
            { SearchTypes.Distance, new RestaurantDistance() },
            { SearchTypes.Cuisine, new RestaurantCuisine() },
            { SearchTypes.Ratings, new RestaurantRating() },
            { SearchTypes.Budget, new RestaurantBudget() }
            };
        }

        // version 1
        //public RestaurantImpl(IRestaurant restaurant) =>  _restaurant = restaurant;       
        //public void SetSearchType(IRestaurant restaurant) => _restaurant = restaurant;

        //verison2
        public SearchTypes UserChoice { get; set; }
        public IEnumerable<Restaurant> InvokeRestaurantSearch(string filter)
        {
            selectedStrategy = strategies[UserChoice]; //e.g: Enum Name
            return selectedStrategy.Search(filter);
        }
    }
    internal class RestaurantName : IRestaurant
    {
        public IEnumerable<Restaurant> Search(string filter)
        {
            using(var dbContext = new RestaurantContext())
            {
                var result = dbContext.Restaurants.Where(x => x.Name == filter).ToList();
                return result;
            }
       }
    }

    internal class RestaurantLocation : IRestaurant
    {
        public IEnumerable<Restaurant> Search(string filter)
        {
            using (var dbContext = new RestaurantContext())
            {
                var result = dbContext.Restaurants.Where(x => x.Location.Contains(filter)).ToList();
                return result;
            }
        }
    }

    internal class RestaurantDistance : IRestaurant
    {
        public IEnumerable<Restaurant> Search(string filter)
        {
            throw new NotImplementedException();
        }
    }

    internal class RestaurantCuisine : IRestaurant
    {
        public IEnumerable<Restaurant> Search(string filter)
        {
            throw new NotImplementedException();
        }
    }

    internal class RestaurantRating : IRestaurant
    {
        public IEnumerable<Restaurant> Search(string filter)
        {
            throw new NotImplementedException();
        }
    }

    internal class RestaurantBudget : IRestaurant
    {
        public IEnumerable<Restaurant> Search(string filter)
        {
            throw new NotImplementedException();
        }
    }
}
