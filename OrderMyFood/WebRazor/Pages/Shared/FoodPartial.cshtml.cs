using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OrderMyFood.Web.WebRazor.Data;
using OrderMyFood.Web.WebRazor.Models;

namespace WebRazor.Pages.Shared
{
    public class FoodPartialModel : PageModel
    {
        public void OnGet()
        {
            // using DBContext (EF 4.1 and above)  
            using (var context = new RestaurantContext())
            {

            }
        }
        //public PartialViewResult OnGetCarPartial()
        //{
            
        //    return new PartialViewResult
        //    {
        //        ViewName = "FoodPartial",
        //        ViewData = new ViewDataDictionary<List<Car>>(ViewData, Cars)
        //    };
        //}


    }
}
