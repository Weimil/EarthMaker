using System.Collections.Generic;
using Level.WorldStuff;
using UnityEngine;

namespace LoadManagement
{
    public class LoadServer : MonoBehaviour
    {
        private World _world;
        private HashSet<Vector2> _loadedChunks;
        private HashSet<Vector2> _toBeUnloaded;
        private HashSet<Vector2> _toBeLoaded;

        public void Awake()
        {
            _world = GetComponent<World>();
            _loadedChunks = new HashSet<Vector2>();
            _toBeUnloaded = new HashSet<Vector2>();
            _toBeLoaded = new HashSet<Vector2>();
        }

        public void ChunkRequest(HashSet<Vector2> viewDistanceMask)
        {
            foreach (Vector2 vector in _loadedChunks) _toBeUnloaded.Add(vector);
            _toBeUnloaded.ExceptWith(viewDistanceMask);
            foreach (Vector2 vector in _toBeUnloaded) _world.Unload(vector);

            foreach (Vector2 vector in viewDistanceMask) _toBeLoaded.Add(vector);
            _toBeLoaded.ExceptWith(_loadedChunks);
            foreach (Vector2 vector in _toBeLoaded) _world.Load(vector);

            _loadedChunks.Clear();
            _toBeLoaded.Clear();
            _toBeUnloaded.Clear();

            foreach (Vector2 vector in viewDistanceMask) _loadedChunks.Add(vector);
        }
    }
}