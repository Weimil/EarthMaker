using System.Collections.Generic;
using static Miscellaneous.Constants;
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
        public static readonly Vector3[] FaceCheck =
        {
            // Side facing ...
            new Vector3(0, 1, 0), // ... Top
            new Vector3(0, -1, 0), // ... Bottom
            new Vector3(0, 0, 1), // ... North
            new Vector3(0, 0, -1), // ... South
            new Vector3(1, 0, 0), // ... East
            new Vector3(-1, 0, 0) // ... West
        };

        private static readonly Vector3[] FullBlockVertex =
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

        private static readonly int[,] FullBlockTriangles =
        {
            // Side facing ...
            {4, 5, 6, 7}, // ... Top
            {0, 2, 1, 3}, // ... Bottom
            {1, 3, 5, 7}, // ... North
            {0, 4, 2, 6}, // ... South
            {2, 6, 3, 7}, // ... East
            {0, 1, 4, 5} // ... West
        };

        private static readonly Vector3[] TMPFullBlockVertex =
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

        private static readonly int[,] TMPFullBlockTriangles =
        {
            // Side facing ...
            {4, 5, 6, 6, 5, 7}, // ... Top
            {0, 2, 1, 1, 2, 3}, // ... Bottom
            {1, 3, 5, 5, 3, 7}, // ... North
            {0, 4, 2, 2, 4, 6}, // ... South
            {2, 6, 3, 3, 6, 7}, // ... East
            {0, 1, 4, 4, 1, 5}  // ... West
        };

        private static readonly Vector2[] FullBlockUVs =
        {
            new Vector2(0, 0),
            new Vector3(0, 1),
            new Vector3(1, 0),
            new Vector3(1, 1)
        };

        public static void Mesh(
            ref List<int> triangles, ref List<Vector3> vertex, ref List<Vector2> uvs, ref int vertexIndex,
            Vector3 position, Block block, int face
        )
        {
            TriangleListFromFace(block.MeshType, ref vertexIndex, ref triangles);
            VertexListFromFace(block.MeshType, face, position, ref vertex);
            UVsListFromFace(block.MeshType, face, block.TextureMapIndex, ref uvs);
        }

        private static void VertexListFromFace(int meshType, int face, Vector3 pos, ref List<Vector3> list)
        {
            switch (meshType)
            {
                case (int) BlockMeshType.FullBlock:
                    list.Add(FullBlockVertex[FullBlockTriangles[face, 0]] + pos);
                    list.Add(FullBlockVertex[FullBlockTriangles[face, 1]] + pos);
                    list.Add(FullBlockVertex[FullBlockTriangles[face, 2]] + pos);
                    list.Add(FullBlockVertex[FullBlockTriangles[face, 3]] + pos);
                    break;
                case (int) BlockMeshType.TMPFullBlock:
                    for (int i = 0; i < TMPFullBlockTriangles.GetLength(1); i++) list.Add(TMPFullBlockVertex[TMPFullBlockTriangles[face,i]] + pos);
                    break;
            }
        }

        private static void TriangleListFromFace(int meshType, ref int vertexIndex, ref List<int> list)
        {
            switch (meshType)
            {
                case (int) BlockMeshType.FullBlock:
                    list.Add(vertexIndex);
                    list.Add(vertexIndex + 1);
                    list.Add(vertexIndex + 2);
                    list.Add(vertexIndex + 1);
                    list.Add(vertexIndex + 2);
                    list.Add(vertexIndex + 3);
                    vertexIndex += 4;
                    break;
                case (int) BlockMeshType.TMPFullBlock:
                    for (int i = 0; i < TMPFullBlockTriangles.GetLength(1); i++)
                    {
                        list.Add(vertexIndex);
                        vertexIndex++;
                    }
                    break;

            }
        }

        private static void UVsListFromFace(int meshType, int face, int textureIndex, ref List<Vector2> list)
        {
            switch (meshType)
            {
                case (int) BlockMeshType.FullBlock:
                    list.Add(new Vector2(
                        FullBlockUVs[0].x / TextureWidth + 1f / TextureWidth * face,
                        FullBlockUVs[0].y / TextureHeight + 1f / TextureHeight * textureIndex
                    ));
                    list.Add(new Vector2(
                        FullBlockUVs[1].x / TextureWidth + 1f / TextureWidth * face,
                        FullBlockUVs[1].y / TextureHeight + 1f / TextureHeight * textureIndex
                    ));
                    list.Add(new Vector2(
                        FullBlockUVs[2].x / TextureWidth + 1f / TextureWidth * face,
                        FullBlockUVs[2].y / TextureHeight + 1f / TextureHeight * textureIndex
                    ));
                    list.Add(new Vector2(
                        FullBlockUVs[3].x / TextureWidth + 1f / TextureWidth * face,
                        FullBlockUVs[3].y / TextureHeight + 1f / TextureHeight * textureIndex
                    ));
                    break;
                case (int) BlockMeshType.TMPFullBlock:
                    for (int i = 0; i < TMPFullBlockTriangles.GetLength(1); i++)
                        switch (face)
                        {
                            case 0:
                            case 1:
                                list.Add(new Vector2(
                                        TMPFullBlockVertex[TMPFullBlockTriangles[face,i]].x / TextureWidth +
                                        1f / TextureWidth * face,
                                        TMPFullBlockVertex[TMPFullBlockTriangles[face,i]].z / TextureHeight +
                                        1f / TextureHeight * textureIndex
                                    )
                                );
                                break;

                            case 2:
                            case 3:
                                list.Add(new Vector2(
                                        TMPFullBlockVertex[TMPFullBlockTriangles[face,i]].x / TextureWidth +
                                        1f / TextureWidth * face,
                                        TMPFullBlockVertex[TMPFullBlockTriangles[face,i]].y / TextureHeight +
                                        1f / TextureHeight * textureIndex
                                    )
                                );
                                break;

                            case 4:
                            case 5:
                                list.Add(new Vector2(
                                        TMPFullBlockVertex[TMPFullBlockTriangles[face,i]].z / TextureWidth +
                                        1f / TextureWidth * face,
                                        TMPFullBlockVertex[TMPFullBlockTriangles[face,i]].y / TextureHeight +
                                        1f / TextureHeight * textureIndex
                                    )
                                );
                                break;
                        }
                    break;

            }
        }
    }
}