using MinecraftGame.Core;

namespace MinecraftGame.Enemies
{
    public class Spider : Enemy
    {
        public Spider()
        { 
            Name = "Spider";
            Health = 30;
        }

        public override void Attack(IDamageable target)
        {
            Random rnd = new Random();
            int damage = rnd.Next(3, 10);

            target.TakeDamage(damage);

            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine($"Spider bites for {damage} damage!");
            Console.ResetColor();
        }
    }
}
