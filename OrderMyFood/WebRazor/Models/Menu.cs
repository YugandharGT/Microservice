using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderMyFood.Web.WebRazor.Models
{
    public class Menu
    {
        public string RestaurantName { get; set; }
        public string MenuName { get; set; }
        public decimal Price { get; set; }
        public int MenuId { get; set; }
    }
}
