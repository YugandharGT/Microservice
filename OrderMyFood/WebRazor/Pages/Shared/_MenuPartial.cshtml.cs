using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using OrderMyFood.Web.WebRazor.Business;
using OrderMyFood.Web.WebRazor.Models;
using localModel = WebRazor.Pages.Shared._MenuPartialModel;
namespace WebRazor.Pages.Shared
{
    public class _MenuPartialModel : PageModel
    {
        private readonly IRestaurantService _restService;

        public _MenuPartialModel(IRestaurantService restService)
        {

            _restService = restService;
        }

        [BindProperty(SupportsGet = true)]
        public string PassRestaurant { get; set; }
        [BindProperty]
        public IEnumerable<SelectListItem> RestaurantViewer { get; set; }
        public IEnumerable<Menu> Menus { get; set; }

        public void OnGet()
        {
            
        }

        public IActionResult OnGetPartial()
        {
            IEnumerable<Restaurant> data = _restService.GetAllRestaurants().Result;
            RestaurantViewer = data.Select(i => new SelectListItem()
            {
                Value = i.RestaurantId.ToString(),
                Text = i.Name,
            });
            return new PartialViewResult
            {
                ViewName = "Menu",
                ViewData = new ViewDataDictionary<IEnumerable<SelectListItem>>(ViewData, RestaurantViewer)
            };
        }

        //public PartialViewResult OnPostMenuPartial()
        //{
        //    int restaurantId = 0;
        //    if (int.TryParse(PassRestaurant, out restaurantId))
        //    {
        //        Menus = _restService.GetOrderByRestaurant(restaurantId) as IEnumerable<Menu>;
        //    }

        //}

        public class Menu
        {
            public int MenuId { get; set; }

            public string MenuName { get; set; }

            public decimal Price { get; set; }

            public string RestauranName { get; set; }

        }
    }

}
