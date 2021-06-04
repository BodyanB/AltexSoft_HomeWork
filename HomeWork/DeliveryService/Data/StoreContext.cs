using DeliveryService.Interfaces;
using DeliveryService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryService.Data
{
    public class StoreContext : IStoreContext
    {
        public IList<Product> Products { get; set; }
        public IList<Buyer> Buyers { get; set; }
        public IList<Order> Orders { get; set; }

      

        public StoreContext()
        {
            Products = new List<Product>();
            Buyers = new List<Buyer>();
            Orders = new List<Order>();
        }


        
    }
}