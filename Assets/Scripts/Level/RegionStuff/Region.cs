using System.Collections.Generic;
using Level.ChunkStuff;
using UnityEngine;

namespace Level.RegionStuff
{
    public class Region : MonoBehaviour
    {
        private Dictionary<Vector2, Chunk> _chunks;
        private Chunk _chunk;

        public void Init(Chunk chunk)
        {
            _chunks = new Dictionary<Vector2, Chunk>();
            _chunk = chunk;
        }

        private void GenerateChunk(Vector2 vector)
        {
            Chunk chunk = Instantiate(
                _chunk,
                new Vector3(vector.x, 0, vector.y) * 16f,
                Quaternion.identity,
                transform
            );
            chunk.name = $"Chunk[{vector.x}|{vector.y}]";
            _chunks.Add(vector, chunk);
            chunk.Init();
        }

        public void Load(Vector2 vector)
        {
            if (_chunks.ContainsKey(vector))
            {
                _chunks[vector].Init();
            }
            else
            {
                GenerateChunk(vector);
                _chunks[vector].Init();
            }
        }

        public void Unload(Vector2 vector)
        {
            if (_chunks.ContainsKey(vector))
            {
                Destroy(_chunks[vector].gameObject);
                _chunks.Remove(vector);
            }
        }

        public int ChunksCount()
        {
            return _chunks.Count;
        }
    }
}