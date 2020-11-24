using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerApi.Model
{
    public class Customer
    {
        public String UserId { get; set; }

        public String UserName { get; set; }

        public String PhoneNumber { get; set; }

        public String Address { get; set; }

        public double Amount { get; set; }

        //List<IFoodOrderCommands> orderList = new List<IFoodOrderCommands>();

        //public void TakeOrder(IFoodOrderCommands order)
        //{
        //    orderList.Add(order);
        //}

        //public void PlaceOrders()
        //{
        //    foreach (var order in orderList)
        //    {
        //        order.Execute();
        //    }

        //    orderList.Clear();
        //}
    }
}
