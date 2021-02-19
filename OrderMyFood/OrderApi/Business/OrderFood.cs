using OrderMyFood.Services.OrderApi.Data;
using OrderMyFood.Services.OrderApi.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderMyFood.Services.OrderApi.Business
{
    public class OrderFood : IFoodOrderCommands
    {
        private Food food;
        public List<FoodMenuModel> FoodItems;
        public Customer User;
        public string OrderId;
        public string RestaurantId;

        public OrderFood(Food food)
        {
            this.food = food;
        }
        public OrderFood()
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="customer"></param>
        public Customer AddCustomerIfNotExists(Customer customer)
        {
            Customer customerDTO = new Customer();
            using (var orderContext = new OrderContext())
            {                

                var customerRecord = orderContext.customers.Where(c => c.UserName == customer.UserName).FirstOrDefault();
                if(customerRecord != null)
                {
                    customerDTO = new Customer { UserName = customer.UserName, PhoneNumber = customer.PhoneNumber, Address = customer.Address, Amount = customer.Amount };
                    orderContext.Update(customerDTO);
                }
                else
                {
                    customerDTO = new Customer { CustomerId = customer.CustomerId, UserName = customer.UserName, PhoneNumber = customer.PhoneNumber, Address = customer.Address, Amount = customer.Amount };
                    orderContext.Add(customerDTO);
                }
                orderContext.SaveChanges();
            }
            return customerDTO;
        }


        public bool AddOrderDetails(string orderId, List<FoodMenuModel> selectedMenus)
        {
            List<OrderDetails> orderDetails = new List<OrderDetails>();
            using (var orderContext = new OrderContext())
            {
                var itemQty = selectedMenus.GroupBy(p => p.FoodId);
                for (int i = 0; i < selectedMenus.Count; i++)
                {
                    int menuQty = itemQty.Where(li => li.Key == selectedMenus[i].FoodId).Count();
                    var order = new OrderDetails()
                    {
                        OrderId = Convert.ToInt32(orderId),
                        MenuId = Convert.ToInt32(selectedMenus[i].FoodId),
                        Quantity = menuQty
                    };
                    orderDetails.Add(order);
                }

                orderContext.AddRange(orderDetails);
                orderContext.SaveChanges();
                return true;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public void Execute()
        {
            //FoodItems = 
            OrderId = food.OrderFood(RestaurantId,User);
        }
    }
}
