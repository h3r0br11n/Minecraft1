using MinecraftGame.Enums;

namespace MinecraftGame.Blocks
{
    public class DiamondBlock : Block
    {
        public DiamondBlock()
        {
            Name = "Diamond Block";
            Health = 50;
        }
        public override ToolType RequiredTool => ToolType.Pickaxe;
    }
} 
