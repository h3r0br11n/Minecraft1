using MinecraftGame.Enums;

namespace MinecraftGame.Blocks
{
    public class WoodBlock : Block
    {
        public WoodBlock()
        {
            Name = "Wood";
            Health = 15;
        }
        public override ToolType RequiredTool => ToolType.Axe;
    }
}
