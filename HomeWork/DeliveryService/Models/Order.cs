using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryService.Models
{
    public class Order : BaseModel
    {
        public int BuyerId { get; set; }
        public IList<Product> Products { get; set; }
        public decimal Price { get; set; }
        public string Address { get; set; }

        public Order(string address, List<Product> products)
        {
            Products = products;
            Address = address;
        }
    }
}
