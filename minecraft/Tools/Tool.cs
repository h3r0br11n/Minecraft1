using MinecraftGame.Enums;
using MinecraftGame.Core;

namespace MinecraftGame.Tools
{
    public abstract class Tool : GameObject
    {
       public int Damage { get; protected set; }
       public ToolType Type { get; protected set; }
       public int Durability { get; protected set; }

        public virtual void Use(IDamageable target)
        { 
           if (Durability <= 0)
           {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Tool is broken!!");
                Console.ResetColor();
                return;
            }
           target.TakeDamage(Damage);
           Durability--; 
        }
    }
}