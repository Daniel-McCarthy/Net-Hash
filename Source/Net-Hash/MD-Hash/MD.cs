using System;

namespace MD_Hash
{
    public class MD
    {
        static uint[] md5Shifts =
        {
            7, 12, 17, 22,  7, 12, 17, 22,
            7, 12, 17, 22,  7, 12, 17, 22,
            5,  9, 14, 20,  5,  9, 14, 20,
            5,  9, 14, 20,  5,  9, 14, 20,
            4, 11, 16, 23,  4, 11, 16, 23,
            4, 11, 16, 23,  4, 11, 16, 23,
            6, 10, 15, 21,  6, 10, 15, 21,
            6, 10, 15, 21,  6, 10, 15, 21
        };

        static uint[] md5Table =
        {
            0xd76aa478, 0xe8c7b756, 0x242070db, 0xc1bdceee, 0xf57c0faf, 0x4787c62a, 0xa8304613, 0xfd469501,
            0x698098d8, 0x8b44f7af, 0xffff5bb1, 0x895cd7be, 0x6b901122, 0xfd987193, 0xa679438e, 0x49b40821,
            0xf61e2562, 0xc040b340, 0x265e5a51, 0xe9b6c7aa, 0xd62f105d, 0x02441453, 0xd8a1e681, 0xe7d3fbc8,
            0x21e1cde6, 0xc33707d6, 0xf4d50d87, 0x455a14ed, 0xa9e3e905, 0xfcefa3f8, 0x676f02d9, 0x8d2a4c8a,
            0xfffa3942, 0x8771f681, 0x6d9d6122, 0xfde5380c, 0xa4beea44, 0x4bdecfa9, 0xf6bb4b60, 0xbebfbc70,
            0x289b7ec6, 0xeaa127fa, 0xd4ef3085, 0x04881d05, 0xd9d4d039, 0xe6db99e5, 0x1fa27cf8, 0xc4ac5665,
            0xf4292244, 0x432aff97, 0xab9423a7, 0xfc93a039, 0x655b59c3, 0x8f0ccc92, 0xffeff47d, 0x85845dd1,
            0x6fa87e4f, 0xfe2ce6e0, 0xa3014314, 0x4e0811a1, 0xf7537e82, 0xbd3af235, 0x2ad7d2bb, 0xeb86d391
        };


        public static string md5_128Hash(byte[] message)
        {
            uint a = 0x67452301;
            uint b = 0xefcdab89;
            uint c = 0x98badcfe;
            uint d = 0x10325476;

            int oldSize = message.Length;
            int numNonPaddingCharacters = (message.Length + 8 + 1); //Message Length + 1 to account for 0x80 end character, and + 8 to account for 64 bit file size
            int paddingAmount = (64 - ((numNonPaddingCharacters) % 64));

            byte[] paddedMessage = new byte[numNonPaddingCharacters + paddingAmount];

            for(int i = 0; i < message.Length; i++)
            {
                paddedMessage[i] = message[i];
            }

            paddedMessage[oldSize] = 0x80;

            //Write message size to padded message
            uint sizeToWrite = reverseEndian((uint)(message.Length * 8));
            uint sizeOffset = (uint)(paddedMessage.Length - 8);
            uint mask = 0xFF000000;

            for (int i = 0; i < 4; i++)
            {
                //This can be simplified by writing it from right to left, would require less shifting
                paddedMessage[sizeOffset + i] = (byte)((sizeToWrite & (mask)) >> ((4- (i+1)) * 8));
                mask >>= 8;
            }


            uint[] intConvertedMessage = new uint[16];

            //Loop for each set of 512 bits
            for (uint h = 0; h < ((paddedMessage.Length << 3) / 512); h++)
            {

                //Convert byte array to little endian int array
                for (uint i = 0; i < intConvertedMessage.Length; i++)
                {
                    uint fullValue = 0;

                    fullValue |= (paddedMessage[(i * 4) + (64 * h)]);
                    fullValue |= (uint)(paddedMessage[(i * 4) + (64 * h) + 1] << 8);
                    fullValue |= (uint)(paddedMessage[(i * 4) + (64 * h) + 2] << 16);
                    fullValue |= (uint)(paddedMessage[(i * 4) + (64 * h) + 3] << 24);

                    intConvertedMessage[i] = fullValue;

                }

                uint a1 = a;
                uint b1 = b;
                uint c1 = c;
                uint d1 = d;

                for (uint i = 0; i < 64; i++)
                {
                    uint f = 0, g = 0;

                    if ((i >= 0) && (i <= 15))
                    {
                        f = ((b1 & c1) | (~b1 & d1));
                        g = i;
                    }
                    else if ((i >= 16) && (i <= 31))
                    {
                        f = ((d1 & b1) | (~d1 & c1));
                        g = ((5 * i) + 1) & 0x0F;
                    }
                    else if ((i >= 32) && (i <= 47))
                    {
                        f = b1 ^ c1 ^ d1;
                        g = ((3 * i) + 5) & 0x0F;
                    }
                    else if ((i >= 48) && (i <= 63))
                    {
                        f = c1 ^ (b1 | ~d1);
                        g = (7 * i) & 0x0F;
                    }

                    f = f + a1 + md5Table[i] + intConvertedMessage[g];
                    a1 = d1;
                    d1 = c1;
                    c1 = b1;
                    b1 = b1 + rotateLeft(f, (int)md5Shifts[i]);
                }
              
                a += a1;
                b += b1;
                c += c1;
                d += d1;
            }

            return ((reverseEndian(a)).ToString("X8") + (reverseEndian(b)).ToString("X8") + (reverseEndian(c)).ToString("X8") + (reverseEndian(d)).ToString("X8"));

        }

        static UInt32 reverseEndian(UInt32 hash)
        {
            return (((hash & 0x000000FF) << 24) | ((hash & 0xFF000000) >> 24) | ((hash & 0x00FF0000) >> 8) | ((hash & 0x0000FF00) << 8));
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
