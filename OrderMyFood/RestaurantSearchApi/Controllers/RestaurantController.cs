using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RestaurantSearchApi.Business.Concrete;
using RestaurantSearchApi.Business.Interfaces;
using RestaurantSearchApi.Model;

namespace RestaurantSearchApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestaurantController : ControllerBase
    {
        
        [HttpPost]
        public ActionResult SearchRestaurants()
        {

            #region DP version
            try
            {
                //e.g: Convert string to Enum (i.e., Name)
                string SelectionType = "Name";
                string SelectedValue = string.Empty;

                RestaurantImpl impl = new RestaurantImpl();
                impl.UserChoice = ParseEnum<SearchTypes>(SelectionType);
                var result = impl.InvokeRestaurantSearch(SelectedValue ="Mango Tree");
                if (result.Any())
                {
                    return Ok(result);
                }
                return NotFound();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
            #endregion

        }

        [HttpGet]
        public ActionResult GetMenuByRestaurant()
        {
            try
            {
                int restaurantSelection;
                IMenu menu = new MenuContext();
                var result = menu.GetMenuItems(restaurantSelection = 1);
                if (result.Any())
                {
                    return Ok(result);
                }
                return NotFound();
            }
            catch (Exception ex)
            {
                return BadRequest();
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
