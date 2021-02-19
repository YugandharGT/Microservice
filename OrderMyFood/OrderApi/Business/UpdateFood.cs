using OrderMyFood.Services.OrderApi.Data;
using OrderMyFood.Services.OrderApi.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderMyFood.Services.OrderApi.Business
{
    public class UpdateFood : IFoodOrderCommands
    {
        private Food food;
        public Customer User;
        public ICollection<FoodMenuModel> UpdateFoodItems;
        public string OrderId;
        public OrderFood order;

        public UpdateFood(Food food)
        {
            this.food = food;
        }

        public UpdateFood(Food food, OrderFood order)
        {
            this.food = food;
            this.order = order;
        }

        public UpdateFood()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        public void Execute()
        {
            food.RemoveOrder(OrderId);
            UpdatePrice(OrderId);
            UpdateOrder(UpdateFoodItems);
        }

        private void UpdatePrice(string orderId)
        {
            using (var orderContext = new OrderContext())
            {

                Order updateEntity = (from o in orderContext.Orders
                                      where o.Id == Convert.ToInt32(orderId)
                                      select new Order { Id = o.Id, CustomerId = o.CustomerId, RestaurantId = o.RestaurantId, StatusId = o.StatusId, Price = Convert.ToDecimal(o.Price), IsPaid = o.IsPaid, Note = o.Note, OrderCreated = o.OrderCreated }).FirstOrDefault();
                updateEntity.Price = User.Amount;
                orderContext.Update(updateEntity);
                orderContext.SaveChanges();
            }
        }

        private void UpdateOrder(ICollection<FoodMenuModel> lists)
        {           
            order.AddOrderDetails(OrderId, lists.ToList());
        }

        internal bool ValidateOrderID(string orderId)
        {
            var OrderRecord = new Order(){ Price = User.Amount };
            using (var orderContext = new OrderContext())
            {

                Order customerRecord = (from o in orderContext.Orders
                                     where o.Id == Convert.ToInt32(orderId)
                                     select new Order { Id = o.Id, CustomerId = o.CustomerId, RestaurantId = o.RestaurantId, StatusId = o.StatusId, Price = Convert.ToDecimal(o.Price), IsPaid = o.IsPaid, Note = o.Note, OrderCreated = o.OrderCreated }).FirstOrDefault();
                    //orderContext.Orders.Where(c => c.Id== Convert.ToInt32(orderId)).FirstOrDefault();
                if (customerRecord == null)
                {
                    return false;
                }
                else 
                {
                    return true;
                }
            }
            
        }
    }
}
