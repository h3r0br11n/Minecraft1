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
            int danage = rnd.Next(4, 12);

            target.TakeDamage(danage);

            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine($"Zombie hits for {danage} damage!");
            Console.ResetColor();   
        }
    }
}
