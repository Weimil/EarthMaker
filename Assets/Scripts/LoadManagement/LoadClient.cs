using System.Collections.Generic;
using Miscellaneous.Utils;
using UnityEngine;

namespace LoadManagement
{
    public class LoadClient : MonoBehaviour
    {
        private int ViewDistance { get; set; }
        private LoadServer _server;
        private List<Vector2> ViewDistanceMask { get; set; }
        private Vector3 _position;

        public void Init(LoadServer server)
        {
            ViewDistanceMask = new List<Vector2>();
            ViewDistance = 2;
            _server = server;
            CreateViewDistanceMask();
            SendRequest(Vector3.zero);
        }

        private void Update()
        {
            Vector3 currentPosition = Mathw.Vector3IntDivision(transform.position, 16);
            if (_position != currentPosition) SendRequest(currentPosition);
        }

        private void SendRequest(Vector3 currentPosition)
        {
            _position = currentPosition;
            HashSet<Vector2> hashSet = new HashSet<Vector2>();
            for (int i = 0; i < ViewDistanceMask.Count; i++)
                hashSet.Add(new Vector2(
                        ViewDistanceMask[i].x + (int) _position.x,
                        ViewDistanceMask[i].y + (int) _position.z
                    )
                );
            _server.ChunkRequest(hashSet);
        }

        private void CreateViewDistanceMask()
        {
            ViewDistanceMask.Clear();
            int max = ViewDistance * 2 + 1;

            for (int i = 0; i < max; i++)
            for (int j = 0; j < max; j++)
                ViewDistanceMask.Add(new Vector2(
                    i - ViewDistance,
                    j - ViewDistance
                ));
        }
    }
}