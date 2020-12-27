using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using OrderMyFood.Web.WebRazor.Business;
using OrderMyFood.Web.WebRazor.Models;

namespace WebRazor.Pages
{
    public class MenuModel : PageModel
    {
        private readonly IRestaurantService _restService;

        public MenuModel(IRestaurantService restService)
        {

            _restService = restService;
        }
        #region UI Controls
        [BindProperty(SupportsGet = true)]
        public string PassRestaurant { get; set; }
        [BindProperty]
        public IEnumerable<SelectListItem> RestaurantViewer { get; set; }
        public IEnumerable<Menu> Menus { get; set; }
        #endregion

        #region Table Pagination
        [BindProperty(SupportsGet = true)]
        public int CurrentPage { get; set; } = 1;
        public int Count { get; set; }
        public int PageSize { get; set; } = 3;

        public int TotalPages => (int)Math.Ceiling(decimal.Divide(Count, PageSize));

        public bool ShowPrevious => CurrentPage > 1;
        public bool ShowNext => CurrentPage < TotalPages;
        public bool ShowFirst => CurrentPage != 1;
        public bool ShowLast => CurrentPage != TotalPages;
        #endregion

        public async Task OnGetAsync()
        {
           await PopulateData();
        }

        private async Task PopulateData()
        {
            IEnumerable<Restaurant> data =  await _restService.GetAllRestaurants();
            RestaurantViewer = data.Select(i => new SelectListItem()
            {
                Value = i.RestaurantId.ToString(),
                Text = i.Name,
            });
        }

        public async Task OnPost()
        {
            int restaurantId = 0;
            if (int.TryParse(PassRestaurant, out restaurantId))
            {
                Menus = await _restService.GetPaginatedResultOfMenu(restaurantId, CurrentPage, PageSize);
                Count = Menus.Count();
            }
            await PopulateData();
            ViewData["IsTableVisible"] = true;
        }

    }
}
