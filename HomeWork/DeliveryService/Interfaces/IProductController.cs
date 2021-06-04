using System;
using DeliveryService.Models;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace DeliveryService.Interfaces
{
    interface IProductController
    {
        IList<Product> GetProducts();
        void AddProduct(Product product);
    }
}
