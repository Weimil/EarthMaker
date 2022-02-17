using Level.ChunkStuff;
using Level.RegionStuff;
using UnityEngine;
using Random = System.Random;

namespace Miscellaneous
{
    public class Constants : MonoBehaviour
    {
        public const int Seed = 50;
        public const int Octaves = 5;
        public const int ChunkWidth = 16;
        public const int ChunkHeight = 256;
        public const int RegionWidth = 16;
        public const int TextureWidth = 6;
        public const int TextureHeight = 8;
        public const float Scale = 256f;

        public static readonly Chunk ChunkPrefab = Resources.Load<Chunk>("Prefabs/ChunkPrefab");
        public static readonly Region RegionPrefab = Resources.Load<Region>("Prefabs/RegionPrefab");
        public static readonly Random Random = new Random(Seed);
    }
}