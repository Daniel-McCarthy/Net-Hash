using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FNV_Hash;
using CRC_Hash;
using Adler_Hash;
using MD_Hash;


namespace Test_Framework
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Testing FNV1-Hash with string \"HelloKitty\"");
            Console.WriteLine(FNV.fnv1_32Hash(stringToByteArray("HelloKitty")));

            Console.WriteLine("Testing FNV1A-Hash with string \"HelloKitty\"");
            Console.WriteLine(FNV.fnv1A_32Hash(stringToByteArray("HelloKitty")));

            Console.WriteLine("Testing FNV0-Hash with string \"HelloKitty\"");
            Console.WriteLine(FNV.fnv0_32Hash(stringToByteArray("HelloKitty")) + '\n');


            Console.WriteLine("Testing CRC-Hash with string \"HelloKitty\"");
            Console.WriteLine(CRC.crc_32Hash(stringToByteArray("HelloKitty")));

            Console.WriteLine("Testing CRC-Hash with string \"HelloKitty\"");
            Console.WriteLine(CRC.crcB_32Hash(stringToByteArray("HelloKitty")) + '\n');


            Console.WriteLine("Testing Adler-Hash with string \"HelloKitty\"");
            Console.WriteLine(Adler.adler_32Hash(stringToByteArray("HelloKitty")) + '\n');

            Console.WriteLine("Testing MD5-Hash with string \"HelloKitty\"");
            Console.WriteLine(MD.md5_128Hash(stringToByteArray("HelloKitty")));

            Console.WriteLine("Testing MD5-Hash with string \"HelloKitty\"");
            Console.WriteLine(MD.md5_128Hash(stringToByteArray("HelloKittyHelloKittyHelloKittyHelloKittyHelloKittyHelloKittyHelloKittyHelloKittyHelloKittyHelloKittyHelloKittyHelloKittyHelloKittyHelloKittyHelloKittyHelloKittyHelloKittyHelloKittyHelloKittyHelloKitty")) + '\n');

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
