using MinecraftGame.Enums;
using MinecraftGame.Core;

namespace MinecraftGame.Tools
{
    public abstract class Tool : GameObject
    {
       public int Damage { get; protected set; }
       public ToolType Type { get; protected set; }

        public virtual void Use(IDamageable target)
        { 
            target.TakeDamage(Damage);
        }
    }
}