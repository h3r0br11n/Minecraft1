using MinecraftGame.Enums;

namespace MinecraftGame.Tools
{
    public class Shovel : Tool
    {
        public Shovel()
        {
            Name = "Shovel";
            Damage = 3;
            Durability = 40;
            Type = ToolType.Shovel;
        }
    }
}