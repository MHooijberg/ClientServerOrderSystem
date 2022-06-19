using System;
using System.Collections.Generic;

namespace OrderSystem_Server
{
	public class OrderDirectory : IOrder
	{
		private readonly List<OrderDetails> _orders;

		public OrderDirectory()
        {
			_orders = new List<OrderDetails>();
        }

		public void Print()
		{
            for (int i = 0; i < _orders.Count; i++)
            {
				Console.WriteLine($"==== Order {i} ====");
				_orders[i].Print();
				Console.WriteLine($"==== End of Order ====");
            }
		}

		public void Add(OrderDetails Order)
		{
			_orders.Add(Order);
		}

		public void Remove(OrderDetails Order)
		{
			_orders.Remove(Order);
		}

		public List<OrderDetails> GetChildren()
		{
			return _orders;
		}

		public void AcceptOrderVisitor(IOrderVisitor Visitor) {
			Visitor.VisitOrderDirectory(this);
		}
	}
}