using System;
using System.Collections;
using System.Net;
using System.Net.Sockets;
using System.Net.Security;
using System.Security.Authentication;
using System.Text;
using System.Security.Cryptography.X509Certificates;
using System.IO;
using OrderSystem_Client.Network;
using System.Linq;
using System.Collections.Generic;

namespace OrderSystem_Client
{
	public class ClientSocket
	{
		protected static ClientSocket _instance = null;
		//		protected static readonly object codeLock = new();

		private readonly int _port = 8080;
		private readonly string _RemoteAddres = "127.0.0.1";
		private IListener _client;
		private SecureChannel _channel;

		private ClientSocket(bool IsTCP)
		{
			_channel = new SecureChannel();
			if (IsTCP)
				_client = new TCPClient(_RemoteAddres, _port);
			else
				_client = new UDPClient(_RemoteAddres, _port); ;
		}

		public static ClientSocket GetInstance(bool IsTCP)
		{
			if (_instance == null)
			{
				_instance = new ClientSocket(IsTCP);
				// The following code is the replacement if the class should have a thread-safe instance.
				// In other words it'll make sure that there's only one instance over multiple threads.
				//					lock (codeLock)
				//                    {
				//						if (_instance == null)
				//                        {
				//							_instance = new ServerSocket();
				//                        }
				//
				//                    }
			}
			return _instance;
		}

		public List<string> Receive() {
			byte[] incomingData = _client.Receive();
			List<string> data = _channel.Decrypt(incomingData).Split(';').ToList();
			data.RemoveAt(data.Count - 1);
			return data;
		}
		public void Send(string Message) {
			_client.Send(_channel.Encrypt(Message + ";"));
		}
	}
}