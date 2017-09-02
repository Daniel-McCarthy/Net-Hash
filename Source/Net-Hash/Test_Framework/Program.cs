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


            Console.WriteLine("Testing MD2-Hash with string \"HelloKitty\"");
            Console.WriteLine(MD.md2_128Hash(stringToByteArray("HelloKitty")) + '\n');


            Console.WriteLine("Testing MD5-Hash with string \"HelloKitty\"");
            Console.WriteLine(MD.md5_128Hash(stringToByteArray("HelloKitty")));

            Console.WriteLine("Testing MD5-Hash with string \"HelloKitty\"");
            Console.WriteLine(MD.md5_128Hash(stringToByteArray("HelloKittyHelloKittyHelloKittyHelloKittyHelloKittyHelloKittyHelloKittyHelloKittyHelloKittyHelloKittyHelloKittyHelloKittyHelloKittyHelloKittyHelloKittyHelloKittyHelloKittyHelloKittyHelloKittyHelloKitty")) + '\n');


            /*
             * Timing Tests
             */ 


            byte[] dataTest1 = stringToByteArray("HelloKitty");
            byte[] dataTest2 = stringToByteArray("HelloKittyHelloKittyHelloKittyHelloKittyHelloKittyHelloKittyHelloKittyHelloKittyHelloKittyHelloKittyHelloKittyHelloKittyHelloKittyHelloKittyHelloKittyHelloKittyHelloKittyHelloKittyHelloKittyHelloKitty");

            Stopwatch timer;
            
            timer = Stopwatch.StartNew();
            FNV.fnv1_32Hash(dataTest1);
            timer.Stop();
            Console.WriteLine("FNV1 Hash took : " + timer.ElapsedTicks + " ticks");

            timer = Stopwatch.StartNew();
            FNV.fnv1A_32Hash(dataTest1);
            timer.Stop();
            Console.WriteLine("FNV1A Hash took : " + timer.ElapsedTicks + " ticks");

            timer = Stopwatch.StartNew();
            FNV.fnv0_32Hash(dataTest1);
            timer.Stop();
            Console.WriteLine("FNV0 Hash took : " + timer.ElapsedTicks + " ticks");

            timer = Stopwatch.StartNew();
            CRC.crc_32Hash(dataTest1);
            timer.Stop();
            Console.WriteLine("CRC32 Hash took : " + timer.ElapsedTicks + " ticks");

            timer = Stopwatch.StartNew();
            CRC.crcB_32Hash(dataTest1);
            timer.Stop();
            Console.WriteLine("CRC32B Hash took : " + timer.ElapsedTicks + " ticks");

            timer = Stopwatch.StartNew();
            Adler.adler_32Hash(dataTest1);
            timer.Stop();
            Console.WriteLine("Adler32 Hash took : " + timer.ElapsedTicks + " ticks");

            timer = Stopwatch.StartNew();
            MD.md5_128Hash(dataTest1);
            timer.Stop();
            Console.WriteLine("MD5 Hash took : " + timer.ElapsedTicks + " ticks");

            timer = Stopwatch.StartNew();
            MD.md5_128Hash(dataTest2);
            timer.Stop();
            Console.WriteLine("MD5 Hash Test2 took : " + timer.ElapsedTicks + " ticks");


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
