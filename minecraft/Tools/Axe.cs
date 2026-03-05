using MinecraftGame.Enums;

namespace MinecraftGame.Tools
{
    public class Axe : Tool
    {
        public Axe()
        {
            Name = "Axe";
            Damage = 4;
            Durability = 40;
            Type = ToolType.Axe;
        }
    }
}