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
        public void Post([FromBody] string value)
        {
        }

    }
}
