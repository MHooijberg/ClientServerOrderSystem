using System;
using System.Security.Cryptography;
using System.Text;
using System.Threading;

namespace OrderSystem_Server
{
    class Program
    {
        static void Main(string[] args)
        {
            Server server = new Server();
            server.Start();
        }
    }
}
