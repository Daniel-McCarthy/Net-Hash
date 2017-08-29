using System;

namespace FNV_Hash
{
    public static class FNV
    {
        private const Int32 fnv032Prime = 0;
        private const Int32 fnv132Prime = unchecked(16777619);//(Int64)(Math.Pow(2, 24) + Math.Pow(2, 8) + 147);
        private const Int32 fnv132Offset = unchecked((int)0x811C9DC5);


        public static string fnv032Hash(byte[] message)
        {
            Int64 hash = 0;

            foreach(byte data in message)
            {
                hash *= fnv032Prime;
                hash ^= data;
            }

            return hash.ToString("X8");
        }

    }
}
