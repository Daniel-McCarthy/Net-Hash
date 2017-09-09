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
            Console.WriteLine(MD.md2_128Hash(stringToByteArray("HelloKitty")));

            Console.WriteLine("Testing MD2-Hash with string \"HelloKitty\"x21");
            Console.WriteLine(MD.md2_128Hash(stringToByteArray("HelloKittyHelloKittyHelloKittyHelloKittyHelloKittyHelloKittyHelloKittyHelloKittyHelloKittyHelloKittyHelloKittyHelloKittyHelloKittyHelloKittyHelloKittyHelloKittyHelloKittyHelloKittyHelloKittyHelloKitty")) +'\n');

            Console.WriteLine("Testing MD4-Hash with string \"HelloKitty\"");
            Console.WriteLine(MD.md4_128Hash(stringToByteArray("HelloKitty")));


            /*
             * Tests MD4 with string length 64-9
             */
            Console.WriteLine("Testing MD4-Hash with string \"HelloKittyHelloKittyHelloKittyHelloKittyHelloKittyHello\"");
            Console.WriteLine(MD.md4_128Hash(stringToByteArray("HelloKittyHelloKittyHelloKittyHelloKittyHelloKittyHello")));

            /*
             * Tests MD4 with string length 63
             */
            Console.WriteLine("Testing MD4-Hash with string \"HelloKittyHelloKittyHelloKittyHelloKittyHelloKittyHelloKittyHel\"");
            Console.WriteLine(MD.md4_128Hash(stringToByteArray("HelloKittyHelloKittyHelloKittyHelloKittyHelloKittyHelloKittyHel")) + '\n');


            Console.WriteLine("Testing MD5-Hash with string \"HelloKitty\"");
            Console.WriteLine(MD.md5_128Hash(stringToByteArray("HelloKitty")));

            Console.WriteLine("Testing MD5-Hash with string \"HelloKitty\"x21");
            Console.WriteLine(MD.md5_128Hash(stringToByteArray("HelloKittyHelloKittyHelloKittyHelloKittyHelloKittyHelloKittyHelloKittyHelloKittyHelloKittyHelloKittyHelloKittyHelloKittyHelloKittyHelloKittyHelloKittyHelloKittyHelloKittyHelloKittyHelloKittyHelloKitty")));

            Console.WriteLine("Testing MD5-Hash with string \"\"");
            Console.WriteLine(MD.md5_128Hash(stringToByteArray("")) + '\n');

            Console.WriteLine("Testing SHA0-Hash with string \"HelloKitty\"");
            Console.WriteLine(SHA.sha0_160Hash(stringToByteArray("HelloKitty")) + '\n');

            Console.WriteLine("Testing SHA1-Hash with string \"HelloKitty\"");
            Console.WriteLine(SHA.sha1_160Hash(stringToByteArray("HelloKitty")) + '\n');

            Console.WriteLine("Testing SHA2-Hash with string \"HelloKitty\"");
            Console.WriteLine(SHA.sha2_224Hash(stringToByteArray("HelloKitty")));

            Console.WriteLine("Testing SHA2-Hash with string \"HelloKitty\"x21");
            Console.WriteLine(SHA.sha2_224Hash(stringToByteArray("HelloKittyHelloKittyHelloKittyHelloKittyHelloKittyHelloKittyHelloKittyHelloKittyHelloKittyHelloKittyHelloKittyHelloKittyHelloKittyHelloKittyHelloKittyHelloKittyHelloKittyHelloKittyHelloKittyHelloKitty")) + '\n');

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
            MD.md2_128Hash(dataTest1);
            timer.Stop();
            Console.WriteLine("MD2 Hash took : " + timer.ElapsedTicks + " ticks");

            timer = Stopwatch.StartNew();
            MD.md2_128Hash(dataTest2);
            timer.Stop();
            Console.WriteLine("MD2 Hash Test 2 took : " + timer.ElapsedTicks + " ticks");

            timer = Stopwatch.StartNew();
            MD.md4_128Hash(dataTest1);
            timer.Stop();
            Console.WriteLine("MD4 Hash took : " + timer.ElapsedTicks + " ticks");

            timer = Stopwatch.StartNew();
            MD.md4_128Hash(dataTest2);
            timer.Stop();
            Console.WriteLine("MD4 Hash Test2 took : " + timer.ElapsedTicks + " ticks");


            timer = Stopwatch.StartNew();
            MD.md5_128Hash(dataTest1);
            timer.Stop();
            Console.WriteLine("MD5 Hash took : " + timer.ElapsedTicks + " ticks");

            timer = Stopwatch.StartNew();
            MD.md5_128Hash(dataTest2);
            timer.Stop();
            Console.WriteLine("MD5 Hash Test2 took : " + timer.ElapsedTicks + " ticks");

            timer = Stopwatch.StartNew();
            SHA.sha0_160Hash(dataTest1);
            timer.Stop();
            Console.WriteLine("SHA0 Hashtook : " + timer.ElapsedTicks + " ticks");

            timer = Stopwatch.StartNew();
            SHA.sha0_160Hash(dataTest2);
            timer.Stop();
            Console.WriteLine("SHA0 Hash Test2 took : " + timer.ElapsedTicks + " ticks");

            timer = Stopwatch.StartNew();
            SHA.sha1_160Hash(dataTest1);
            timer.Stop();
            Console.WriteLine("SHA1 Hashtook : " + timer.ElapsedTicks + " ticks");

            timer = Stopwatch.StartNew();
            SHA.sha1_160Hash(dataTest2);
            timer.Stop();
            Console.WriteLine("SHA1 Hash Test2 took : " + timer.ElapsedTicks + " ticks");

            timer = Stopwatch.StartNew();
            SHA.sha2_224Hash(dataTest1);
            timer.Stop();
            Console.WriteLine("SHA2 Hashtook : " + timer.ElapsedTicks + " ticks");


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
