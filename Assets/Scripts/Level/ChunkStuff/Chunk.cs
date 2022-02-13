using System;
using System.Collections.Generic;
using UnityEngine.Rendering;
using Level.BlockStuff;
using Unity.Mathematics;
using UnityEngine;
using static Miscellaneous.Constants;
using static Unity.Mathematics.noise;

namespace Level.ChunkStuff
{
    [RequireComponent(typeof(MeshRenderer))]
    [RequireComponent(typeof(MeshCollider))]
    [RequireComponent(typeof(MeshFilter))]
    public class Chunk : MonoBehaviour
    {
        private Block[,,] _blocks;
        private int[,] _heightMap;
        private MeshCollider _meshCollider;
        private MeshRenderer _meshRenderer;
        private MeshFilter _meshFilter;
        private List<int> _triangles;
        private List<Vector3> _vertex;
        private List<Vector2> _uvs;
        private Vector3 _position;
        private Vector2 _coord;
        private float _scale;
        private int _vertexIndex;

        public void Init()
        {
            _blocks = new Block[ChunkWidth, ChunkHeight, ChunkWidth];
            _heightMap = new int[ChunkWidth + 2, ChunkWidth + 2];
            _meshCollider = GetComponent<MeshCollider>();
            _meshRenderer = GetComponent<MeshRenderer>();
            _meshFilter = GetComponent<MeshFilter>();
            _triangles = new List<int>();
            _vertex = new List<Vector3>();
            _uvs = new List<Vector2>();
            _vertexIndex = 0;
            _position = transform.position;

            CreateHeightMap();
            _blocks = Population.Populate(_blocks, _heightMap);
            RenderChunk();
            CreateMesh();
        }

        private void CreateHeightMap()
        {
            for (int x = 0; x < _heightMap.GetLength(0); x++)
            for (int z = 0; z < _heightMap.GetLength(1); z++)
            {
                float newZ = (z + _position.z + 0.0001f) / Scale;
                float newX = (x + _position.x + 0.0001f) / Scale;

                float totalDivisions = 0;
                float noiseValue = 0;
                float multiplier = 1;
                float divider = 1;

                for (int i = 0; i < 4; i++)
                {
                    noiseValue += divider * snoise(new float3(newX * multiplier, Seed, newZ * multiplier));
                    totalDivisions += divider;
                    multiplier *= 2;
                    divider /= 2;
                }

                noiseValue = (float) Math.Pow(noiseValue, 2);

                _heightMap[x, z] = (int) (noiseValue / totalDivisions * 32 + 40);
            }
        }

        private void RenderChunk()
        {
            for (int x = 0; x < _blocks.GetLength(0); x++)
            for (int y = 0; y < _blocks.GetLength(1); y++)
            for (int z = 0; z < _blocks.GetLength(2); z++)
                if (_blocks[x, y, z] != null)
                    for (int face = 0; face < 6; face++)
                        if (IsVisible(x, y, z, face))
                            MeshTables.Mesh(
                                ref _triangles, ref _vertex, ref _uvs, ref _vertexIndex,
                                new Vector3(x - 8, y, z - 8), _blocks[x, y, z], face
                            );
        }

        private bool IsVisible(int x, int y, int z, int face)
        {
            int checkX = x + (int) MeshTables.FaceCheck[face].x;
            int checkY = y + (int) MeshTables.FaceCheck[face].y;
            int checkZ = z + (int) MeshTables.FaceCheck[face].z;

            if (checkX >= 0 && checkX < ChunkWidth &&
                checkY >= 0 && checkY < ChunkHeight &&
                checkZ >= 0 && checkZ < ChunkWidth
            )
                return _blocks[checkX, checkY, checkZ] == null;

            if (_heightMap[checkX + 1, checkZ + 1] >= y)
                return false;

            return true;
        }

        private void CreateMesh()
        {
            Mesh mesh = new Mesh
            {
                indexFormat = IndexFormat.UInt32,
                vertices = _vertex.ToArray(),
                triangles = _triangles.ToArray(),
                uv = _uvs.ToArray()
            };

            mesh.Optimize();
            mesh.RecalculateNormals();

            _meshFilter.mesh = mesh;
            _meshCollider.sharedMesh = mesh;
        }
    }
}