using System;

namespace SHA_Hash
{
    public class SHA
    {
        static uint[] sha0Table =
        {
            0x5A827999, 0x6ED9EBA1, 0x8F1BBCDC, 0xCA62C1D6
        };

        static uint[] sha1Table =
        {
            0x5A827999, 0x6ED9EBA1, 0x8F1BBCDC, 0xCA62C1D6
        };

        static uint[] sha2_224Table =
        {
            0x428A2F98, 0x71374491, 0xB5C0FBCF, 0xE9B5DBA5, 0x3956C25B, 0x59F111F1, 0x923F82A4, 0xAB1C5ED5,
            0xD807AA98, 0x12835B01, 0x243185BE, 0x550C7DC3, 0x72BE5D74, 0x80DEB1FE, 0x9BDC06A7, 0xC19BF174,
            0xE49B69C1, 0xEFBE4786, 0x0FC19DC6, 0x240CA1CC, 0x2DE92C6F, 0x4A7484AA, 0x5CB0A9DC, 0x76F988DA,
            0x983E5152, 0xA831C66D, 0xB00327C8, 0xBF597FC7, 0xC6E00BF3, 0xD5A79147, 0x06CA6351, 0x14292967,
            0x27B70A85, 0x2E1B2138, 0x4D2C6DFC, 0x53380D13, 0x650A7354, 0x766A0ABB, 0x81C2C92E, 0x92722C85,
            0xA2BFE8A1, 0xA81A664B, 0xC24B8B70, 0xC76C51A3, 0xD192E819, 0xD6990624, 0xF40E3585, 0x106AA070,
            0x19A4C116, 0x1E376C08, 0x2748774C, 0x34B0BCB5, 0x391C0CB3, 0x4ED8AA4A, 0x5B9CCA4F, 0x682E6FF3,
            0x748F82EE, 0x78A5636F, 0x84C87814, 0x8CC70208, 0x90BEFFFA, 0xA4506CEB, 0xBEF9A3F7, 0xC67178F2
        };

        public static string sha0_160Hash(byte[] message)
        {
            uint a = 0x67452301;
            uint b = 0xEFCDAB89;
            uint c = 0x98BADCFE;
            uint d = 0x10325476;
            uint e = 0xc3d2e1f0;

            //Decide padding amount. Padding must always occur, even if length is already divisible by 64.
            //Space also must be made for an 8 byte message length, and a string terminator character (0x80)

            //If the message length is 9 or more bytes short of 64: Just pad to the nearest multiple of 64
            //Else: Pad to the nearest multiple 64 and pad another 64 bytes so there is room for the message length

            int paddingAmount = (64 - (message.Length % 64));        //Calculate how many bytes of padding are required to achieve next multiple of 64
            paddingAmount += (paddingAmount >= 9) ? 0 : 64;          //If less than 9 bytes were padded to the message, add another 64.



            byte[] paddedMessage = new byte[message.Length + paddingAmount];

            for (int i = 0; i < message.Length; i++)
            {
                paddedMessage[i] = message[i];
            }

            paddedMessage[message.Length] = 0x80;

            //Write message size to padded message
            UInt64 sizeToWrite = (UInt64)(message.Length * 8);
            uint sizeOffset = (uint)(paddedMessage.Length - 8);
            uint mask = 0x000000FF;

            for (int i = 0; i < 8; i++)
            {
                paddedMessage[(paddedMessage.Length - 1) - i] = (byte)((sizeToWrite & (mask)) >> (i * 8));
                mask <<= 8;
            }


            uint[] intConvertedMessage = new uint[16];

            //Loop for each set of 512 bits
            for (uint h = 0; h < ((paddedMessage.Length << 3) / 512); h++)
            {

                //Convert byte array to little endian int array
                for (uint i = 0; i < intConvertedMessage.Length; i++)
                {
                    uint fullValue = 0;

                    //No longer reversed endian
                    fullValue |= (uint)(paddedMessage[(i * 4) + (64 * h)] << 24);
                    fullValue |= (uint)(paddedMessage[(i * 4) + (64 * h) + 1] << 16);
                    fullValue |= (uint)(paddedMessage[(i * 4) + (64 * h) + 2] << 8);
                    fullValue |= (paddedMessage[(i * 4) + (64 * h) + 3]);

                    intConvertedMessage[i] = fullValue;

                }

                uint a1 = a;
                uint b1 = b;
                uint c1 = c;
                uint d1 = d;
                uint e1 = e;

                for (uint i = 0; i < 80; i++)
                {
                    uint f = 0;

                    if ((i >= 0) && (i <= 15))
                    {
                        f = ((b1 & (c1 ^ d1)) ^ d1);
                    }
                    else if ((i >= 16) && (i <= 19))
                    {
                        uint blockData = intConvertedMessage[((i % 16) + 13) & 15];
                        blockData ^= intConvertedMessage[((i % 16) + 8) & 15];
                        blockData ^= intConvertedMessage[((i % 16) + 2) & 15];
                        blockData ^= intConvertedMessage[(i % 16)];
                        intConvertedMessage[(i % 16)] = blockData;

                        f = ((b1 & (c1 ^ d1)) ^ d1);
                    }
                    else if ((i >= 20) && (i <= 39))
                    {
                        uint blockData = intConvertedMessage[((i % 16) + 13) & 15];
                        blockData ^= intConvertedMessage[((i % 16) + 8) & 15];
                        blockData ^= intConvertedMessage[((i % 16) + 2) & 15];
                        blockData ^= intConvertedMessage[(i % 16)];
                        intConvertedMessage[(i % 16)] = blockData;

                        f = (b1 ^ c1 ^ d1);
                    }
                    else if ((i >= 40) && (i <= 59))
                    {
                        uint blockData = intConvertedMessage[((i % 16) + 13) & 15];
                        blockData ^= intConvertedMessage[((i % 16) + 8) & 15];
                        blockData ^= intConvertedMessage[((i % 16) + 2) & 15];
                        blockData ^= intConvertedMessage[(i % 16)];
                        intConvertedMessage[(i % 16)] = blockData;
                        f = (((b1 | c1) & d1) | (b1 & c1));
                    }
                    else if ((i >= 60) && (i <= 79))
                    {
                        uint blockData = intConvertedMessage[((i % 16) + 13) & 15];
                        blockData ^= intConvertedMessage[((i % 16) + 8) & 15];
                        blockData ^= intConvertedMessage[((i % 16) + 2) & 15];
                        blockData ^= intConvertedMessage[(i % 16)];
                        intConvertedMessage[(i % 16)] = blockData;
                        f = (b1 ^ c1 ^ d1);
                    }

                    f = f + e1 + sha0Table[i / 20] + intConvertedMessage[(i % 16)] + rotateLeft(a1, 5);
                    b1 = rotateLeft(b1, 30);

                    //Swap variables for next calculation
                    e1 = d1;
                    d1 = c1;
                    c1 = b1;
                    b1 = a1;
                    a1 = f;

                }

                a += a1;
                b += b1;
                c += c1;
                d += d1;
                e += e1;
            }

            return a.ToString("X8") + b.ToString("X8") + c.ToString("X8") + d.ToString("X8") + e.ToString("X8");

        }

        public static string sha1_160Hash(byte[] message)
        {
            uint a = 0x67452301;
            uint b = 0xEFCDAB89;
            uint c = 0x98BADCFE;
            uint d = 0x10325476;
            uint e = 0xc3d2e1f0;

            //Decide padding amount. Padding must always occur, even if length is already divisible by 64.
            //Space also must be made for an 8 byte message length, and a string terminator character (0x80)

            //If the message length is 9 or more bytes short of 64: Just pad to the nearest multiple of 64
            //Else: Pad to the nearest multiple 64 and pad another 64 bytes so there is room for the message length

            int paddingAmount = (64 - (message.Length % 64));        //Calculate how many bytes of padding are required to achieve next multiple of 64
            paddingAmount += (paddingAmount >= 9) ? 0 : 64;          //If less than 9 bytes were padded to the message, add another 64.



            byte[] paddedMessage = new byte[message.Length + paddingAmount];

            for (int i = 0; i < message.Length; i++)
            {
                paddedMessage[i] = message[i];
            }

            paddedMessage[message.Length] = 0x80;

            //Write message size to padded message
            UInt64 sizeToWrite = (UInt64)(message.Length * 8);
            uint sizeOffset = (uint)(paddedMessage.Length - 8);
            uint mask = 0x000000FF;

            for (int i = 0; i < 8; i++)
            {
                paddedMessage[(paddedMessage.Length - 1) - i] = (byte)((sizeToWrite & (mask)) >> (i * 8));
                mask <<= 8;
            }


            uint[] intConvertedMessage = new uint[16];

            //Loop for each set of 512 bits
            for (uint h = 0; h < ((paddedMessage.Length << 3) / 512); h++)
            {

                //Convert byte array to little endian int array
                for (uint i = 0; i < intConvertedMessage.Length; i++)
                {
                    uint fullValue = 0;

                    //No longer reversed endian
                    fullValue |= (uint)(paddedMessage[(i * 4) + (64 * h)] << 24);
                    fullValue |= (uint)(paddedMessage[(i * 4) + (64 * h) + 1] << 16);
                    fullValue |= (uint)(paddedMessage[(i * 4) + (64 * h) + 2] << 8);
                    fullValue |= (paddedMessage[(i * 4) + (64 * h) + 3]);

                    intConvertedMessage[i] = fullValue;

                }

                uint a1 = a;
                uint b1 = b;
                uint c1 = c;
                uint d1 = d;
                uint e1 = e;

                for (uint i = 0; i < 80; i++)
                {
                    uint f = 0;

                    if ((i >= 0) && (i <= 15))
                    {
                        f = ((b1 & (c1 ^ d1)) ^ d1);
                    }
                    else if ((i >= 16) && (i <= 19))
                    {
                        uint blockData = intConvertedMessage[((i % 16) + 13) & 15];
                        blockData ^= intConvertedMessage[((i % 16) + 8) & 15];
                        blockData ^= intConvertedMessage[((i % 16) + 2) & 15];
                        blockData ^= intConvertedMessage[(i % 16)];
                        blockData = rotateLeft(blockData, 1);
                        intConvertedMessage[(i % 16)] = blockData;

                        f = ((b1 & (c1 ^ d1)) ^ d1);
                    }
                    else if ((i >= 20) && (i <= 39))
                    {
                        uint blockData = intConvertedMessage[((i % 16) + 13) & 15];
                        blockData ^= intConvertedMessage[((i % 16) + 8) & 15];
                        blockData ^= intConvertedMessage[((i % 16) + 2) & 15];
                        blockData ^= intConvertedMessage[(i % 16)];
                        blockData = rotateLeft(blockData, 1);
                        intConvertedMessage[(i % 16)] = blockData;

                        f = (b1 ^ c1 ^ d1);
                    }
                    else if ((i >= 40) && (i <= 59))
                    {
                        uint blockData = intConvertedMessage[((i % 16) + 13) & 15];
                        blockData ^= intConvertedMessage[((i % 16) + 8) & 15];
                        blockData ^= intConvertedMessage[((i % 16) + 2) & 15];
                        blockData ^= intConvertedMessage[(i % 16)];
                        blockData = rotateLeft(blockData, 1);
                        intConvertedMessage[(i % 16)] = blockData;
                        f = (((b1 | c1) & d1) | (b1 & c1));
                    }
                    else if ((i >= 60) && (i <= 79))
                    {
                        uint blockData = intConvertedMessage[((i % 16) + 13) & 15];
                        blockData ^= intConvertedMessage[((i % 16) + 8) & 15];
                        blockData ^= intConvertedMessage[((i % 16) + 2) & 15];
                        blockData ^= intConvertedMessage[(i % 16)];
                        blockData = rotateLeft(blockData, 1);
                        intConvertedMessage[(i % 16)] = blockData;
                        f = (b1 ^ c1 ^ d1);
                    }

                    f = f + e1 + sha1Table[i / 20] + intConvertedMessage[(i % 16)] + rotateLeft(a1, 5);
                    b1 = rotateLeft(b1, 30);

                    //Swap variables for next calculation
                    e1 = d1;
                    d1 = c1;
                    c1 = b1;
                    b1 = a1;
                    a1 = f;
                    
                }

                a += a1;
                b += b1;
                c += c1;
                d += d1;
                e += e1;
            }

            return a.ToString("X8") + b.ToString("X8") + c.ToString("X8") + d.ToString("X8") + e.ToString("X8");

        }

        public static string sha2_224Hash(byte[] message)
        {

            {
                uint a = 0xC1059ED8;
                uint b = 0x367CD507;
                uint c = 0x3070DD17;
                uint d = 0xF70E5939;
                uint e = 0xFFC00B31;
                uint f = 0x68581511;
                uint g = 0x64F98FA7;
                uint h = 0xBEFA4FA4;

                //Decide padding amount. Padding must always occur, even if length is already divisible by 64.
                //Space also must be made for an 8 byte message length, and a string terminator character (0x80)

                //If the message length is 9 or more bytes short of 64: Just pad to the nearest multiple of 64
                //Else: Pad to the nearest multiple 64 and pad another 64 bytes so there is room for the message length

                int paddingAmount = (64 - (message.Length % 64));        //Calculate how many bytes of padding are required to achieve next multiple of 64
                paddingAmount += (paddingAmount >= 9) ? 0 : 64;          //If less than 9 bytes were padded to the message, add another 64.



                byte[] paddedMessage = new byte[message.Length + paddingAmount];

                for (int i = 0; i < message.Length; i++)
                {
                    paddedMessage[i] = message[i];
                }

                paddedMessage[message.Length] = 0x80;

                //Write message size to padded message
                UInt64 sizeToWrite = (UInt64)(message.Length * 8);
                uint sizeOffset = (uint)(paddedMessage.Length - 8);
                uint mask = 0x000000FF;

                for (int i = 0; i < 8; i++)
                {
                    paddedMessage[(paddedMessage.Length - 1) - i] = (byte)((sizeToWrite & (mask)) >> (i * 8));
                    mask <<= 8;
                }


                uint[] intConvertedMessage = new uint[64];

                //Loop for each set of 512 bits
                for (uint j = 0; j < ((paddedMessage.Length << 3) / 512); j++)
                {

                    //Convert byte array to little endian int array
                    for (uint i = 0; i < 16; i++)
                    {
                        uint fullValue = 0;

                        //No longer reversed endian
                        fullValue |= (uint)(paddedMessage[(i * 4) + (64 * j)] << 24);
                        fullValue |= (uint)(paddedMessage[(i * 4) + (64 * j) + 1] << 16);
                        fullValue |= (uint)(paddedMessage[(i * 4) + (64 * j) + 2] << 8);
                        fullValue |= (paddedMessage[(i * 4) + (64 * j) + 3]);

                        intConvertedMessage[i] = fullValue;

                    }

                    //Use SHA Calculations to extend to 64 ints
                    for(int i = 16; i < 64; i++)
                    {
                        intConvertedMessage[i] = calculation6(intConvertedMessage[i - 2]) + intConvertedMessage[i - 7] + calculation5(intConvertedMessage[i - 15]) + intConvertedMessage[i - 16];
                    }

                    uint a1 = a;
                    uint b1 = b;
                    uint c1 = c;
                    uint d1 = d;
                    uint e1 = e;
                    uint f1 = f;
                    uint g1 = g;
                    uint h1 = h;
    
                    for (uint i = 0; i < 64; i++)
                    {
                        uint l = 0, m = 0;

                        l = h1 + calculation4(e1) + calculation2(e1, f1, g1) + sha2_224Table[i] + intConvertedMessage[i];
                        m = calculation3(a1) + calculation1(a1, b1, c1);

                        //Swap variables around and add in previous calculations
                        h1 = g1;
                        g1 = f1;
                        f1 = e1;
                        e1 = d1 + l;
                        d1 = c1;
                        c1 = b1;
                        b1 = a1;
                        a1 = l + m; 

                    }

                    a += a1;
                    b += b1;
                    c += c1;
                    d += d1;
                    e += e1;
                    f += f1;
                    g += g1;
                    h += h1;
                }

                return a.ToString("X8") + b.ToString("X8") + c.ToString("X8") + d.ToString("X8") + e.ToString("X8") + f.ToString("X8") + g.ToString("X8");

                uint calculation1(uint v1, uint v2, uint v3)
                {
                    return ((v1 & v2) | (v3 & (v1 | v2)));
                }


            }
        }

        public static uint rotateLeft(uint value, int amount)
        {
            return ((value << amount) | (value >> (32 - amount)));
        }

        public static uint rotateRight(uint value, int amount)
        {
            return ((value >> amount) | (value << (32 - amount)));
        }

    }
}
