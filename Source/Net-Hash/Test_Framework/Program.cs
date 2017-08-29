using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FNV_Hash;

namespace Test_Framework
{
    class Program
    {
        static void Main(string[] args)
        {

        }

        static byte[] stringToByteArray(string message)
        {
            byte[] returnArray = new byte[message.Length];

            for (int i = 0; i < message.Length; i++)
            {
                returnArray[i] = (byte)message[i];
            }

            return returnArray;
        }
    }
}
