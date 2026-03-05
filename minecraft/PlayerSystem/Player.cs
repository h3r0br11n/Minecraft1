using MinecraftGame.Core;
using MinecraftGame.Tools;

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

            Inventory.AddTool(new Pickaxe());
            Inventory.AddTool(new Shovel());
            Inventory.AddTool(new Axe());
        }

        public void TakeDamage(int damage)
        {
            Health -= damage;

            if (Health <= 0)
            { 
                Health = 0;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Player took {damage}! HP: {Health}");
                Console.ResetColor();

                if (Health == 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Player died");
                    Console.ResetColor();

                    Logger.Log("Player has died.");

                    Console.WriteLine();
                    Console.WriteLine("--- Game Over! ---");

                    Environment.Exit(0);
                }
            }
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
