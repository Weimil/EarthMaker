using System.Collections.Generic;
using Level.ChunkStuff;
using UnityEngine;

namespace Level.RegionStuff
{
    public class Region : MonoBehaviour
    {
        public Dictionary<Vector2, Chunk> _chunks { get; }


        public void GenerateChunk(Vector2 vector)
        {
            Chunk chunk = Instantiate(
                gameObject.AddComponent<Chunk>(),
                new Vector3(vector.x, 0, vector.y) * 16f,
                Quaternion.identity,
                gameObject.transform
            );
            chunk.name = $"Chunk[{vector.x}|{vector.y}]";
            _chunks.Add(vector, chunk);
        }
    }
}