using MinecraftGame.Enums;

namespace MinecraftGame.Blocks
{
    public class DirtBlock : Block
    {
        public DirtBlock()
        {
            Name = "Dirt";
            Health = 10;
        }
        public override ToolType RequiredTool => ToolType.Shovel;
    }
}
