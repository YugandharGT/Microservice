using OrderMyFood.Web.WebRazor.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using OrderMyFood.Web.WebRazor.Models;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Logging;
using OrderMyFood.Web.WebRazor.Infrastructure;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Microsoft.AspNetCore.Hosting;

namespace OrderMyFood.Web.WebRazor.Business
{
    public class RestaurantService : IRestaurantService
    {
        private readonly IOptionsSnapshot<AppSettings> _settings;
        private readonly IHttpClient _apiClient;
        //private readonly ILogger<RestaurantService> _logger;

        private readonly string _remoteServiceBaseUrl;


        public RestaurantService(IOptionsSnapshot<AppSettings> settings, IHttpClient httpClient) //, ILogger<RestaurantService> logger
        {
           
            _settings = settings;
            _apiClient = httpClient;
            //_logger = logger;

            _remoteServiceBaseUrl = $"{_settings.Value.RestaurantUrl}/api/Restaurant";
        }

        #region
        public async Task<IEnumerable<Menu>> GetOrderByRestaurant(int restaurantName)
        {
            var allcatalogItemsUri = ApiPaths.RestaurantPage.GetMenu(_remoteServiceBaseUrl, restaurantName);

            var dataString =  await _apiClient.GetStringAsync(allcatalogItemsUri);

            var response = JsonConvert.DeserializeObject<IEnumerable<Menu>>(dataString);

            return response;
        }

        public async Task<List<Restaurant>> GetRestaurantList(string searchType, string searchName)
        {
            var allcatalogItemsUri = ApiPaths.RestaurantPage.SearchRestaurant(_remoteServiceBaseUrl,searchType, searchName);

            var dataString = await _apiClient.GetStringAsync(allcatalogItemsUri);

            var response = JsonConvert.DeserializeObject<List<Restaurant>>(dataString);

            return response;
        }

        public async Task<IEnumerable<Restaurant>> GetAllRestaurants()
        {
            var getBrandsUri = ApiPaths.RestaurantPage.GetAllRestaurant(_remoteServiceBaseUrl);

            var dataString = await _apiClient.GetStringAsync(getBrandsUri);

            var response = JsonConvert.DeserializeObject<IEnumerable<Restaurant>>(dataString);
            return response;
        }

        public async Task<IEnumerable<Menu>> GetMenuItems(int restaurantId)
        {
            var getBrandsUri = ApiPaths.RestaurantPage.GetMenu(_remoteServiceBaseUrl, restaurantId);

            var dataString = await _apiClient.GetStringAsync(getBrandsUri);

            var response = JsonConvert.DeserializeObject<IEnumerable<Menu>>(dataString);
            return response;
        }


        public async Task<List<Restaurant>> GetPaginatedResult(int currentPage, int pageSize = 10)
        {
            var data = await GetAllRestaurants();
            return data.OrderBy(d => d.RestaurantId).Skip((currentPage - 1) * pageSize).Take(pageSize).ToList();
        }

        public async Task<List<Menu>> GetPaginatedResultOfMenu(int restaurantId, int currentPage, int pageSize = 10)
        {
            var data = await GetOrderByRestaurant(restaurantId);
            return data.OrderBy(d => d.MenuId).Skip((currentPage - 1) * pageSize).Take(pageSize).ToList();
        }
        #endregion

        
    }
}

