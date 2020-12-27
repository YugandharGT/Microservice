using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace OrderMyFood.Web.WebMvc.Models
{
    public class Menu
    {
        public int MenuId { get; set; }
        
        public string MenuName { get; set; }
       
        public decimal Price { get; set; }

        public string RestauranName { get; set; }

    }
}
