using System;
using DeliveryService.Models;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryService.Interfaces
{
     public  interface IStoreContext
    {
        IList<Product> Products { get; set; }
        IList<Buyer> Buyers { get; set; }
        IList<Order> Orders { get; set; }
        void Save();
    }
}
