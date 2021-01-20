using Exercicio_Composicao.Entities;
using Exercicio_Composicao.Entities.Enums;
using System;
using System.Globalization;

namespace Exercicio_Composicao
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter client data: ");
            Console.Write("Name: ");
            string name = Console.ReadLine();
            Console.Write("Email: ");
            string email = Console.ReadLine();
            Console.Write("Birth date: ");
            DateTime birthdate = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("Enter order data: ");
            Console.Write("Status: ");
            OrderStatus status = Enum.Parse<OrderStatus>(Console.ReadLine());
            DateTime orderMoment = DateTime.Now;

            Client client = new Client(name, email, birthdate);
            Order order = new Order(orderMoment, status, client);

            Console.Write("How many items to this order? ");
            int n = int.Parse(Console.ReadLine());

            for (int i = 1; i <= n; i++)
            {
                Console.WriteLine("Enter #" + i + " item data: ");
                Console.Write("Product name: ");
                string itemName = Console.ReadLine();
                Console.Write("Product price: ");
                double itemPrice = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                Console.Write("Quantity: ");
                int itemQuantity = int.Parse(Console.ReadLine());

                Product product = new Product(itemName, itemPrice);
                OrderItem item = new OrderItem(itemQuantity, itemPrice, product);
                order.AddItem(item);
            }

            Console.WriteLine("ORDER SUMMARY: ");
            Console.WriteLine(order);
        }
    }
}
