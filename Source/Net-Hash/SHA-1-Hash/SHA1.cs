using System;

namespace SHA_Hash
{
    public class SHA
    {

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
