using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;

namespace OrderMyFood.Services.ReviewApi.Model
{
    public class Restaurant
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int RestaurantId { get; set; }

        public string Name { get; set; }
        public string Location { get; set; }
        public int Distance { get; set; }
        public string Cuisine { get; set; }
        public decimal Budget { get; set; }
        public short Ratings { get; set; }

    }
}
