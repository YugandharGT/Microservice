using Microsoft.Extensions.Options;
using OrderMyFood.Web.WebRazor.Infrastructure;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static WebRazor.Pages.OrderModel;

namespace OrderMyFood.Web.WebRazor.Business
{
    public class OrderConsumer : IOrderConsumer
    {
        private readonly IOptionsSnapshot<AppSettings> _settings;
        private readonly IHttpClient _apiClient;
        private readonly string _remoteServiceBaseUrl;


        public OrderConsumer(IOptionsSnapshot<AppSettings> settings, IHttpClient httpClient) 
        {

            _settings = settings;
            _apiClient = httpClient;
            _remoteServiceBaseUrl = $"{_settings.Value.RestaurantUrl}/api/Restaurant";
        }

        public async Task GetRestaurantList(int restId, Customer customer)
        {
            ArrayList paramList = new ArrayList(); ;
            paramList.Add(restId);
            paramList.Add(customer);

            var allcatalogItemsUri = ApiPaths.OrderPage.GetMenuByRestaurantId(baseUri: _remoteServiceBaseUrl);

            await _apiClient.PostAsync(allcatalogItemsUri, paramList);
        }
    }
}
