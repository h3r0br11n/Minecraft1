using System;
using MinecraftGame.Core;

namespace MinecraftGame.Enemies
{
    public class  Skeleton : Enemy
    {
        public Skeleton()
        {
            Name = "Skeleton";
            Health = 40;
        }

        public override void Attack(IDamageable target)
        {
            int damage = 12;
            
            target.TakeDamage(damage);

            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine($"Skeleton shoots an arrow for {damage} damage!");
            Console.ResetColor();
        }
    }
}