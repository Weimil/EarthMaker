using System.Collections.Generic;
using System.Linq;
using Miscellaneous;
using UnityEngine;

namespace Level.BlockStuff
{
    public static class MeshTables
    {
        /*
         * Order: X+- Y+- Z+-
         * X+: East  \ X-: West
         * Y+: Top   \ Y-: Bottom
         * Z+: North \ Z-: South
         *
         * Documentation in "MineClone.drawio"
         */
        public static readonly Vector3[] FaceCheck = new Vector3[6]
        {
            // Side facing ...
            new Vector3(0, 1, 0), // ... Top
            new Vector3(0, -1, 0), // ... Bottom
            new Vector3(0, 0, 1), // ... North
            new Vector3(0, 0, -1), // ... South
            new Vector3(1, 0, 0), // ... East
            new Vector3(-1, 0, 0) // ... West
        };

        private static readonly List<Vector3> FullBlockVertex = new List<Vector3>
        {
            new Vector3(0, 0, 0), // 0
            new Vector3(0, 0, 1), // 1
            new Vector3(1, 0, 0), // 2
            new Vector3(1, 0, 1), // 3
            new Vector3(0, 1, 0), // 4
            new Vector3(0, 1, 1), // 5
            new Vector3(1, 1, 0), // 6
            new Vector3(1, 1, 1) // 7
        };

        private static readonly List<int>[] FullBlockTriangles =
        {
            // Side facing ...
            new List<int> {4, 5, 6, 6, 5, 7}, // ... Top
            new List<int> {0, 2, 1, 1, 2, 3}, // ... Bottom
            new List<int> {1, 3, 5, 5, 3, 7}, // ... North
            new List<int> {0, 4, 2, 2, 4, 6}, // ... South
            new List<int> {2, 6, 3, 3, 6, 7}, // ... East
            new List<int> {0, 1, 4, 4, 1, 5} // ... West
        };

        public static List<Vector3> VertexListFromFace(int meshType, int face, Vector3 pos)
        {
            switch (meshType)
            {
                case 1:
                    return FullBlockTriangles[face].Select(x => FullBlockVertex[x] + pos) as List<Vector3>;
                default:
                    ErrorLogger.Error(100);
                    return null;
            }
        }

        public static List<int> TriangleListFromFace(int meshType, int face, int vertexIndex)
        {
            switch (meshType)
            {
                case 1:
                    return new List<int>(FullBlockTriangles[face].Count).Select(x => x = vertexIndex++) as List<int>;
                default:
                    ErrorLogger.Error(101);
                    return null;
            }
        }

        public static List<Vector3> UVsListFromFace(int meshType, int face, Vector3 pos)
        {
            switch (meshType)
            {
                case 1:
                    return (List<Vector3>) FullBlockTriangles[face].Select(x => FullBlockVertex[x] + pos);
                default:
                    ErrorLogger.Error(102);
                    return null;
            }
        }
    }
}