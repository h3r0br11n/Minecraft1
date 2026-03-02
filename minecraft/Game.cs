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
        private Random random = new Random();
        private Player player;
        private Tool tool;
        public void Start()
        {
            player = new Player();
            tool = new Pickaxe();

            Console.ForegroundColor = ConsoleColor.Cyan; ;
            Console.WriteLine("--- Minecraft ---");
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.Yellow;
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
            Console.Clear();
            Block block = new StoneBlock();

            int randomBlock = random.Next(1, 4);

            switch (randomBlock)
            {
                case 1:
                    block = new StoneBlock();
                    break;
                case 2:
                    block = new DirtBlock();
                    break;
                default:
                    block = new WoodBlock();
                    break;
            }
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"You found a {block.Name} block!");
            Console.ResetColor();

            if (tool.Type != block.RequiredTool)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"You need a {block.RequiredTool} to mine this block!");
                Console.ResetColor();
                return;
            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Player starts mining...");
            Console.ResetColor();

            while (block.Health > 0)
            {
                if (tool.Durability <= 0)
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("Your tool broke!");
                    Console.ResetColor();
                    return;
                }

                tool.Use(block);

                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine($"Block HP: {block.Health}");
                Console.ResetColor();

                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.WriteLine($"Tool durability: {tool.Durability}");
                Console.ResetColor();

                System.Threading.Thread.Sleep(400);
            }

            Console.ForegroundColor = ConsoleColor.Magenta;
            block.DropLoot(player);
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Block destroyed!");
            Console.ResetColor();
        }

        private void Fight()
        {
            Zombie zombie = new Zombie();

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("A WILD ZOMBIE APPEARS!!!");
            Console.ResetColor();

            while (zombie.Health > 0 && player.Health > 0)
            {
                zombie.Attack(player);

                Console.ForegroundColor = ConsoleColor.Green;
                player.Attack(zombie);
                Console.ResetColor();
            }
            if (player.Health <= 0)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("You died...");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine("You defeated the zombie!");
            }

        }
    }
}
