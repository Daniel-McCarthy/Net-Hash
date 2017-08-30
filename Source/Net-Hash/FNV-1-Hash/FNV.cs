using System;

namespace FNV_Hash
{
    public static class FNV
    {
        private const Int32 fnv032Prime = 0;
        private const Int32 fnv132Prime = unchecked(16777619);//(Int64)(Math.Pow(2, 24) + Math.Pow(2, 8) + 147);
        private const Int32 fnv132Offset = unchecked((int)0x811C9DC5);


        public static string fnv0_32Hash(byte[] message)
        {
            Int32 hash = 0;

            foreach(byte data in message)
            {
                hash *= fnv032Prime;
                hash ^= data;
            }

            return hash.ToString("X8");
        }

        public static string fnv1_32Hash(byte[] message)
        {
            Int32 hash = fnv132Offset;

            foreach(byte data in message)
            {
                hash *= fnv132Prime;
                hash ^= data;
            }

            return hash.ToString("X8");
        }

        public static string fnv1A_32Hash(byte[] message)
        {
            Int32 hash = fnv132Offset;

            foreach (byte data in message)
            {
                hash ^= data;
                hash *= fnv132Prime;
            }

            return hash.ToString("X8");
        }
    }
}
