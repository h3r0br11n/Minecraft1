using MinecraftGame.Core;

namespace MinecraftGame.Enemies
{
    public class Zombie : Enemy
    {
        public Zombie() 
        {
            Name = "Zombie";
            Health = 50;
        }

        public override void Attack(IDamageable target)
        {
            Random rnd = new Random();
            int damage = rnd.Next(4, 12);

            target.TakeDamage(damage);

            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine($"Zombie hits for {damage} damage!");
            Console.ResetColor(); 
            
            Logger.Log($"Zombie attacked for {damage} damage.");
        }
    }
}
