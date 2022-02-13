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
        public static readonly int RegionWidth = 4;
        public static readonly int TextureWidth = 6;
        public static readonly int TextureHeight = 6;
        public static readonly int Seed = 0;
        public static readonly float Scale = 100f;
        public static readonly Random Random = new Random(Seed);
        public static Material ChunkMaterial;
        public static Region RegionTemplate;
        public static Chunk ChunkTemplate;

        private void Start()
        {
            // RegionTemplate = new GameObject().gameObject.AddComponent<Region>();
            // ChunkTemplate = new GameObject().gameObject.AddComponent<Chunk>();

            // RegionTemplate = (Region) Resources.Load("Prefabs/RegionPrefab");
            // ChunkTemplate = new GameObject().gameObject.AddComponent<Chunk>();

            // ChunkMaterial = Resources.Load<Material>("GFX/ChunkMaterial.mat");
            // ChunkTemplate.GetComponent<Renderer>().material = ChunkMaterial;
        }
    }
}