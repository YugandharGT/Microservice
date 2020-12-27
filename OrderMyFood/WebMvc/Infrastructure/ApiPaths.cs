using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderMyFood.Web.WebMvc.Infrastructure
{
    public class ApiPaths
    {
        public static class Restaurant
        {
            public static string GetAllRestaurants(string baseUri, string basketId)
            {
                return $"{baseUri}/{basketId}";
            }

            public static string UpdateBasket(string baseUri)
            {
                return baseUri;
            }

            public static string GetMenuFromRestaurant(string baseUri, string basketId)
            {
                return $"{baseUri}/{basketId}";
            }
        }

        public static class Order
        {
            public static string GetOrder(string baseUri, string orderId)
            {
                return $"{baseUri}/{orderId}";
            }

            //public static string GetOrdersByUser(string baseUri, string userName)
            //{
            //    return $"{baseUri}/userOrders?userName={userName}";
            //}
            public static string GetOrders(string baseUri)
            {
                return baseUri;
            }
            public static string AddNewOrder(string baseUri)
            {
                return $"{baseUri}/new";
            }
        }

        public static class RestaurantPage
        {
            public static string GetFilteredRestaurant(string baseUri, int page, int take, string searchType, string searchName)
            {
                var filterQs = "";

                if (!String.IsNullOrEmpty(searchType) || !String.IsNullOrEmpty(searchName))
                {
                    filterQs = $"/searchtype/{searchType}/search/{searchName}";
                }

                return $"{baseUri}{filterQs}?pageIndex={page}&pageSize={take}";
            }

            public static string SearchRestaurant(string baseUri, string searchType, string searchName)
            {
                var filterQs = $"/searchtype/{searchType}/search/{searchName}";
                return $"{baseUri}/FiltersRestaurants{filterQs}";
            }
            public static string GetAllRestaurant(string baseUri)
            {
                return $"{baseUri}";
            }

            internal static string GetMenu(string remoteServiceBaseUrl, int restaurantName)
            {
                var filterQs = $"/{restaurantName}";
                return $"{remoteServiceBaseUrl}/GetMenuByRestaurant{filterQs}";
            }
        }
    }
}
