using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderSystem_Server
{
    class Authenticate
    {
        public static bool Authorize(string Key)
        {
            if (Key == "ZG9nZ28K")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
