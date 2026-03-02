using System;
using System.Collections.Generic;

namespace MinecraftGame.PlayerSystem
{
    public class Inventory
    {
        private List<string> items = new List<string>();

        public void AddItem(string item)
        {
            items.Add(item);
            Console.WriteLine($"Added {item} to inventory.");
        }

        public void ShowItems()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Inventory: ");
            Console.ResetColor();
            foreach (var item in items)
                Console.WriteLine(item);

        }
    }
}
