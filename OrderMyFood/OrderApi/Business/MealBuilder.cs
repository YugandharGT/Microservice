using OrderMyFood.Services.OrderApi.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderMyFood.Services.OrderApi.Business
{
    public class MealBuilder
    {
        public Meal meal;
        public void PrepareMeal(List<FoodMenuModel> foodMenu)
        {
            meal = new Meal();
            meal.AddFoodItem(foodMenu);
        }
    }
}
