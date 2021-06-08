using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeliveryService.Controller;
using DeliveryService.Interfaces;
using DeliveryService.Models;
using DeliveryService.Expansion;

namespace DeliveryService
{
     public class Presenter : IPresenter
    {
        private readonly IProductController productController;
        private readonly IBuyerController buyerController;
        private readonly IOrderController orderController;

        public Presenter(IProductController productController, IBuyerController buyerController, IOrderController orderController)
        {
            this.productController = productController;
            this.buyerController = buyerController;
            this.orderController = orderController;
        }

        public void ShowMenu()
        {
            bool end = false;
            while (!end)
            {
                Console.WriteLine("\r\nDeliveryService");
                Console.WriteLine("Введите 1, чтобы войти как покупатель");
                Console.WriteLine("Введите 2, чтобы войти как продавец");
                Console.WriteLine("Введите 3, чтобы выйти");
                int.TryParse(Console.ReadLine(), out var number);

                switch (number)
                {
                    case 1:
                        MakeOrder();
                        break;
                    case 2:
                        CreateProduct();
                        break;
                    case 3:
                        end = true;
                        break;
                    default:
                        Console.WriteLine("Нужно ввести число от 1 до 3");
                        break;
                }
            }
        }

        public void MakeOrder()
        {
            bool goToOrder = false;
            var productsToOrder = new List<Product>();
            while (!goToOrder)
            {
                Console.WriteLine("Список товаров:");
                var products = productController.GetProducts();
                Console.WriteLine("Имя | Описание | Цена | Продавец");
                foreach (var product in products)
                {
                    Console.WriteLine($"{product.Name} | {product.Description} | {product.Price} | {product.Seller}");
                }
                var productsToOrderCount = 0;
                while (productsToOrderCount < 1)
                {
                    Console.WriteLine("Введите имя товара, который хотите заказать");
                    var inputProductName = Console.ReadLine();
                    foreach (var product1 in products)
                    {
                        if (product1.Name == inputProductName)
                        {
                            productsToOrder.Add(product1);
                            productsToOrderCount += 1;
                        }
                    }
                    if (productsToOrderCount < 1)
                    {
                        Console.WriteLine("Не удалось найти товар с таким именем, попробуйте еще раз");
                    }
                }
                Console.WriteLine("Введите 1, чтобы перейти к оформлению заказа");
                Console.WriteLine("Или введите любой другой символ, чтобы добавить в заказ другие товары");
                int.TryParse(Console.ReadLine(), out var number);
                if (number == 1)
                {
                    goToOrder = true;
                }
            }
            Console.WriteLine("Для оформления заказа  введите адресс доставки, свой email и номер телефона.");

            RegisterUser();
            string inputAdress;
            while (true)
            {
                Console.WriteLine("Введите адрес доставки:");
                inputAdress = Console.ReadLine();
                if (inputAdress.IsAddress())
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Адрес не соответствует формату. Введите еще раз.");
                    Console.WriteLine("Пример: улица Серебряная, д.23, кв.89");
                }
            }
            var order = new Order(inputAdress, productsToOrder);
            orderController.AddOrder(order);
            Console.WriteLine("Заказ успешно сделан!");
        }

        public void RegisterUser()
        {
            string email;
            string phoneNumber;
            while (true)
            {
                Console.WriteLine("Введите ваш Email:");
                email = Console.ReadLine();
                if (email.IsEmail())
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Email не соответствует формату. Введите еще раз.");
                    Console.WriteLine("Пример: example@gmail.com");
                }
            }
            Console.WriteLine("Введите ваше имя:");
            var name = Console.ReadLine();
            while (true)
            {
                Console.WriteLine("Введите ваш номер телефона:");
                phoneNumber = Console.ReadLine();
                if (phoneNumber.IsPhoneNumber())
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Номер телефона не соответствует формату. Попробуйте еще раз.");
                    Console.WriteLine("Пример: +380952223388");
                }
            }
            var buyer = new Buyer(email, name, phoneNumber);
            buyerController.AddBuyer(buyer);
        }

        public void CreateProduct()
        {
            Console.WriteLine("Добавление нового продукта");
            Console.WriteLine("Введите название продукта:");
            var productName = Console.ReadLine();
            Console.WriteLine("Введите описание продукта:");
            var productDescription = Console.ReadLine();
            Console.WriteLine("Введите цену продукта:");
            var productPrice = Convert.ToDecimal(Console.ReadLine());
            var newProduct = new Product(productName, productDescription, productPrice, "SellerName");
            productController.AddProduct(newProduct);
            Console.WriteLine("Товар успешно добавлен!");
        }
    }
}
