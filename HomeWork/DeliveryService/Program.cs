using System;
using System.Collections.Generic;
using DeliveryService.Controller;
using DeliveryService.Data;
using DeliveryService.Models;
namespace DeliveryService
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello in Service!");

   
            var context = new StoreContext();
            var productController = new ProductController(context);
            var buyerController = new BuyerController(context);
            var orderController = new OrderController(context);

            productController.AddProduct(new Product("Продукты", "Описание", 1, "Продавец"));
            productController.AddProduct(new Product("Услуги", "Описание", 2, "Продавец"));
            productController.AddProduct(new Product("Одежда", "Описание", 3, "Продавец"));

            var presenter = new Presenter(productController, buyerController, orderController);
            presenter.ShowMenu();
            
        }
    }
}
