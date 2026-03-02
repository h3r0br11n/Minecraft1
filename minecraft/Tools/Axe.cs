using MinecraftGame.Core;
using MinecraftGame.Enums;
using MinecraftGame.Tools;
using static System.Net.Mime.MediaTypeNames;

namespace Minecraft.Tools
{
    public class Axe : Tool
    {
        public Axe()
        {
            Name = "Axe";
            Damage = 4;
            Type = ToolType.Axe;
        }
    }
}