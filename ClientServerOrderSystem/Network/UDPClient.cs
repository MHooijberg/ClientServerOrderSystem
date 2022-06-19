using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace OrderSystem_Client.Network
{
    public class UDPClient : IListener
    {
        private UTF8Encoding utf8 = new();
        private UdpClient udpClient;
        private IPEndPoint groupEp;
        private Socket socket;

        public UDPClient(string adress, int port)
        {
            utf8 = new UTF8Encoding();
            udpClient = new UdpClient(8081);
            groupEp = new IPEndPoint(IPAddress.Parse(adress), port);
            socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
        }
        public byte[] Receive()
        {
            byte[] data = null;
            try
            {
                data = udpClient.Receive(ref groupEp);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return data;
        }

        public void Send(byte[] Data)
        {
            socket.SendTo(Data, groupEp);
        }
    }
}
