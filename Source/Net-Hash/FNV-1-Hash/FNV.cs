using System;

namespace FNV_Hash
{
    public static class FNV
    {
        private const Int32 fnv032Prime = 0;
        private const Int32 fnv132Prime = unchecked(16777619);//(Int64)(Math.Pow(2, 24) + Math.Pow(2, 8) + 147);
        private const Int32 fnv132Offset = unchecked((int)0x811C9DC5);
    }
}
