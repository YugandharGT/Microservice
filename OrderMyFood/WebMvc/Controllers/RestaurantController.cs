using OrderMyFood.Web.WebMvc.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        private static void Load(RestaurantViewModel vm)
        {
            var arrayList = new System.Collections.ArrayList();
            new Restaurant().GetType().GetProperties().ToList().ForEach(l =>
            {
                if (l.Name != "RestaurantId") arrayList.Add(l.Name);
            });
            vm.SearchType = new Microsoft.AspNetCore.Mvc.Rendering.SelectList(arrayList);
        }

        [HttpPost]
        [ActionName("Index_Post")]
        public ActionResult Index(RestaurantViewModel viewModel)
        {          

            IEnumerable<Restaurant> res = _catalogSvc.GetRestaurantList(viewModel.SelectedRestaurant, viewModel.RestaurantName) as IEnumerable<Restaurant>;
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
            Load(vm); 
            return View("Index", vm);
        }
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
