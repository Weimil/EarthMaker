using Level.BlockStuff;
using Miscellaneous;
using UnityEngine;

namespace Level.ChunkStuff
{
    public static class Population
    {
        public static Block[,,] Populate(Block[,,] blocks, int[,] heightMap)
        {
            blocks = StoneLayer(blocks, heightMap);
            blocks = BedrockLayer(blocks);
            blocks = DirtGrassLayer(blocks, heightMap);
            return blocks;
        }

        private static Block[,,] BedrockLayer(Block[,,] blocks)
        {
            for (int x = 0; x < blocks.GetLength(0); x++)
            for (int y = 0; y < 5; y++)
            for (int z = 0; z < blocks.GetLength(2); z++)
                if (Constants.Random.NextDouble() > (float) y / 5)
                    blocks[x, y, z] = new BlockDefinition().Bedrock;
            return blocks;
        }

        private static Block[,,] StoneLayer(Block[,,] blocks, int[,] heightMap)
        {
            for (int x = 0; x < blocks.GetLength(0); x++)
            for (int z = 0; z < blocks.GetLength(2); z++)
            for (int y = 0; y < heightMap[x + 1, z + 1]; y++)
            {
                blocks[x, y, z] = new BlockDefinition().Stone;
            }
            return blocks;
        }

        private static Block[,,] DirtGrassLayer(Block[,,] blocks, int[,] heightMap)
        {
            for (int x = 0; x < blocks.GetLength(0); x++)
            for (int z = 0; z < blocks.GetLength(2); z++)
            {
                blocks[x, heightMap[x + 1, z + 1], z] = new BlockDefinition().Grass;
                blocks[x, heightMap[x + 1, z + 1] - 1, z] = new BlockDefinition().Dirt;
                blocks[x, heightMap[x + 1, z + 1] - 2, z] = new BlockDefinition().Dirt;
                blocks[x, heightMap[x + 1, z + 1] - 3, z] = new BlockDefinition().Dirt;
            }
            return blocks;
        }
    }
}