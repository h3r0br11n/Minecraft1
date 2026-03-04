using System;
using System.IO;

namespace MinecraftGame.Utils
{
    public static class Logger
    { 
        private static string logFile = "game_log.txt";

        public static void Log(string message)
        { 
            string line = $"{DateTime.Now:HH:mm:ss}: {message}";

            File.AppendAllText(logFile, line + Environment.NewLine);
        }
    
    }
}