using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Microsoft.AspNetCore.Hosting;
using OrderMyFood.Services.ReviewApi.Data;

namespace OrderMyFood.Services.ReviewApi.Business
{
    public class Review : IReview
    {
        public async Task<IEnumerable<object>> ViewRating()
        {
            using (var dbContext = new RestaurantContext())
            {
                var result = (from r in dbContext.Restaurants
                              select new { Name = r.Name, Star = r.Ratings });
                return await result.ToListAsync();
            }
        }

        public async Task<IEnumerable<object>> ViewReview()
        {
            throw new NotImplementedException();
        }
    }
}

