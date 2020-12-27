using OrderMyFood.Web.WebRazor.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OrderMyFood.Web.WebRazor.Business
{
    public interface IReviewService
    {
        Task<IEnumerable<RatingViewModel>> GetRatings();
    }
}
