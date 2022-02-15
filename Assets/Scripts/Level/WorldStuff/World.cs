using System;
using System.Collections.Generic;
using System.Threading.Tasks;
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


        public void Init()
        {
            _regions = new Dictionary<Vector2, Region>();
        }

        private void InstantiateRegion(Vector2 vector)
        {
            Region region = Instantiate(
                Constants.Region,
                new Vector3(vector.x, 0, vector.y) * (ChunkWidth * RegionWidth),
                Quaternion.identity,
                gameObject.transform
            );
            region.name = $"Region[{vector.x}|{vector.y}]";
            _regions.Add(vector, region);
            region.Init();
        }

        public void Load(Vector2 vector)
        {
            Vector2 vectorDiv = Mathw.Vector2IntDivision(vector, RegionWidth);
            if (!_regions.ContainsKey(vectorDiv))
                InstantiateRegion(vectorDiv);
            _regions[vectorDiv].InstantiateChunk(vector);
        }

        public void Unload(Vector2 vector)
        {
            Vector2 vectorDiv = Mathw.Vector2IntDivision(vector, RegionWidth);
            if (_regions.ContainsKey(vectorDiv))
                _regions[vectorDiv].Unload(vector);

            if (_regions[vectorDiv].ChunksCount() != 0) return;
            Destroy(_regions[vectorDiv].gameObject);
            _regions.Remove(vectorDiv);
        }
    }
}