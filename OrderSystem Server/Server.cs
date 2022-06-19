using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace OrderSystem_Server
{
    class Server
    {
        private ServerSocket _socket;
        private OrderDirectory _orders;
        public Server()
        {
            _socket = ServerSocket.GetInstance(true);
            _orders = new OrderDirectory();
        }

        public void Start()
        {
            while (true)
            {
                List<string> request = _socket.Receive();
                //Console.WriteLine("Data received: {0}", request);
                OrderDetails incomingOrder = JsonSerializer.Deserialize<OrderDetails>(request[1]);
                if (Authenticate.Authorize(request[0]))          
                    _orders.Add(incomingOrder);
                Console.Clear();
                Console.WriteLine("==== Here follow the current Orders: ====");
                _orders.Print();
            }
        }
    }
}