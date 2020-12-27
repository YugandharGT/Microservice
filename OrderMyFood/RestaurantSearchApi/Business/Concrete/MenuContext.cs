using Microsoft.EntityFrameworkCore;
using OrderMyFood.RestaurantSearchApi.Business.Interfaces;
using OrderMyFood.RestaurantSearchApi.Data;
using OrderMyFood.RestaurantSearchApi.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderMyFood.RestaurantSearchApi.Business.Concrete
{
    /// <summary>
    /// 
    /// </summary>
    public class MenuContext : IMenu
    {
        public MenuContext()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="restaurantId"></param>
        public async Task<IEnumerable<object>> GetMenuItems(int restaurantId)
        {
            using (var dbContext = new RestaurantContext())
            {
                var result = (from r in dbContext.Restaurants
                             join m in dbContext.Menus
                             on r.RestaurantId equals m.RestaurantId
                             where r.RestaurantId == restaurantId
                             select new  {m.MenuId, RestaurantName = r.Name, MenuName = m.Name, m.Price});
                return await result.ToListAsync();
            }
        }
    }
}
