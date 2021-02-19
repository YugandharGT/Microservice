using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderMyFood.Services.OrderApi.Model
{
    [Table("Menus")]
    public class FoodMenuModel
    {
        private int restaurantId;
        [Column("RestaurantId")]
        public int RestaurantId
        {
            get { return restaurantId; }
            set { restaurantId = value; }
        }

        private int foodId;
        [Key]
        [Column("MenuId")]
        public int FoodId
        {
            get { return foodId; }
            set { foodId = value; }
        }

        private string foodname;
        [Column("Name")]
        public string FoodName
        {
            get { return foodname; }
            set { foodname = value; }
        }

        private decimal price;
        [Column("Price")]
        public decimal Price
        {
            get { return price; }
            set { price = value; }
        }
    }
}
