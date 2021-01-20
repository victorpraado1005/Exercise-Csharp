using Exercicio_Composicao.Entities.Enums;
using System;
using System.Globalization;
using System.Collections.Generic;
using System.Text;

namespace Exercicio_Composicao.Entities
{
    class Order
    {
        public DateTime Moment { get; set; }
        public OrderStatus Status { get; set; }
        public Client Client { get; set; }

        List<OrderItem> items = new List<OrderItem>();

        public Order()
        {
        }
        public Order(DateTime moment, OrderStatus status, Client client)
        {
            Moment = moment;
            Status = status;
            Client = client;
        }

        public void AddItem(OrderItem item)
        {
            items.Add(item);
        }

        public void RemoveItem(OrderItem item)
        {
            items.Remove(item);
        }

        public double total()
        {
            double sum = 0;
            foreach (OrderItem item in items)
            {
                sum += item.SubTotal();
            }
            return sum;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Order Moment: " + Moment.ToString("dd/MM/yyyy HH:mm:ss"));
            sb.AppendLine("Order Status: " + Status);
            sb.AppendLine("Client: " + Client);
            sb.AppendLine("Order items: ");
            foreach (OrderItem item in items)
            {
                sb.AppendLine(item.ToString());
            }
            sb.AppendLine("Total price: " + total().ToString("F2", CultureInfo.InvariantCulture));
            return sb.ToString();
        }
    }
}
