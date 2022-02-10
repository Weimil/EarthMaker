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
}