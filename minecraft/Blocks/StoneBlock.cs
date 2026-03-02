using MinecraftGame.Enums;

namespace MinecraftGame.Blocks
{
    public class StoneBlock : Block
    {
        public StoneBlock()
        {
            Name = "Stone";
            Health = 20;
        }
        public override ToolType RequiredTool => ToolType.Pickaxe;
    }
}
