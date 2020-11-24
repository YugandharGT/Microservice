using Microsoft.AspNetCore.Mvc.Rendering;
using OrderMyFood.Web.WebMvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderMyFood.Web.WebMvc.ViewModels
{
    public class RestaurantViewModel
    {
        public IEnumerable<Restaurant> Restaurants { get; set; }
        public PaginationInfo PaginationInfo { get; set; }

        public string RestaurantName { get; set; }

        public string SelectedRestaurant { get; set; }
        public SelectList SearchType { get; set; }
    }
}
