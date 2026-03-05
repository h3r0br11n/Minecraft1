using MinecraftGame.Core;
using MinecraftGame.Enums;
using MinecraftGame.PlayerSystem;

namespace MinecraftGame.Blocks
{
    public abstract class Block : GameObject, IDamageable
    {
        public int Health { get; protected set; }
        public abstract ToolType RequiredTool { get; }

        public virtual void DropLoot(Player player)
        {
            Random rnd = new Random();
            int amount = rnd.Next(1, 4);

            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine($"{Name} dropped {amount} items!");
            Console.ResetColor(); 

            for (int i = 0; i < amount; i++)
                player.Inventory.AddItem(Name);
        }

        public void TakeDamage(int damage)
        {
            Health -= damage;
            
        }
    }
}
