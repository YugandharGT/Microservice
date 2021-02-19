using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderMyFood.Services.OrderApi.Business
{
    public class CancelFood : IFoodOrderCommands
    {
        private Food food;
        public int OrderId;

        public CancelFood(Food food)
        {
            this.food = food;
        }

        /// <summary>
        /// 
        /// </summary>
        public void Execute()
        {
            food.CancelFood(OrderId);
        }
    }
}
