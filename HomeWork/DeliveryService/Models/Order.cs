using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryService.Models
{
    public class Order : GoodsId
    {
        public int BuyerId { get; set; }
        public IList<Product> Products { get; set; }
        public AdressDelivery AdressDelivery { get; set; }
        public Order()
        {
            Products = new List<Product>();
        }
    }
}
