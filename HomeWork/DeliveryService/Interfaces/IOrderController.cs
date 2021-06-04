using System;
using System.Collections.Generic;
using DeliveryService.Models;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryService.Interfaces
{
    interface IOrderController
    {
        void AddOrder(Order order);
    }
}
