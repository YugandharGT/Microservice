using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using OrderMyFood.Services.OrderApi.Business;
using OrderMyFood.Services.OrderApi.Model;

namespace OrderMyFood.Services.OrderApi.Controllers
{
    [Route("api/Order")]
    [ApiController]
    public class OrderController : Controller
    {
        readonly MealOrderContext orderContext;
        public OrderController()
        {
            orderContext = new MealOrderContext();
        }

        [HttpPost] 
        [Route("PlaceOrder")]
        public IActionResult PlaceOrder([FromQuery] string restaurantId, [FromQuery] Customer customerJson, [FromBody] ICollection<FoodMenuModel> foodMenuJson)
        {
            try
            {
                var orderId = orderContext.MealOrderByUser(foodMenuJson, restaurantId, customerJson);
                
                if (!string.IsNullOrEmpty(orderId))
                {
                    return Ok(orderId);
                }
                return NotFound();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }

        }

        [HttpPost] 
        [Route("UpdateOrder")] 
        public IActionResult UpdateOrder([FromBody] ICollection<FoodMenuModel> foodMenuJson, [FromQuery]string orderId)
        {
            try
            {
                var result = orderContext.MealUpdateByUser(foodMenuJson, orderId);
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

        [HttpPost("CancelOrder")]
        public IActionResult CancelOrder(string orderId)
        {
            try
            {
                orderContext.MealCancelByUser(orderId);
                return Ok();   
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }

        }

        [HttpGet("ViewOrder")]
        public IActionResult ViewOrder(string orderId)
        {
            try
            {
                int id =0;
                if (int.TryParse(orderId, out id))
                {
                    Food meal = new Food();
                    List<FoodMenuModel> result = meal.ViewByOrderId(id);

                    if (!result.Any()) return NotFound();

                    return Ok(result);
                    
                }
                else
                {
                    return BadRequest("Invalid OrderId is passed");
                }
              
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }

        }
    }
}
