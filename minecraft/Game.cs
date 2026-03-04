using System;
using MinecraftGame.Blocks;
using MinecraftGame.Tools;
using MinecraftGame.PlayerSystem;
using MinecraftGame.Enemies;
using MinecraftGame.Utils;
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

            Logger.Log("Game started.");

            Console.ForegroundColor = ConsoleColor.Cyan; ;
            Console.WriteLine("--- Minecraft ---");
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.Yellow;
            bool running = true;
            while (running)
            {
                Console.WriteLine("\nChoose action:");
                Console.WriteLine("1 - Mine stone.");
                Console.WriteLine("2 - Fight.");
                Console.WriteLine("3 - Show inventory.");
                Console.WriteLine("4 - Show Stats");
                Console.WriteLine("5 - Find something to eat.");
                Console.WriteLine("6 - Eat.");
                Console.WriteLine("7 - Exit.");

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
                        ShowStats();
                        break;

                    case "5":
                        GatherFood();
                        break;

                    case "6":
                        Eat();
                        break;

                    case "7":
                        running = false;
                        break;

                    default:
                        Console.WriteLine("Invalid input. Try again.");
                        break;

                }
            }
            Logger.Log("Game closed.");
            Console.WriteLine("Thanks for playing!");
        }

        private void ShowStats()
        {
            Console.WriteLine("\n--- Player Stats ---");
            Console.WriteLine($"Player HP: {player.Health}");
            Console.WriteLine($"Level: {player.Level}");
        }
        private void CheckLevelUp()
        {
            if (player.Experience >= 20)
            {
                player.Level++;
                player.Experience = 0;

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"LEVEL UP!!! You've reached level {player.Level}!");
                Console.ResetColor();
            }
        }

        private void Mine()
        {
            Console.Clear();
            Block block;

            int randomBlock = random.Next(1, 6);

            switch (randomBlock)
            {
                case 1:
                    block = new StoneBlock();
                    break;
                case 2:
                    block = new DirtBlock();
                    break;
                case 3:
                    block = new WoodBlock();
                    break;
                case 4:
                    block = new StoneBlock();
                    break;

                default:
                    block = new DiamondBlock();
                    break;
            }
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"You found a {block.Name} block!");
            Console.ResetColor();

            Logger.Log($"Player found a {block.Name} block.");

            if (tool.Type != block.RequiredTool)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"You need a {block.RequiredTool} to mine this block!");
                Console.ResetColor();

                Logger.Log($"Player failed to mine {block.Name} block. Required tool: {block.RequiredTool}.");
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

                Logger.Log($"Player mined {block.Name} block. Remaining HP: {block.Health}. Tool durability: {tool.Durability}.");

                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.WriteLine($"Tool durability: {tool.Durability}");
                Console.ResetColor();

                System.Threading.Thread.Sleep(400);
            }

            Console.ForegroundColor = ConsoleColor.Magenta;
            block.DropLoot(player);
            Console.ResetColor();

            if (block.Name == "Diamond")
            {
                player.Experience += 20;

                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("You mined a DIAMOND! +20XP");
            }
            else
            {
                player.Experience += 5;

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("+5XP");
            }
            Console.ResetColor();

            player.Experience += 5;

            Logger.Log($"Player destroyed {block.Name} block, received loot and gained XP from minung.");

            CheckLevelUp();
        }

        private void Fight()
        {
            Enemy enemy;

            int rndm = random.Next(1, 4);

            switch (rndm)
            {
                case 1:
                    enemy = new Zombie();
                    break;

                case 2:
                    enemy = new Spider();
                    break;

                default:
                    enemy = new Zombie();
                    break;
            }

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"A wild {enemy.Name} appears!");
            Console.ResetColor();   

            Logger.Log($"Player encountered a {enemy.Name}.");

            while (enemy.Health > 0 && player.Health > 0)
            { 
                enemy.Attack(player);
                player.Attack(enemy);
                
            }
        }
        private void GatherFood()
        {
            string[] foods = { "Apple", "Bread", "Cooked Meat" };
            string food = foods[random.Next(foods.Length)];
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"You found some {food}!");
            Console.ResetColor();
            Logger.Log($"Player found {food}.");
            player.Inventory.AddItem(food);
        }

        private void Eat()
        {
            if (player.Inventory.HasItem("Apple"))
            {
                player.Inventory.RemoveItem("Apple");
                player.Heal(20);

                Console.WriteLine("You ate an Apple and restored 20 HP!");
                Logger.Log("Player ate an Apple and healed 20 HP.");
            }
            else if (player.Inventory.HasItem("Bread"))
            {
                player.Inventory.RemoveItem("Bread");
                player.Heal(30);
                Console.WriteLine("You ate Bread and restored 30 HP!");
                Logger.Log("Player ate Bread and healed 30 HP.");
            }
            else if (player.Inventory.HasItem("Cooked Meat"))
            {
                player.Inventory.RemoveItem("Cooked Meat");
                player.Heal(50);
                Console.WriteLine("You ate Cooked Meat and restored 50 HP!");
                Logger.Log("Player ate Cooked Meat and healed 50 HP.");
            }
            else
            {
                Console.WriteLine("You have nothing to eat!");
                Logger.Log("Player tried to eat but had no food.");
            }
        }
    }
}

