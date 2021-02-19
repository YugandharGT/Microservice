using OrderMyFood.Services.OrderApi.Data;
using OrderMyFood.Services.OrderApi.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderMyFood.Services.OrderApi.Business
{
    /// <summary>
    /// Do cascade insert or update for the customer (order-customer: 1-1) order, tems(menuids as csv), price restu,customer
    /// </summary>
    public class Food
    {
        public string OrderFood(string restaurantId, Customer user)
        {
            //nsert to order table has restaurant(1-*) & customer(1-*) as reference then check for customer entry else nsert
            bool IsPaid=false;
            var orderId = string.Format("{0}{1}",restaurantId,001);
            if (user.Amount != 0.0m) IsPaid = true;
            using (var orderContext = new OrderContext())
            {
                var order = new Order()
                { Id = Convert.ToInt32(orderId), RestaurantId = Convert.ToInt32(restaurantId), StatusId = 1, OrderCreated = DateTime.Now, IsPaid = IsPaid, Price = user.Amount, CustomerId = user.CustomerId };

                orderContext.Add<Order>(order);
                orderContext.SaveChanges();
            }
            return orderId.ToString();
        }

        public string CancelFood(int orderId)
        {
            IQueryable<Order> record = null;
            using (var orderContext = new OrderContext())
            {
                record = (from o in orderContext.Orders
                          where o.Id == orderId
                          select new Order
                          { Id = o.Id, CustomerId = o.CustomerId, RestaurantId = o.RestaurantId, StatusId = o.StatusId, Price = Convert.ToDecimal(o.Price), IsPaid = o.IsPaid, Note = o.Note, OrderCreated = o.OrderCreated });
                    //orderContext.Orders.Where(c => c.Id == orderId);
                if (!record.Any()) return "Order is not crated to cancel";

                orderContext.Remove(record.FirstOrDefault());
                orderContext.SaveChanges();

                var customerRecord = orderContext.OrderDetails.Where(c => c.OrderId == (orderId));
                if (!customerRecord.Any()) return "Order Details are not found to cancel";
                
                orderContext.Remove(customerRecord.FirstOrDefault());
                orderContext.SaveChanges();
                
            }
            return record.FirstOrDefault().Id.ToString();
        }

        public void RemoveOrder(string OrderId)
        {
            //get order by order & try custd wth respectve name then update orderdetals & customer
            using (var orderContext = new OrderContext())
            {                
                var customerRecord = orderContext.OrderDetails.Where(c => c.OrderId== Convert.ToInt32(OrderId));
                if(customerRecord.Any())
                {
                    orderContext.RemoveRange(customerRecord);
                    orderContext.SaveChanges();
                }
            }
        }

        public List<FoodMenuModel> ViewByOrderId(int orderId)
        {
            using (var orderContext = new OrderContext())
            {
                var view = (from od in orderContext.OrderDetails
                            join fm in orderContext.foodMenus on od.MenuId equals fm.FoodId
                            where od.OrderId == orderId
                            select fm);
                return view.ToList();
            }

        }
    }
}
