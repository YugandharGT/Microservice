using OrderMyFood.Web.WebRazor.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OrderMyFood.Web.WebRazor.Business
{
    public interface IRestaurantService
    {
        Task<IEnumerable<Menu>> GetOrderByRestaurant(int restaurantName);
        Task<List<Restaurant>> GetRestaurantList(string searchType, string searchName);
        Task<IEnumerable<Restaurant>> GetAllRestaurants();
        Task<IEnumerable<Menu>> GetMenuItems(int restaurantId);
        Task<List<Restaurant>> GetPaginatedResult(int currentPage, int pageSize);
        Task<List<Menu>> GetPaginatedResultOfMenu(int restaurantId, int currentPage, int pageSize);

        


    }
}
