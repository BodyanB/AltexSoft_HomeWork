using System;
using System.Collections.Generic;
using DeliveryService.Controller;
using DeliveryService.Data;
using DeliveryService.Models;
using DeliveryService.Loggers;

namespace DeliveryService
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello in Service!");

   
            var context = new StoreContext();
            var logger = new Logger();
            var productController = new ProductController(context, logger);
            var buyerController = new BuyerController(context, logger);
            var orderController = new OrderController(context, logger);
            
            productController.AddProduct(new Product("Продукты", "Описание", 1, "Продавец"));
            productController.AddProduct(new Product("Услуги", "Описание", 2, "Продавец"));
            productController.AddProduct(new Product("Одежда", "Описание", 3, "Продавец"));

            var presenter = new Presenter(productController, buyerController, orderController);
            presenter.ShowMenu();
            
        }
    }
}
