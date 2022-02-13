using System.Collections.Generic;
using Level.ChunkStuff;
using Level.RegionStuff;
using Miscellaneous;
using static Miscellaneous.Constants;
using UnityEngine;

namespace Level.WorldStuff
{
    public class World : MonoBehaviour
    {
        private Dictionary<Vector2, Region> _regions;
        private Region _region;
        private Chunk _chunk;

        public void Init(Region region, Chunk chunk)
        {
            _regions = new Dictionary<Vector2, Region>();
            _region = region;
            _chunk = chunk;
        }

        private void GenerateRegion(Vector2 vector)
        {
            Region region = Instantiate(
                _region,
                new Vector3(vector.x, 0, vector.y) * (ChunkWidth * RegionWidth),
                Quaternion.identity,
                gameObject.transform
            );
            // GameObject a = new GameObject($"Region[{vector.x}|{vector.y}]");
            // Region region = a.AddComponent<Region>();
            // region.transform.position = new Vector3(vector.x, 0, vector.y) * 16f;
            // region.transform.rotation = Quaternion.identity;
            // region.transform.parent = gameObject.transform;
            region.name = $"Region[{vector.x}|{vector.y}]";
            region.Init(_chunk);
            _regions.Add(vector, region);

        }

        public void Load(Vector2 vector)
        {
            Vector2 vectorDiv = Mathw.Vector2IntDivision(vector, RegionWidth);
            if (_regions.ContainsKey(vectorDiv))
            {
                _regions[vectorDiv].Load(vector);
            }
            else
            {
                GenerateRegion(vectorDiv);
                _regions[vectorDiv].Load(vector);
            }
        }

        public void Unload(Vector2 vector)
        {
            Vector2 vectorDiv = Mathw.Vector2IntDivision(vector, RegionWidth);
            if (_regions.ContainsKey(vectorDiv))
            {
                _regions[vectorDiv].Unload(vector);
                if (_regions[vectorDiv].ChunksCount() == 0)
                    Destroy(_regions[vectorDiv].gameObject);
            }
        }
    }
}