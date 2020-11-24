using Microsoft.AspNetCore.Mvc.Rendering;
using OrderMyFood.Web.WebMvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderMyFood.Web.WebMvc.Services
{
    public interface IRestaurantService
    {
        Task<IEnumerable<Restaurant>> GetRestaurantList(string searchType, string searchName);
        Task<IEnumerable<Restaurant>> GetAllRestaurants();
    }
}
