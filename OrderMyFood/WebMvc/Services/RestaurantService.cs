using OrderMyFood.Web.WebMvc.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using OrderMyFood.Web.WebMvc.Models;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Logging;
using OrderMyFood.Web.WebMvc.Infrastructure;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace OrderMyFood.Web.WebMvc.Services
{
    public class RestaurantService : IRestaurantService
    {
        private readonly IOptionsSnapshot<AppSettings> _settings;
        private readonly IHttpClient _apiClient;
        private readonly ILogger<RestaurantService> _logger;

        private readonly string _remoteServiceBaseUrl;
        public RestaurantService(IOptionsSnapshot<AppSettings> settings, IHttpClient httpClient, ILogger<RestaurantService> logger)
        {
            _settings = settings;
            _apiClient = httpClient;
            _logger = logger;

            _remoteServiceBaseUrl = $"{_settings.Value.RestaurantUrl}/api/Restaurant";
        }

        public async Task<IEnumerable<Restaurant>> GetOrderByRestaurant(int restaurantName)
        {
            var allcatalogItemsUri = ApiPaths.RestaurantPage.GetMenu(_remoteServiceBaseUrl, restaurantName);

            var dataString = await _apiClient.GetStringAsync(allcatalogItemsUri);

            var response = JsonConvert.DeserializeObject<IEnumerable<Restaurant>>(dataString);

            return response;
        }

        public async Task<IEnumerable<Restaurant>> GetRestaurantList(string searchType, string searchName)
        {
            var allcatalogItemsUri = ApiPaths.RestaurantPage.SearchRestaurant(_remoteServiceBaseUrl,searchType, searchName);

            var dataString = await _apiClient.GetStringAsync(allcatalogItemsUri);

            var response = JsonConvert.DeserializeObject<IEnumerable<Restaurant>>(dataString);

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
    }
}
