using Level.BlockStuff;
using Miscellaneous;

namespace Level.ChunkStuff
{
    public static class Population
    {
        public static void Populate(ref Block[,,] blocks, int[,] heightMap)
        {
            StoneLayer(ref blocks, ref heightMap);
            BedrockLayer(ref blocks);
            DirtGrassLayer(ref blocks, ref heightMap);
        }

        private static void BedrockLayer(ref Block[,,] blocks)
        {
            for (int x = 0; x < blocks.GetLength(0); x++)
            for (int y = 0; y < 5; y++)
            for (int z = 0; z < blocks.GetLength(2); z++)
                if (Constants.Random.NextDouble() > (float) y / 5)
                    blocks[x, y, z] = new BlockDefinition().Bedrock;
        }

        private static void StoneLayer(ref Block[,,] blocks, ref int[,] heightMap)
        {
            for (int x = 0; x < blocks.GetLength(0); x++)
            for (int z = 0; z < blocks.GetLength(2); z++)
            for (int y = 0; y < heightMap[x + 1, z + 1]; y++)
                blocks[x, y, z] = new BlockDefinition().Stone;
        }

        private static void DirtGrassLayer(ref Block[,,] blocks, ref int[,] heightMap)
        {
            for (int x = 0; x < blocks.GetLength(0); x++)
            for (int z = 0; z < blocks.GetLength(2); z++)
            {
                blocks[x, heightMap[x + 1, z + 1], z] = new BlockDefinition().Grass;
                blocks[x, heightMap[x + 1, z + 1] - 1, z] = new BlockDefinition().Dirt;
                blocks[x, heightMap[x + 1, z + 1] - 2, z] = new BlockDefinition().Dirt;
                blocks[x, heightMap[x + 1, z + 1] - 3, z] = new BlockDefinition().Dirt;
            }
        }
    }
}