using System;
using DeliveryService.Controller;
using DeliveryService.Models;

namespace DeliveryService
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello in Service!");
            var navigationController = new NavigationController();

            navigationController.RunMenu();
        }
    }
}
