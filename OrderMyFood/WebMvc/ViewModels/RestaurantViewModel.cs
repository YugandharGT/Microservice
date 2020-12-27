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
        public IEnumerable<Menu> Menus { get; set; }

        public IEnumerable<Restaurant> Restaurants { get; set; }
        public PaginationInfo PaginationInfo { get; set; }

        public string RestaurantName { get; set; }

        public string SelectedSearch { get; set; }
        public SelectList SearchType { get; set; }

        public int SelectedRestaurant { get; set; }
        public IEnumerable<SelectListItem> RestaurantList { get; set; }

    }
}
