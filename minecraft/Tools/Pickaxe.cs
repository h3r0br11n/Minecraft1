using MinecraftGame.Core;
using MinecraftGame.Enums;

namespace MinecraftGame.Tools
{
    public class  Pickaxe : Tool
    {
        public Pickaxe()
        { 
            Name = "Pickaxe";
            Damage = 5;
            Type = ToolType.Pickaxe;
        }
    }
}