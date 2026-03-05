using MinecraftGame.Enums;
using MinecraftGame.Tools; 

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
            var groupedItems = items.GroupBy(i => i);

            foreach (var group in groupedItems)
                Console.WriteLine($"{group.Key} x{group.Count()}");

        }
        public bool HasItem(string item)
        {
            return items.Contains(item);
        }

        public void RemoveItem(string item)
        {
            items.Remove(item);
        }

        private List<Tool> tools = new List<Tool>();

        public void ShowTools()
        {
            Console.WriteLine("Tools: ");

            foreach (var tool in tools)
            {
                Console.WriteLine(tool);
            }
        }

        public void AddTool(Tool tool)
        {
            tools.Add(tool);
        }

        public Tool GetToolForBlock(ToolType required)
        {
            foreach (var tool in tools)
            {
                if (tool.Type == required)
                {
                    return tool;
                }
            }
            return null;
        }
    }
}
