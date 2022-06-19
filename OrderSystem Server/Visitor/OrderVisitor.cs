using System;

namespace OrderSystem_Server
{
	public interface IOrderVisitor
	{
		void VisitOrderDetails(OrderDetails OrderDetails);

		void VisitOrderDirectory(OrderDirectory OrderDirectory);
	}
}

