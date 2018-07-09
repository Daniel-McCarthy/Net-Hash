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

        [Fact]
        public void TestFNV0()
        {
            Assert.Equal("6077D641", FNV.fnv0_32Hash(stringToByteArray("HelloKitty")));
        }

        [Fact]
        public void TestFNV1()
        {
            Assert.Equal("8C974AE0", FNV.fnv1_32Hash(stringToByteArray("HelloKitty")));
        }

        [Fact]
        public void TestFNV1A()
        {
            Assert.Equal("2C934346", FNV.fnv1A_32Hash(stringToByteArray("HelloKitty")));
        }

        [Fact]
        public void TestCRC32()
        {
            Assert.Equal("9A133DE9", CRC.crc_32Hash(stringToByteArray("HelloKitty")));
        }

        [Fact]
        public void TestCRC32B()
        {
            Assert.Equal("129CA114", CRC.crcB_32Hash(stringToByteArray("HelloKitty")));
        }

        [Fact]
        public void TestMD2()
        {
            Assert.Equal("D35E6E718A891F00659CCD3ADD0259C0", MD.md2_128Hash(stringToByteArray("HelloKitty")));
        }

        [Fact]
        public void TestMD4()
        {
            Assert.Equal("7865F2C781395A074AC6161AE18059A3", MD.md4_128Hash(stringToByteArray("HelloKitty")));
        }

        [Fact]
        public void TestMD5()
        {
            Assert.Equal("C2DF5F7D3132A7920E6B245AB1E58625", MD.md5_128Hash(stringToByteArray("HelloKitty")));
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
