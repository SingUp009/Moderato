namespace Moderato.Collections
{
    public class xxHash
    {
        private const uint PRIME32_2 = 2246822519U;
        private const uint PRIME32_3 = 3266489917U;
        private const uint PRIME32_4 = 668265263U;
        private const uint PRIME32_5 = 374761393U;
        private const uint PRIME32_6 = 1635631U;

        public static uint Hash32(uint data, uint seed)
        {
            uint h32 = data * PRIME32_3;
            h32 += seed + PRIME32_5 + 4U;
            h32 = (h32 << 17) | (h32 >> 15);
            h32 *= PRIME32_4;
            h32 ^= h32 >> 15;
            h32 *= PRIME32_2;
            h32 ^= h32 >> 13;
            h32 *= PRIME32_3;
            h32 ^= h32 >> 16;

            return h32;
        }

        public static uint Hash32(uint data)
        {
            return Hash32(data, PRIME32_6);
        }
    }
}
