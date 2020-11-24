using OrderApi.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderApi.OrderAndCancellation
{
    public class OrderFood : IFoodOrderCommands
    {
        private Food food;
        public List<Menu> FoodItems;
        public Customer User;
        public string OrderId;
        public string RestaurantId;

        public OrderFood(Food food)
        {
            this.food = food;
        }

        public void Execute()
        {
            OrderId = food.OrderFood(RestaurantId,User);
        }
    }
}
