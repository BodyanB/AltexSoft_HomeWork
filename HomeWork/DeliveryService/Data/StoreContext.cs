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
        private readonly IFileManager _fileManager;
        public IList<Product> Products { get; set; }
        public IList<Buyer> Buyers { get; set; }
        public IList<Order> Orders { get; set; }

      

        public StoreContext(IFileManager fileManager)
        {
            _fileManager = fileManager;
            Products = _fileManager.LoadFromFile<Product>("Products.json");
            Buyers = _fileManager.LoadFromFile<Buyer>("Buyer.json");
            Orders = _fileManager.LoadFromFile<Order>("Orders.json");
        }
        public void Save()
        {
            _fileManager.SaveToFile(Products, "Products.json");
            _fileManager.SaveToFile(Buyers, "Buyer.json");
            _fileManager.SaveToFile(Orders, "Orders.json");
        }


    }
}