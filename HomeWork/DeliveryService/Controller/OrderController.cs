using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeliveryService.Interfaces;
using DeliveryService.Models;

namespace DeliveryService.Controller
{
    public class OrderController : IOrderController
    {
        private readonly IStoreContext _storeContext;
        private readonly ILogger _logger;

        public OrderController(IStoreContext storeContext, ILogger logger)
        {
            _storeContext = storeContext;
            _logger = logger;
        }
        public void AddOrder(Order order)
        {
            order.Id = _storeContext.Orders.Count > 0 ? _storeContext.Orders.Max(x => x.Id) + 1 : 1;

            _storeContext.Orders.Add(order);
            if (_storeContext.Buyers is not null)
            {
                _logger.Log($"Пользователи добавили новый заказ (ID: {order.Id})");
            }
            
        }
    }
}
