using System;

namespace OrderSystem_Server
{
	public interface IOrder
	{
		void Print();

		void AcceptOrderVisitor(IOrderVisitor Visitor);

	}
}
