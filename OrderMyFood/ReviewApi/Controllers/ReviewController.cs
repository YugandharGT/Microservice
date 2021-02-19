using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OrderMyFood.Services.ReviewApi.Business;

namespace OrderMyFood.Services.ReviewApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        [Route("GetRestaurantRatings")]
        public async Task<IActionResult> GetRestaurantRatings()
        {
            try
            {
                IReview review = new Review();
                var result = await review.ViewRating();
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

        // POST api/values
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] int restid, string value)
        {
            try
            {
                IReview review = new Review();
                short ratValue = 0;
                if (!short.TryParse(value, out ratValue)) return BadRequest("Passed value found Invald");

                var result = await review.UpdateRating(restid, ratValue); 
                if (result != null)
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

    }
}
