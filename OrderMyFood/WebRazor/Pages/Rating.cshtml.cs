using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OrderMyFood.Web.WebRazor.Business;
using Microsoft.AspNetCore.Authorization;
using OrderMyFood.Web.WebRazor.Models;

namespace WebRazor.Pages
{
    public class RatingModel : PageModel
    {
        private readonly IReviewService _restService;

        public RatingModel(IReviewService restService)
        {

            _restService = restService;
        }

        public IEnumerable<RatingViewModel> ratingViewModel { get; set; }

        [BindProperty(SupportsGet = true)]
        public string SubmittedRating { get; set; }

       
        public async Task OnGet()
        {
           ratingViewModel = await _restService.GetRatings();
        }

        public void OnPostUpdateRating(string name, string value)
        {
            //
        }

        public void OnPost()
        {
            var store = Request.Form["SubmittedRating"];
        }
    }

}
