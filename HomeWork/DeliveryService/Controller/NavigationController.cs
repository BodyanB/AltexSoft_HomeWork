using DeliveryService.Data;
using DeliveryService.Models;
using System;

namespace DeliveryService.Controller
{
    public class NavigationController
    {
        private readonly Context context;
        private IUser user;

        public NavigationController()
        {
            context = new Context();
        }

        private IUser SelectUser(string selectedUser)
        {
            return selectedUser switch
            {
                "1" => user = new Buyer(),
                "2" => user = new Seller(),
                _ => user = null,
            };
        }

        public void RunMenu()
        {
            Console.WriteLine("Hello, select user\n1. Buyer\n2. Seller");
            var selectedUser = Console.ReadLine();

            var currentUser = SelectUser(selectedUser);

            switch (currentUser)
            {
                case Buyer:
                    RunBuyersScript();
                    break;

                case Seller:
                    RunSellersScript();
                    break;

                default:
                    Console.WriteLine("Incorrect input");
                    break;
            }
        }

        public void RunBuyersScript()
        {
            var buyerController = new BuyerController((Buyer)user, context);
            Console.Clear();
            Console.WriteLine("1. View product list\n2. Create order.");
            var userChoice = Console.ReadLine();
            if (userChoice == "1")
            {
                buyerController.ShowAllProducts();
            }
            if (userChoice == "2")
            {
                buyerController.CreateOrder();
            }
        }

        public void RunSellersScript()
        {
            var sellerController = new SellerController((Seller)user, context);
            Console.Clear();
            Console.WriteLine("1. View product list.\n2. Add your product.");
            var userChoice = Console.ReadLine();
            if (userChoice == "1")
            {
                foreach (var item in sellerController.GetProducts())
                {
                    Console.WriteLine($"{item.Id} {item.Name}");
                }
            }
            if (userChoice == "2")
            {
                sellerController.PostProduct();
            }
        }

      
    }
}