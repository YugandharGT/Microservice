using Microsoft.EntityFrameworkCore;
using OrderMyFood.Services.ReviewApi.Data;
using OrderMyFood.Services.ReviewApi.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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

        public async Task<Restaurant> UpdateRating(int v1, short value)
        {
            using (var dbContext = new RestaurantContext())
            {
                var updtRecord = (from r in dbContext.Restaurants where r.RestaurantId == v1 select r).SingleOrDefault();
                if (updtRecord != null)
                {
                    updtRecord.Ratings = value;
                    dbContext.Update(updtRecord);
                    await dbContext.SaveChangesAsync();
                    return updtRecord;
                }
                return null;
            }
        }

        public Task<IEnumerable<object>> ViewReview()
        {
            throw new NotImplementedException();
        }
    }
}

