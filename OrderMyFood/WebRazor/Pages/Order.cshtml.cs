using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

using OrderMyFood.Web.WebRazor.Data;
using OrderMyFood.Web.WebRazor.Models;

namespace WebRazor.Pages
{
    public class OrderModel : PageModel
    {


        [ViewData]
        public bool FoodItemsVisibility { get; set; }

        public void OnGet()
        {
            
        }
        public IActionResult OnGetLoadFoodPartial(string restId)
        {
            IEnumerable<Menu> resultset;
            Menu getFood;
            using (var context = new RestaurantContext())
            {
                var param= new SqlParameter("@RestId", Convert.ToInt32(restId));
                resultset = context.foodMenus.FromSql($"GetFoodByRestaurant @RestId", param);
                //resultset = context.Database.ExecuteSqlCommand("GetFoodByRestaurant @RestId", param);
                getFood = (from o in resultset select new Menu { MenuId = o.MenuId, MenuName = o.MenuName, Price = o.Price }).FirstOrDefault();
                           
            }           
            return new JsonResult(getFood);
        }

        public void OnPostCustomer(Customer customer)
        {
            
        }

        public void OnPostRestaurant()
        {
            var restId = Request.Form["restaurant"];
        }
        #region ViewModel Objects
        public class Customer
        {
            [BindProperty]
            public string Name { get; set; }

            [BindProperty]
            public string Email { get; set; }

            [BindProperty]
            public decimal Amount { get; set; }

            [BindProperty]
            public string Address { get; set; }

        }

        [BindProperty]
        public Food food { get; set; }

        public class Food
        {

            [BindProperty(SupportsGet = true)]
            public int FoodId { get; set; }

            [BindProperty(SupportsGet = true)]
            public string FoodName { get; set; }

            [BindProperty(SupportsGet = true)]
            public decimal Price { get; set; }

        }
        #endregion
    }
}
