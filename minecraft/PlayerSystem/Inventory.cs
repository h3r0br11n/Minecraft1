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
            Console.WriteLine("Inventory: ");
            foreach (var item in items)
                Console.WriteLine(item);

        }
    }
}
