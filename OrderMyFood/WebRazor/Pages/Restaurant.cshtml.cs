using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json.Linq;
using OrderMyFood.Web.WebRazor.Business;
using OrderMyFood.Web.WebRazor.Models;

namespace WebRazor.Pages
{
    public class RestaurantModel : PageModel
    {
        //private readonly IHostingEnvironment _hostingEnvironment;
        private readonly IRestaurantService _restService;

        public RestaurantModel(IRestaurantService restService)
        {
            
            _restService = restService;
        }

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

        #region UI Controls
        [BindProperty(SupportsGet = true)]
        public string SelectedType { get; set; }
        [BindProperty]
        public IEnumerable<SelectListItem> SearchType { get; set; }

        [BindProperty(SupportsGet = true)]
        public string SearchParameter { get; set; }

        [BindProperty(SupportsGet = true)]
        public string PassRestaurant { get; set; }
        [BindProperty]
        public IEnumerable<SelectListItem> RestaurantViewer { get; set; }

        public IEnumerable<Menu> Menus { get; set; }
        public List<Restaurant> Data { get; set; }
        #endregion

        public async Task OnGetAsync()
        {
            
            Data = await _restService.GetPaginatedResult(CurrentPage, PageSize);
            Count = Data.Count();
            await PopulateData();
        }

        private async Task PopulateData()
        {
            var arrayList = new System.Collections.ArrayList();
            new Restaurant().GetType().GetProperties().ToList().ForEach(l =>
            {
                if (l.Name != "RestaurantId") arrayList.Add(l.Name);
            });
            SearchType = new SelectList(arrayList);

            IEnumerable<Restaurant> data = await _restService.GetAllRestaurants();
            RestaurantViewer = data.Select(i => new SelectListItem()
            {
                Value = i.RestaurantId.ToString(),
                Text = i.Name,
            });
        }

        public async Task OnPost()
        {
            Data =  await _restService.GetRestaurantList(SelectedType, SearchParameter);
            Count = Data.Count();
            await PopulateData();
        }

        public async Task<IActionResult> OnPostMenuByRestaurant() //[FromBody] JObject jobject
        {
            int restaurantId = 0;
            await OnPost();
            if (int.TryParse(PassRestaurant, out restaurantId))
            {
                Menus = await _restService.GetOrderByRestaurant(restaurantId);
                return Page();
            }
            else
                return Page();
        }

       
    }
}
