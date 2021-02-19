using Microsoft.AspNetCore.Mvc.Rendering;
using OrderMyFood.Services.ReviewApi.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderMyFood.Services.ReviewApi.Business 
{
    public interface IReview
    {
        //void SetRating(int a);
        //void SetReview(string c);
        //void UpdateReview(int restaurantId);
        Task<IEnumerable<object>> ViewReview();
        Task<IEnumerable<object>> ViewRating();
        Task<Restaurant> UpdateRating(int v1, short value);
    }
}
