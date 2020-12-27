using OrderMyFood.Web.WebMvc.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using OrderMyFood.Web.WebMvc.ViewModels;
using OrderMyFood.Web.WebMvc.Models;
using System.Diagnostics;
using System.Reflection;

namespace OrderMyFood.Web.WebMvc.Controllers
{
    public class RestaurantController : Controller
    {
        private IRestaurantService _catalogSvc;

        public RestaurantController(IRestaurantService catalogSvc) =>
            _catalogSvc = catalogSvc;
        int itemsPage = 4;

        public async Task<IActionResult> Index()
        {

            IEnumerable<Restaurant> res = await _catalogSvc.GetAllRestaurants(); // GetRestaurantList(page ?? 0, itemsPage, searchType, searchName) as IEnumerable<Restaurant>;

            var vm = new RestaurantViewModel()
            {
                Restaurants = res,
                PaginationInfo = new PaginationInfo()
                {
                    ItemsPerPage = itemsPage,
                    TotalItems = res.Count(),
                    TotalPages = (int)Math.Ceiling(((decimal)res.Count() / itemsPage))
                }
            };

            vm.PaginationInfo.Next = (vm.PaginationInfo.ActualPage == vm.PaginationInfo.TotalPages - 1) ? "is-disabled" : "";
            vm.PaginationInfo.Previous = (vm.PaginationInfo.ActualPage == 0) ? "is-disabled" : "";

            Load(vm);
            return View(vm);
        }

        private void Load(RestaurantViewModel vm)
        {
            var arrayList = new System.Collections.ArrayList();
            new Restaurant().GetType().GetProperties().ToList().ForEach(l =>
            {
                if (l.Name != "RestaurantId") arrayList.Add(l.Name);
            });
            vm.SearchType = new SelectList(arrayList);

            IEnumerable<Restaurant> restaurants = vm.Restaurants;
            
            vm.RestaurantList = restaurants.Select(i => new SelectListItem() { 
             Value = i.RestaurantId.ToString(),
             Text = i.Name,
            });
        }

        [HttpPost]
        [ActionName("Index_Post")]
        public async Task<IActionResult> Index(string submit, RestaurantViewModel viewModel)
        {
            switch (submit)
            {
                case "Search":
                    await NavigateToRestaurant(viewModel);
                    break;
                case "GetOrders":
                    await NavigateToMenu(viewModel);
                    break;
            }
            return View("Index", viewModel);

        }

        private async Task NavigateToRestaurant(RestaurantViewModel viewModel)
        {
            var type = viewModel.SelectedSearch;
            var value = viewModel.RestaurantName;
            IEnumerable<Restaurant> res = await _catalogSvc.GetRestaurantList(type, value);
            var vm = new RestaurantViewModel
            {
                Restaurants = res,
                PaginationInfo = new PaginationInfo()
                {
                    ItemsPerPage = itemsPage,
                    TotalItems = res.Count(),
                    TotalPages = (int)Math.Ceiling(((decimal)res.Count() / itemsPage))
                }
            };
            Load(vm);
        }

        private async Task NavigateToMenu(RestaurantViewModel viewModel)
        {
            var value = viewModel.SelectedRestaurant;
            IEnumerable<Menu> menus = await _catalogSvc.GetMenuItems(value);
            var vm = new RestaurantViewModel()
            {
                Restaurants = await _catalogSvc.GetAllRestaurants(),
            };
            Load(vm);
            
        }

        public ActionResult Order()
        {
            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
