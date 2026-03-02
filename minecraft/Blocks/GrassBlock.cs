using MinecraftGame.Enums;

namespace MinecraftGame.Blocks
{
    public class GrassBlock : Block
    {
        public GrassBlock()
        {
            Name = "Grass";
            Health = 10;
        }
        public override ToolType RequiredTool => ToolType.Shovel;
    }
}
