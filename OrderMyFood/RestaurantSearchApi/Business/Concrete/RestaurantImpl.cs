using Microsoft.EntityFrameworkCore.ValueGeneration.Internal;
using OrderMyFood.RestaurantSearchApi.Business.Interfaces;
using OrderMyFood.RestaurantSearchApi.Data;
using OrderMyFood.RestaurantSearchApi.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderMyFood.RestaurantSearchApi.Business.Concrete
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
        public IQueryable<Restaurant> InvokeRestaurantSearch(string filter)
        {
            selectedStrategy = strategies[UserChoice]; //e.g: Enum Name
            return selectedStrategy.Search(filter);
        }
    }
    internal class RestaurantList
    {
        public static IQueryable<Restaurant> GetAll()
        {
            var dbContext = new RestaurantContext();
            return dbContext.Restaurants; 
        }
    }
    internal class RestaurantName : IRestaurant
    {
        public IQueryable<Restaurant> Search(string filter)
        {
            var dbContext = new RestaurantContext();
            return dbContext.Restaurants.Where(x => x.Name == filter);
            
       }
    }

    internal class RestaurantLocation : IRestaurant
    {
        public IQueryable<Restaurant> Search(string filter)
        {
            var dbContext = new RestaurantContext();
            return dbContext.Restaurants.Where(x => x.Location.Contains(filter));
            
        }
    }

    internal class RestaurantDistance : IRestaurant
    {
        public IQueryable<Restaurant> Search(string filter)
        {
            var dbContext = new RestaurantContext();
            return dbContext.Restaurants.Where(x => x.Distance == Convert.ToInt32(filter));
        }
    }

    internal class RestaurantCuisine : IRestaurant
    {
        public IQueryable<Restaurant> Search(string filter)
        {
            var dbContext = new RestaurantContext();
            return dbContext.Restaurants.Where(x => x.Cuisine.Contains(filter));
        }
    }

    internal class RestaurantRating : IRestaurant
    {
        public IQueryable<Restaurant> Search(string filter)
        {
            var dbContext = new RestaurantContext();
            return dbContext.Restaurants.Where(x => x.Ratings == Convert.ToSByte(filter));
        }
    }

    internal class RestaurantBudget : IRestaurant
    {
        public IQueryable<Restaurant> Search(string filter)
        {
            var dbContext = new RestaurantContext();
            return dbContext.Restaurants.Where(x => x.Budget <= Convert.ToDecimal(filter));
        }
    }
}
