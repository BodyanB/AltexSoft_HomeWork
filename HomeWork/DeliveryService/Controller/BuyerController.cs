using DeliveryService.Data;
using DeliveryService.Models;
using System;
using System.Linq;

namespace DeliveryService.Controller
{
    public class BuyerController
    {
        protected readonly Buyer buyer;
        protected readonly Context context;

        public BuyerController(Buyer buyer, Context context)
        {
            this.buyer = buyer;
            this.context = context;
        }

        public void ShowAllProducts()
        {
            foreach (var item in context.Products)
            {
                Console.WriteLine($"{item.Id}. {item.Name} Price {item.Price}");
            }
        }

        public void CreateOrder()
        {
            var order = new Order();
            order.Id = context.Orders.Count + 1;
            order.BuyerId = 1;
            Console.WriteLine("Choose a product");
            ShowAllProducts();
            int userChoise;
            while (!int.TryParse(Console.ReadLine(), out userChoise))
            {
                Console.Write("Incorrect input, enter number: ");
            }
            var selectedProduct = context.Products.ElementAt(userChoise - 1);

            order.Products.Add(selectedProduct);
            order.AdressDelivery = new AdressDelivery();
            Console.WriteLine("Please provide the shipping address");
            Console.WriteLine("Enter house number");
            order.AdressDelivery.HouseNumber = Console.ReadLine();
            Console.WriteLine("Enter street name");
            order.AdressDelivery.StreetName = Console.ReadLine();
            Console.WriteLine("Enter apartment number");
            order.AdressDelivery.ApartmentNumber = Console.ReadLine();
            Console.WriteLine("Enter city name");
            order.AdressDelivery.CityName = Console.ReadLine();
            Console.WriteLine("Enter area name");
            order.AdressDelivery.PostCode = Console.ReadLine();

            order.AdressDelivery.Id = context.DeliveryAddresses.Count + 1;
            order.AdressDelivery.BuyerId = 1;
            context.Orders.Add(order);
            context.DeliveryAddresses.Add(order.AdressDelivery);
            context.Save();
        }
    }
}