using MinecraftGame.Core;

namespace MinecraftGame.Enemies
{
    public abstract class Enemy : GameObject, IDamageable
    {
        public int Health { get; protected set; }
        public int Damage { get; protected set; }
        public virtual void Attack(IDamageable target)
        {
            Console.WriteLine($"{Name} attacks!");
            target.TakeDamage(Damage);
        }
        public void TakeDamage(int damage)
        {
            Health -= damage;

            if (Health == 0)
            {
                Console.WriteLine($"{Name} took {damage} damage! HP: {Health}.");

                if (Health == 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"{Name} died");
                    Console.ResetColor();
                }
            }
        }

    }
}
