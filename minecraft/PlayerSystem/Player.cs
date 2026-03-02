using System;
using MinecraftGame.Core;

namespace MinecraftGame.PlayerSystem
{
    public class Player : GameObject, IDamageable
    {
        public int Health { get; private set; } = 100;
        public Inventory Inventory { get; private set; }

        public Player()
        {
            Name = "Steve";
            Inventory = new Inventory();
        }

        public void TakeDamage(int damage)
        {
            Health -= damage;
            Console.WriteLine($"Player took {damage} damage! Current HP: {Health}");
        }

        public void Attack(IDamageable target)
        {
            int damage = 10;
            target.TakeDamage(damage);
            Console.WriteLine($"Player attacks!");
        }

    }
    
}
