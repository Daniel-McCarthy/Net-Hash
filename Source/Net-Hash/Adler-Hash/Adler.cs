using System;

namespace Adler_Hash
{
    public class Adler
    {
        public static string adler_32Hash(byte[] message)
        {
            UInt32 a = 1;
            UInt32 b = 0;
            UInt32 c = 0;

            for(int i = 0; i < message.Length; i++)
            {
                c = a;
                a = (a + message[i]) % 65521;
                b = (b + message[i] + c) % 65521;
            }

            UInt64 hash = (UInt64)(b * 0x10000 + a);

            return hash.ToString("X8");
        }

    }
}
