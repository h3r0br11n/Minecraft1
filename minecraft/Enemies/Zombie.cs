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
            int damage = 8;
            target.TakeDamage(damage);
            Console.WriteLine($"Zombie attacks!");
        }
    }
}
