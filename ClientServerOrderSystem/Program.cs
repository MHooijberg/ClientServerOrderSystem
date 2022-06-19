using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading;

namespace OrderSystem_Client
{
    class Program
    {
        static void Main(string[] args)
        {
            ClientSocket socket = ClientSocket.GetInstance(true);
            Console.Write("Server Password: ");
            string password = Console.ReadLine();
            while (true)
            {
                Console.WriteLine("==== New Order ====");
                Console.Write("Name: ");
                string name = Console.ReadLine();
                Console.Write("Adress: ");
                string addres = Console.ReadLine();
                Console.Write("City: ");
                string city = Console.ReadLine();
                Console.Write("Pizza Name: ");
                string pizzaName = Console.ReadLine();
                Console.Write("Pizza Amount: ");
                int pizzaAmount = Convert.ToInt32(Console.ReadLine());
                Console.Write("Topping Amount: ");
                int toppingsAmount = Convert.ToInt32(Console.ReadLine());
                List<string> toppings = new List<string>();
                if (Convert.ToInt16(toppingsAmount) > 0) {
                    string toppingsInput = null;
                    Console.WriteLine("(Type 'continue' to go to the next field.)");
                    for (int i = 0; i < toppingsAmount; i++)
                    {
                        Console.Write("     Topping {0}: ", toppings.Count);
                        toppingsInput = Console.ReadLine();
                        toppings.Add(toppingsInput);
                    }
                }
                DateTime date = DateTime.Now;

                OrderDetails order = new OrderDetails(name, addres, city, pizzaName, pizzaAmount, toppingsAmount, toppings.ToArray(), date);
                string jsonString = JsonSerializer.Serialize<OrderDetails>(order);
                Console.WriteLine("Order Confirmation: " + jsonString);
                Console.WriteLine("Sending Order Now!");
                if (String.IsNullOrEmpty(password))
                    password = "ZG9nZ28K";
                socket.Send(password + ";" + jsonString);
            }
        }
    }
}
