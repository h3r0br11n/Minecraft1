using MinecraftGame.Core;
using MinecraftGame.Enums;
using MinecraftGame.Tools;
using static System.Net.Mime.MediaTypeNames;

namespace Minecraft.Tools
{
    public class Shovel : Tool
    {
        public Shovel()
        {
            Name = "Shovel";
            Damage = 3;
            Type = ToolType.Shovel;
        }
    }
}