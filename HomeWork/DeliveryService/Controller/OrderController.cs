using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeliveryService.Interfaces;
using DeliveryService.Models;

namespace DeliveryService.Controller
{
    class OrderController : IOrderController
    {
        private readonly IStoreContext storeContext;

        public OrderController(IStoreContext storeContext)
        {
            this.storeContext = storeContext;
        }
        public void AddOrder(Order order)
        {
            order.Id = storeContext.Orders.Count > 0 ? storeContext.Orders.Max(x => x.Id) + 1 : 1;

            storeContext.Orders.Add(order);
        }
    }
}
