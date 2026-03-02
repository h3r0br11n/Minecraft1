using System;
using MinecraftGame.Blocks;
using MinecraftGame.Tools;
using MinecraftGame.PlayerSystem;
using MinecraftGame.Enemies;

namespace MinecraftGame
{
    public class Game
    {
        public void Start()
        {
            Player player = new Player();
            Block block = new StoneBlock();
            Tool tool = new Pickaxe();
            Zombie zombie = new Zombie();

            Console.WriteLine("--- Minecraft ---");

            //Mining
            Console.WriteLine("Player starts mining...");
            while (block.Health > 0)
            {
                tool.Use(block);
                Console.WriteLine($"Block HP: {block.Health}");
            }
            block.DropLoot(player);

            //Combat
            Console.WriteLine("\a wild zombie appears!!!");
            while(zombie.Health > 0 && player.Health > 0)
            {
                zombie.Attack(player);
                player.Attack(zombie);
            }
            Console.WriteLine("--- GAME OVER ---");
        }
    }

}
