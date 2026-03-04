using MinecraftGame.Core;

namespace MinecraftGame.Enemies
{
    public abstract class Enemy : GameObject, IDamageable
    {
        public int Health { get; protected set; }
        public abstract void Attack(IDamageable target);
        public void TakeDamage(int damage)
        { 
            Health -= damage;
            Console.WriteLine($"{Name} took {damage} damage! Current HP: {Health}");
        }
    }
}
