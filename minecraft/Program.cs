using MinecraftGame.Core;

namespace MinecraftGame
{
    class Program
    {
        static void Main()
        {
            Logger.Initialize();

            Game game = new Game();
            game.Start();
        } 
    }
}