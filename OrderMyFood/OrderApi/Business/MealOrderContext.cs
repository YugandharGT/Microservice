using OrderMyFood.Services.OrderApi.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderMyFood.Services.OrderApi.Business
{
    public class MealOrderContext
    {
        /// <summary>
        /// This driver called Command Design Pattern
        /// </summary>
        /// <param name="selectedMealItems"></param>
        /// <param name="totalCost"></param>
        /// <param name="restaurantId"></param>
        /// <param name="orderId"></param>
        /// <param name="user"></param>
        /// <returns></returns>
        public string MealOrderByUser(ICollection<FoodMenuModel> selectedMealItems, string restaurantId, Customer customer)
        {
            //Food
            Meal meal = new Meal();
            meal.AddFoodItem(selectedMealItems.ToList());

            Food food = new Food();
            OrderFood orderFood = new OrderFood(food);

           ;
            //customer detals
            orderFood.User = new Customer();            
            orderFood.User.UserName = customer.UserName;
            orderFood.User.Address = customer.Address;
            orderFood.User.PhoneNumber = customer.PhoneNumber;
            var cust = orderFood.AddCustomerIfNotExists(orderFood.User);
            orderFood.User.CustomerId = cust.CustomerId;

            //payment
            orderFood.User.Amount = meal.GetCost();
            orderFood.RestaurantId = restaurantId;
           ;
            // Place Order
            orderFood.Execute();
            var menuList = meal.FoodItems;
            return !orderFood.AddOrderDetails(orderFood.OrderId, menuList)
                ? "An error occured while placing the order"
                : orderFood.OrderId;
        }

        public string MealUpdateByUser(ICollection<FoodMenuModel> updateMealItems, string orderId)
        {
            Meal meal = new Meal();
            meal.AddFoodItem(updateMealItems.ToList());

            Food food = new Food();
            UpdateFood updateOrder = new UpdateFood(food, new OrderFood());

            updateOrder.UpdateFoodItems = updateMealItems;
            updateOrder.OrderId = orderId;
            updateOrder.User = new Customer();
            //updateOrder.User.CustomerId = 12;
            //updateOrder.User.UserName = "Gul";
            //updateOrder.User.Address = "Marathahall, Bangalore - 560006";
            //updateOrder.User.PhoneNumber = "99998988";
            //payment
            updateOrder.User.Amount = meal.GetCost();

            if (!updateOrder.ValidateOrderID(orderId)) return "Invalid OrderID";

            //update order
            updateOrder.Execute();
            return "Your order is successfully updated";
            
        }

        public void MealCancelByUser(string orderId)
        {

            Food food = new Food();
            CancelFood cancelOrder = new CancelFood(food);
            cancelOrder.OrderId = Convert.ToInt32(orderId);
            cancelOrder.Execute();
        }

    }
}
