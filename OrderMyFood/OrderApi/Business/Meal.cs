using OrderMyFood.Services.OrderApi.Data;
using OrderMyFood.Services.OrderApi.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderMyFood.Services.OrderApi.Business
{
    public class Meal
    {
        private List<FoodMenuModel> foodItems;
        public Meal()
        {
            foodItems = new List<FoodMenuModel>();
        }

        public List<FoodMenuModel> FoodItems { get { return foodItems; }  }

        public decimal MealCost { get; private set; }

        public void AddFoodItem(List<FoodMenuModel> items)
        {
            foodItems.AddRange(items);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public decimal GetCost()
        {
            decimal cost = 0m;

            foreach (var item in foodItems)
            {
                cost += item.Price;
            }
            MealCost = cost;
            return cost;
        }

      
    }
}
