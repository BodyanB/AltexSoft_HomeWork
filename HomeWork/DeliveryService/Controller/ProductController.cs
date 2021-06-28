using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeliveryService.Interfaces;
using DeliveryService.Models;

namespace DeliveryService.Controller
{
    public class ProductController : IProductController
    {
        private readonly IStoreContext _storeContext;
        private readonly ILogger _logger;

        public ProductController(IStoreContext storeContext, ILogger logger)
        {
            _storeContext = storeContext;
            _logger = logger;
        }

        public void AddProduct(Product product)
        {
            product.Id = _storeContext.Products.Count > 0 ? _storeContext.Products.Max(x => x.Id) + 1 : 1;

            _storeContext.Products.Add(product);
            if (_storeContext.Buyers is not null)
            {  
                _logger.Log($"Пользователи добавили новый товар ({product.Name})");
            }
           
        }

        public IList<Product> GetProducts()
        {
            return _storeContext.Products;
        }
    }
}
