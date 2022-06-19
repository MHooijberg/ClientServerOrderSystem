using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace OrderSystem_Client.Network
{
    public class TCPClient : IListener
    {
        private UTF8Encoding utf8 = new();
        private TcpClient tcpClient = null;
        private NetworkStream stream = null;

        public TCPClient(string adress, int port)
        {
            tcpClient = new TcpClient(adress, port);
            stream = tcpClient.GetStream();
        }

        public byte[] Receive()
        {
            byte[] data = new byte[256];
            try
            {
                stream.Read(data, 0, data.Length);
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
            }
            return data;
        }

        public void Send(byte[] Data)
        {
            if (stream != null)
            {
                stream.Write(Data, 0, Data.Length);
            }
            else
            {
                Console.WriteLine("Stream was null");
            }
        }

    }
}
