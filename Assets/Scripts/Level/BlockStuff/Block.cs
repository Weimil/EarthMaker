namespace Level.BlockStuff
{
    public class Block
    {
        public string Name { get; }
        public int MeshType { get; }
        public int TextureMapIndex { get; }

        public Block(string name, int meshType, int textureMapIndex)
        {
            Name = name;
            MeshType = meshType;
            TextureMapIndex = textureMapIndex;
        }
    }

    public enum BlockTexture
    {
        Debug = 0,
        Bedrock = 1,
        Stone = 2,
        Dirt = 3,
        Grass = 4,
        Sand = 5
    }

    public enum BlockMeshType
    {
        Debug = 0,
        FullBlock = 1,
        TMPFullBlock = 2
    }

    public class BlockDefinition
    {
        public Block Bedrock = new Block("Bedrock", (int) BlockMeshType.TMPFullBlock, (int) BlockTexture.Bedrock);
        public Block Stone = new Block("Stone", (int) BlockMeshType.TMPFullBlock, (int) BlockTexture.Stone);
        public Block Dirt = new Block("Dirt", (int) BlockMeshType.TMPFullBlock, (int) BlockTexture.Dirt);
        public Block Grass = new Block("Grass", (int) BlockMeshType.TMPFullBlock, (int) BlockTexture.Grass);
        public Block Sand = new Block("Sand", (int) BlockMeshType.TMPFullBlock, (int) BlockTexture.Sand);
    }
}