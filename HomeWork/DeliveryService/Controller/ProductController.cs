﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeliveryService.Interfaces;
using DeliveryService.Models;

namespace DeliveryService.Controller
{
    class ProductController : IProductController
    {
        private readonly IStoreContext storeContext;

        public ProductController(IStoreContext storeContext)
        {
            this.storeContext = storeContext;
        }

        public void AddProduct(Product product)
        {
            product.Id = storeContext.Products.Count > 0 ? storeContext.Products.Max(x => x.Id) + 1 : 1;

            storeContext.Products.Add(product);
        }

        public IList<Product> GetProducts()
        {
            return storeContext.Products;
        }
    }
}
