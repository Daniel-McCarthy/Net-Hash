using System;

namespace MD_Hash
{
    public class MD
    {
        static byte[] md2Table =
        {
            0x29, 0x2E, 0x43, 0xC9, 0xA2, 0xD8, 0x7C, 0x01,
            0x3D, 0x36, 0x54, 0xA1, 0xEC, 0xF0, 0x06, 0x13,
            0x62, 0xA7, 0x05, 0xF3, 0xC0, 0xC7, 0x73, 0x8C,
            0x98, 0x93, 0x2B, 0xD9, 0xBC, 0x4C, 0x82, 0xCA,
            0x1E, 0x9B, 0x57, 0x3C, 0xFD, 0xD4, 0xE0, 0x16,
            0x67, 0x42, 0x6F, 0x18, 0x8A, 0x17, 0xE5, 0x12,
            0xBE, 0x4E, 0xC4, 0xD6, 0xDA, 0x9E, 0xDE, 0x49,
            0xA0, 0xFB, 0xF5, 0x8E, 0xBB, 0x2F, 0xEE, 0x7A,
            0xA9, 0x68, 0x79, 0x91, 0x15, 0xB2, 0x07, 0x3F,
            0x94, 0xC2, 0x10, 0x89, 0x0B, 0x22, 0x5F, 0x21,
            0x80, 0x7F, 0x5D, 0x9A, 0x5A, 0x90, 0x32, 0x27,
            0x35, 0x3E, 0xCC, 0xE7, 0xBF, 0xF7, 0x97, 0x03,
            0xFF, 0x19, 0x30, 0xB3, 0x48, 0xA5, 0xB5, 0xD1,
            0xD7, 0x5E, 0x92, 0x2A, 0xAC, 0x56, 0xAA, 0xC6,
            0x4F, 0xB8, 0x38, 0xD2, 0x96, 0xA4, 0x7D, 0xB6,
            0x76, 0xFC, 0x6B, 0xE2, 0x9C, 0x74, 0x04, 0xF1,
            0x45, 0x9D, 0x70, 0x59, 0x64, 0x71, 0x87, 0x20,
            0x86, 0x5B, 0xCF, 0x65, 0xE6, 0x2D, 0xA8, 0x02,
            0x1B, 0x60, 0x25, 0xAD, 0xAE, 0xB0, 0xB9, 0xF6,
            0x1C, 0x46, 0x61, 0x69, 0x34, 0x40, 0x7E, 0x0F,
            0x55, 0x47, 0xA3, 0x23, 0xDD, 0x51, 0xAF, 0x3A,
            0xC3, 0x5C, 0xF9, 0xCE, 0xBA, 0xC5, 0xEA, 0x26,
            0x2C, 0x53, 0x0D, 0x6E, 0x85, 0x28, 0x84, 0x09,
            0xD3, 0xDF, 0xCD, 0xF4, 0x41, 0x81, 0x4D, 0x52,
            0x6A, 0xDC, 0x37, 0xC8, 0x6C, 0xC1, 0xAB, 0xFA,
            0x24, 0xE1, 0x7B, 0x08, 0x0C, 0xBD, 0xB1, 0x4A,
            0x78, 0x88, 0x95, 0x8B, 0xE3, 0x63, 0xE8, 0x6D,
            0xE9, 0xCB, 0xD5, 0xFE, 0x3B, 0x00, 0x1D, 0x39,
            0xF2, 0xEF, 0xB7, 0x0E, 0x66, 0x58, 0xD0, 0xE4,
            0xA6, 0x77, 0x72, 0xF8, 0xEB, 0x75, 0x4B, 0x0A,
            0x31, 0x44, 0x50, 0xB4, 0x8F, 0xED, 0x1F, 0x1A,
            0xDB, 0x99, 0x8D, 0x33, 0x9F, 0x11, 0x83, 0x14
        };

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
            0xD76AA478, 0xE8C7B756, 0x242070DB, 0xC1BDCEEE, 0xF57C0FAF, 0x4787C62A, 0xA8304613, 0xFD469501,
            0x698098D8, 0x8B44F7AF, 0xFFFF5BB1, 0x895CD7BE, 0x6B901122, 0xFD987193, 0xA679438E, 0x49B40821,
            0xF61E2562, 0xC040B340, 0x265E5A51, 0xE9B6C7AA, 0xD62F105D, 0x02441453, 0xD8A1E681, 0xE7D3FBC8,
            0x21E1CDE6, 0xC33707D6, 0xF4D50D87, 0x455A14ED, 0xA9E3E905, 0xFCEFA3F8, 0x676F02D9, 0x8D2A4C8A,
            0xFFFA3942, 0x8771F681, 0x6D9D6122, 0xFDE5380C, 0xA4BEEA44, 0x4BDECFA9, 0xF6BB4B60, 0xBEBFBC70,
            0x289B7EC6, 0xEAA127FA, 0xD4EF3085, 0x04881D05, 0xD9D4D039, 0xE6DB99E5, 0x1FA27CF8, 0xC4AC5665,
            0xF4292244, 0x432AFF97, 0xAB9423A7, 0xFC93A039, 0x655B59C3, 0x8F0CCC92, 0xFFEFF47D, 0x85845DD1,
            0x6FA87E4F, 0xFE2CE6E0, 0xA3014314, 0x4E0811A1, 0xF7537E82, 0xBD3AF235, 0x2AD7D2BB, 0xEB86D391
        };

        public static string md2_128Hash(byte[] message)
        {
            byte[] hashState = new byte[48];
            byte[] checksum = new byte[16];

            //There must be padding, even if already divisible by 16.
            //Depending on the size of the message there will be between 1-16 bytes of padding.
            byte paddingAmount = (byte)(((message.Length % 16) == 0) ? 16 : (16 - ((message.Length) % 16)));

            byte[] paddedMessage = new byte[message.Length + paddingAmount];

            for(int i = 0; i < paddedMessage.Length; i++)
            {
                if(i < message.Length)
                {
                    paddedMessage[i] = message[i];
                }
                else
                {
                    //The padding data must be the number of padded bytes
                    paddedMessage[i] = paddingAmount;
                }
            }

            //Calculate hash with padded message
            calculateMD2(paddedMessage);

            //Recalculate with generated checksum
            calculateMD2(checksum);

            //Assemble Hash String from State
            string hashString = "";
            for (int i = 0; i < 16; i++)
            {
                hashString += hashState[i].ToString("X2");
            }

            return hashString;


            void calculateMD2(byte[] input)
            {
                for (int i = 0; i < 16; i++)
                {
                    hashState[16 + i] = input[i];
                    hashState[32 + i] = (byte)(hashState[16 + i] ^ hashState[i]);
                }

                byte t = 0;

                for (byte i = 0; i < 18; i++)
                {
                    for (int j = 0; j < 48; j++)
                    {
                        hashState[j] ^= md2Table[t];
                        t = hashState[j];
                    }

                    t += i;
                }

                t = checksum[15];

                for (int i = 0; i < 16; i++)
                {
                    checksum[i] ^= md2Table[(input[i] ^ t)];
                    t = checksum[i];
                }

            }

        }


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
