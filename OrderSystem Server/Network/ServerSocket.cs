using System;
using System.Collections;
using System.Net;
using System.Net.Sockets;
using System.Net.Security;
using System.Security.Authentication;
using System.Text;
using System.Security.Cryptography.X509Certificates;
using System.IO;
using OrderSystem_Server.Network;
using System.Collections.Generic;
using System.Linq;

namespace OrderSystem_Server
{
	public class ServerSocket
	{
		protected static ServerSocket _instance = null;
		//		protected static readonly object codeLock = new();

		private readonly int _port = 8080;
		private readonly string _localAddres = "127.0.0.1";
		private IListener _listener;
		private SecureChannel _channel;

		private ServerSocket(bool IsTCP)
		{
			_channel = new SecureChannel();
			if (IsTCP)
				_listener = new TCPServer(_localAddres, _port);
			else
				_listener = new UDPServer(_localAddres, _port); ;
		}

		public static ServerSocket GetInstance(bool IsTCP)
		{
			if (_instance == null)
			{
				_instance = new ServerSocket(IsTCP);
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
			byte[] incomingData = _listener.Receive();
			List<string> data = _channel.Decrypt(incomingData).Split(';').ToList();
			data.RemoveAt(data.Count - 1);
			return data;
		}
		public void Send(string Message) {
			byte[] data = _channel.Encrypt(Message);
			_listener.Send(data);
		}
	}
}