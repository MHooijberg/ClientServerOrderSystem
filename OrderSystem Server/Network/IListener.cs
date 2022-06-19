using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderSystem_Server.Network
{
    interface IListener
    {
        void Send(byte[] Data);
        byte[] Receive();
    }
}
