using System;
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
            Console.WriteLine("Block dropped loot!");
            player.Inventory.AddItem(Name);
        }

        public void TakeDamage(int damage)
        {
            Health -= damage;
            
        }
    }
}
