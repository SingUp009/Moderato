using Moderato.Collections;
using UnityEngine;

namespace Moderato
{
    public class Random
    {
        /// <summary>
        /// 
        /// </summary>

        /* The arguments to the Random function are as follows
         * Vector2Int
         * int minInclusive, int maxExclusive
         * 
         * The following will be implemented
         * Vector2 Range(Vector2 range)
         * float Range(float minInclusive, float maxExclusive)
         */

        public uint Seed { get; private set; }

        private uint state;

        public Random(uint seed)
        {
            Seed = seed;
            InitState(seed);
        }

        public void InitState(uint state)
        {
            this.state = state;
        }

        public int Range(Vector2Int range)
        {
            return Range(range.x, range.y);
        }

        public int Range(int minInclusive, int maxExclusive)
        {
            return minInclusive + (int)(Next(++state) % (uint)(maxExclusive - minInclusive));
        }

        public int Next()
        {
            return (int)Next(++state);
        }

        private uint Next(uint data)
        {
            uint state = xxHash.Hash32(data, Seed);
            uint xor = ((state >> 18) ^ state) >> 27;
            int rot = (int)(state >> 59);

            return (xor >> rot) | (xor << ((-rot) & 31));
        }
    }
}