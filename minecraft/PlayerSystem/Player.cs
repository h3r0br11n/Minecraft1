using System;
using MinecraftGame.Core;
using MinecraftGame.Utils;

namespace MinecraftGame.PlayerSystem
{
    public class Player : GameObject, IDamageable
    {
        public int Health { get; set; } = 100;
        public Inventory Inventory { get; set; }
        public int Experience { get; set; } = 0;
        public int Level { get; set; } = 1;

        public Player()
        {
            Name = "Steve";
            Inventory = new Inventory();
        }

        public void TakeDamage(int damage)
        {
            Health -= damage;
            Console.WriteLine($"Player took {damage} damage! Current HP: {Health}");

            Logger.Log($"Player took {damage} damage. Current HP: {Health}");
        }

        public void Attack(IDamageable target)
        {
            Random rnd = new Random();
            int damage = rnd.Next(5, 15);
            int critChance = rnd.Next(0, 100);

            if (critChance < 20)
            {
                damage *= 2;
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("CRITICAL HIT!");
                Console.ResetColor();
            }

            target.TakeDamage(damage);

            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine($"Player hits for {damage} damage!");
            Console.ResetColor();   

            Logger.Log($"Player attacked for {damage} damage.");
        }

        public void ShowHealthBar()
        {
            Console.Write("HP: ");

            for (int i = 0; i < Health / 10; i++)
                Console.Write("█");

            Console.WriteLine($" ({Health})");

            Logger.Log($"Player health bar displayed: {Health} HP.");
        }

        public void Heal(int amount)
        {
            Health += amount;

            if (Health > 100)
                Health = 100;

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Player healed for {amount} HP! Current HP: {Health}");
            Console.ResetColor();
        }
    }
    
}
