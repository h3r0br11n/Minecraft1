using System;
using MinecraftGame.Blocks;
using MinecraftGame.Tools;
using MinecraftGame.PlayerSystem;
using MinecraftGame.Enemies;
using System.Runtime.CompilerServices;

namespace MinecraftGame
{
    public class Game
    {
        private Player player;
        private Tool tool;
        public void Start()
        {
            player = new Player();
            tool = new Pickaxe();

            Console.WriteLine("--- Minecraft ---");

            bool running = true;
            while (running)
            {
                Console.WriteLine("\nChoose action:");
                Console.WriteLine("1 - Mine stone.");
                Console.WriteLine("2 - Fight zombie.");
                Console.WriteLine("3 - Show inventory.");
                Console.WriteLine("4 - Exit.");

                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        Mine();
                        break;

                    case "2":
                        Fight();
                        break;

                    case "3":
                        player.Inventory.ShowItems();
                        break;

                    case "4":
                        running = false;
                        break;

                    default:
                        Console.WriteLine("Invalid input. Try again.");
                        break;

                }
            }
            Console.WriteLine("Thanks for playing!");
        }


        private void Mine()
        {
            Block block = new StoneBlock();
            Console.WriteLine("Player starts mining...");
            while (block.Health > 0)
            {
                tool.Use(block);
                Console.WriteLine($"Block HP: {block.Health}");
            }
            block.DropLoot(player);
        }

        //Combat
        private void Fight()
        {
            Zombie zombie = new Zombie();
            Console.WriteLine("A wild zombie appears!!!");
            while (zombie.Health > 0 && player.Health > 0)
            {
                zombie.Attack(player);
                player.Attack(zombie);
            }
            if (player.Health <= 0)
            {
                Console.WriteLine("You died...");
            }
            else
            {
                Console.WriteLine("You defeated the zombie!");
            }

        }
    }
}
