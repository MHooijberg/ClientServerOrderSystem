using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace OrderSystem_Server.Network
{
    public class TCPServer : IListener
    {
        private UTF8Encoding utf8 = new();
        private TcpListener listener = null;
        private TcpClient tcpClient = null;
        private NetworkStream stream = null;
        String data = null;

        public TCPServer(string adress, int port)
        {
            listener = new TcpListener(IPAddress.Parse(adress), port);
            listener.Start();
        }

        public byte[] Receive()
        {
            //byte[] data = new byte[];
            byte[] bytes = new byte[256];
            try
            {
                if (tcpClient == null)
                    tcpClient = listener.AcceptTcpClient();
                if (stream == null)
                    stream = tcpClient.GetStream();
                stream.Read(bytes, 0, bytes.Length);
                //data = null;
                //int i;
                //while ((i = stream.Read(bytes, 0, bytes.Length)) != 0)
                //{
                //    data = System.Text.Encoding.ASCII.GetString(bytes, 0, i);
                //}
                //data = System.Text.Encoding.ASCII.GetString(bytes, 0, bytes.Length);
                //Console.WriteLine("Received: {0}\n== end\n", data);
                return bytes;
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
            }
            return bytes;
        }

        public void Send(byte[] Data)
        {
            if (stream != null)
            {
                stream.Write(Data, 0, Data.Length);
            }            
        }

    }
}
