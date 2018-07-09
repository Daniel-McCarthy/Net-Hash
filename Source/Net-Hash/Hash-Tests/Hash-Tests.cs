using System;
using Xunit;

using FNV_Hash;
using CRC_Hash;
using Adler_Hash;
using MD_Hash;
using SHA_Hash;

namespace Hash_Tests
{
    public class Hash_Tests
    {

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
