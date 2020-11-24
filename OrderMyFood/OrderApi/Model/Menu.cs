using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace OrderApi.Model
{
    public class Menu
    {
        public int MenuId { get; set; }
        
        public string Name { get; set; }
       
        public decimal Price { get; set; }

        public int RestaurantId { get; set; }

    }
}
