using System;

namespace OrderSystem_Client
{
	public class OrderDetails
	{
		public string CustomerName { get; }

		public string Adress { get; }

		public string City { get; }

		public string PizzaName { get; }

		public int PizzaAmount { get; }

		public int ToppingAmount { get; }

		public string[] Toppings { get; }

		public DateTime Date { get; }

		public OrderDetails(string customerName, string adress, string city, string pizzaName, int pizzaAmount, int toppingAmount, string[] toppings, DateTime date)
		{
			Adress = adress;
			City = city;
			CustomerName = customerName;
			Date = date;
			PizzaAmount = pizzaAmount;
			PizzaName = pizzaName;
			ToppingAmount = toppingAmount;
			Toppings = toppings;
		}

		public void Print()
		{
			Console.WriteLine($"Date: {Date}\n" +
				$"Customer Name: {CustomerName}\n" +
				$"Adress: {Adress}, {City}\n" +
				$"Pizza: {PizzaName}\n" +
				$"# of pizzas: {PizzaAmount}\n" +
				$"# of toppings: {ToppingAmount}\n" +
				$"Toppings:");
			foreach (string topping in Toppings)
			{
				Console.WriteLine($"    - {topping}");
			}
		}
	}
}