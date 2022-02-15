using Level.ChunkStuff;
using Level.RegionStuff;
using UnityEngine;
using Random = System.Random;

namespace Miscellaneous
{
    public class Constants : MonoBehaviour
    {
        public static readonly int ChunkWidth = 16;
        public static readonly int ChunkHeight = 256;
        public static readonly int RegionWidth = 16;
        public static readonly int TextureWidth = 6;
        public static readonly int TextureHeight = 8;
        public static readonly int Seed = 50;
        public static readonly float Scale = 256f;
        public static readonly int Octaves = 1;
        public static Region Region;
        public static Chunk Chunk;
        public static readonly Random Random = new Random(Seed);
    }
}