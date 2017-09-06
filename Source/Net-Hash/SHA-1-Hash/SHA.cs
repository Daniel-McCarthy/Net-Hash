using System;

namespace SHA_Hash
{
    public class SHA
    {

        static uint[] sha1Table =
        {
            0x5A827999, 0x6ED9EBA1, 0x8F1BBCDC, 0xCA62C1D6
        };


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
