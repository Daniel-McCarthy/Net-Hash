using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

using FNV_Hash;
using CRC_Hash;
using Adler_Hash;
using MD_Hash;
using SHA_Hash;


namespace Console_Frontend
{
    class Program
    {
        static void Main(string[] args)
        {
            string keyInput = "";
            bool exit       = false;

            while (!exit)
            {

                Console.WriteLine("\n\nPlease enter the text you would like to hash:");
                string input = Console.ReadLine();

                Console.WriteLine("\nOutput:");

                testCustomInput(input);


                // Check if user wishes to test with custom input again.
                Console.WriteLine("\n\nPress 0 to input text to be hashed again.");
                Console.WriteLine("Enter anything else to exit.");

                keyInput = Console.ReadKey().KeyChar.ToString();

                if(keyInput != "0")
                {
                    exit = true;
                }
            }

            Console.ReadKey();
        }

        static void testCustomInput(string input)
        {
            Console.WriteLine("Testing FNV1-Hash with string \"" + input + "\"");
            Console.WriteLine(FNV.fnv1_32Hash(stringToByteArray(input)));

            Console.WriteLine("Testing FNV1A-Hash with string \"" + input + "\"");
            Console.WriteLine(FNV.fnv1A_32Hash(stringToByteArray(input)));

            Console.WriteLine("Testing FNV0-Hash with string \"" + input + "\"");
            Console.WriteLine(FNV.fnv0_32Hash(stringToByteArray(input)) + '\n');

            Console.WriteLine("Testing CRC-Hash with string \"" + input + "\"");
            Console.WriteLine(CRC.crc_32Hash(stringToByteArray(input)));

            Console.WriteLine("Testing CRC-Hash with string \"" + input + "\"");
            Console.WriteLine(CRC.crcB_32Hash(stringToByteArray(input)) + '\n');

            Console.WriteLine("Testing Adler-Hash with string \"" + input + "\"");
            Console.WriteLine(Adler.adler_32Hash(stringToByteArray(input)) + '\n');

            Console.WriteLine("Testing MD2-Hash with string \"" + input + "\"");
            Console.WriteLine(MD.md2_128Hash(stringToByteArray(input)));

            Console.WriteLine("Testing MD4-Hash with string \"" + input + "\"");
            Console.WriteLine(MD.md4_128Hash(stringToByteArray(input)));

            Console.WriteLine("Testing MD5-Hash with string \"" + input + "\"");
            Console.WriteLine(MD.md5_128Hash(stringToByteArray(input)));

            Console.WriteLine("Testing SHA0-Hash with string \"" + input + "\"");
            Console.WriteLine(SHA.sha0_160Hash(stringToByteArray(input)) + '\n');

            Console.WriteLine("Testing SHA1-Hash with string \"" + input + "\"");
            Console.WriteLine(SHA.sha1_160Hash(stringToByteArray(input)) + '\n');

            Console.WriteLine("Testing SHA2-Hash with string \"" + input + "\"");
            Console.WriteLine(SHA.sha2_224Hash(stringToByteArray(input)));
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
