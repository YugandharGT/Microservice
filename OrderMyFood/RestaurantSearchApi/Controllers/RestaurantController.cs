using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OrderMyFood.RestaurantSearchApi.Business.Concrete;
using OrderMyFood.RestaurantSearchApi.Business.Interfaces;
using OrderMyFood.RestaurantSearchApi.Model;
using OrderMyFood.RestaurantSearchApi.ViewModel;

namespace OrderMyFood.Services.RestaurantSearchApi.Controllers
{
    [Route("api/Restaurant")]
    [ApiController]
    public class RestaurantController : ControllerBase
    {

        [HttpGet]
        [Route("FiltersRestaurants/searchtype/{searchTypeId}/search/{SearchValue}")]
        public async Task<IActionResult> FiltersRestaurants(string searchTypeId, string searchValue) //int? catalogTypeId, int? catalogBrandId, [FromQuery]int pageSize = 6, [FromQuery]int pageIndex = 0
        {

            #region DP version
            try
            {
                IQueryable<Restaurant> result=null;
                //e.g: Convert string to Enum (i.e., Name)
                var selectionType = searchTypeId; 
                var selectedValue = searchValue; 

                if (!String.IsNullOrEmpty(selectionType) && !String.IsNullOrEmpty(selectedValue))
                {
                    RestaurantImpl impl = new RestaurantImpl
                    {
                        UserChoice = ParseEnum<SearchTypes>(selectionType)
                    };
                    result = impl.InvokeRestaurantSearch(selectedValue); 
                }
                if (result.Any())
                {
                    //var totalItems = await result.LongCountAsync();

                    //var itemsOnPage = await result
                    //    .Skip(pageSize * pageIndex)
                    //    .OrderBy(c => c.Name)
                    //    .Take(pageSize)
                    //    .ToListAsync();

                    //var model = new PaginatedItemsViewModel<Restaurant>(
                    //    pageIndex, pageSize, totalItems, itemsOnPage);
                    var res = await result.ToListAsync();
                    return Ok(res);
                }
                return NotFound();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
            #endregion

        }

        [HttpGet("SearchRestaurants")]
        public async Task<IActionResult> SearchRestaurants([FromQuery] int pageIndex = 0, [FromQuery] int pageSize = 0) //int? catalogTypeId, int? catalogBrandId, [FromQuery]int pageSize = 6, [FromQuery]int pageIndex = 0
        {

            #region DP version
            try
            {
                IQueryable<Restaurant> result = null;
                result = RestaurantList.GetAll(); // ="Mango Tree" 
                if (result.Any())
                {
                    var totalItems = await result.LongCountAsync();

                    var itemsOnPage = await result
                        .Skip(pageSize * pageIndex)
                        .OrderBy(c => c.Name)
                        .Take(pageSize)
                        .ToListAsync();

                    var model = new PaginatedItemsViewModel<Restaurant>(
                        pageIndex, pageSize, totalItems, itemsOnPage);
                    return Ok(result);
                }
                return NotFound();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
            #endregion

        }

        [HttpGet]
        [Route("GetMenuByRestaurant/{restaurantName:int}")]
        public async Task<IActionResult> GetMenuByRestaurant(int restaurantName)
        {
            try
            {
                IMenu menu = new MenuContext();
                var result = await menu.GetMenuItems(restaurantName);
                if (result.Any())
                {
                    return Ok(result);
                }
                return NotFound();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }

        }
        public static T ParseEnum<T>(string value)
        {
            return (T)Enum.Parse(typeof(T), value, true);
        }

        //public static T ToEnum<T>(this string value, T defaultValue)
        //{
        //    if (string.IsNullOrEmpty(value))
        //    {
        //        return defaultValue;
        //    }

        //    T result;
        //    return Enum.TryParse<T>(value, true, out result) ? result : defaultValue;
        //}


    }
}
