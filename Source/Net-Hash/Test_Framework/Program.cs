using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FNV_Hash;
using CRC_Hash;

namespace Test_Framework
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Testing FNV1-Hash with string \"HelloKitty\"");
            Console.WriteLine(FNV.fnv132Hash(stringToByteArray("HelloKitty")));

            Console.WriteLine("Testing FNV1A-Hash with string \"HelloKitty\"");
            Console.WriteLine(FNV.fnv1A32Hash(stringToByteArray("HelloKitty")));

            Console.WriteLine("Testing FNV0-Hash with string \"HelloKitty\"");
            Console.WriteLine(FNV.fnv032Hash(stringToByteArray("HelloKitty" + '\n')));




            Console.ReadKey();
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
