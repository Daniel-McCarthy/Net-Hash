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
        [Fact]
        public void TestAlder32()
        {
            Assert.Equal("152D040A", Adler.adler_32Hash(stringToByteArray("HelloKitty")));
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
