using System.Collections.Generic;
using Level.ChunkStuff;
using Level.RegionStuff;
using Miscellaneous;
using Miscellaneous.Utils;
using UnityEngine;

namespace Level.WorldStuff
{
    public class World : MonoBehaviour
    {
        private Dictionary<Vector2, Region> Regions { get; set; }

        public void Unload(Vector2 vector)
        {
            if (Regions.TryGetValue(Mathw.Vector2IntDivision(vector, Constants.RegionWidth), out Region region))
                if (region._chunks.TryGetValue(Mathw.Vector2IntMod(vector, Constants.RegionWidth), out Chunk chunk))
                    Destroy(chunk.gameObject);
        }

        public void Load(Vector2 vector)
        {
            Vector2 vectorDiv = Mathw.Vector2IntDivision(vector, Constants.RegionWidth);
            if (!Regions.TryGetValue(vectorDiv, out Region region))
            {
                GenerateRegion(vectorDiv);
            }
            else
            {
                Vector2 vectorMod = Mathw.Vector2IntMod(vector, Constants.RegionWidth);
                if (!region._chunks.TryGetValue(vectorMod, out Chunk chunk))
                    region.GenerateChunk(vectorMod);
            }
        }

        private void GenerateRegion(Vector2 vector)
        {
            Region region = Instantiate(
                gameObject.AddComponent<Region>(),
                new Vector3(vector.x, 0, vector.y) * 16f,
                Quaternion.identity,
                gameObject.transform
            );
            region.name = $"Region[{vector.x}|{vector.y}]";
            Regions.Add(vector, region);
        }
    }
}