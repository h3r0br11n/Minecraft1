using System;
using System.IO;

namespace MinecraftGame.Core
{
    public static class Logger
    {
        private static string logFile;

        public static void Initialize()
        {
            string folder = "Logs";

            if ( !Directory.Exists(folder))
                Directory.CreateDirectory(folder);
            
            string timestamp = DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss");

            logFile = $"{folder}/log_{timestamp}.txt";

            File.WriteAllText(logFile, "--- Minecraft Game Log ---\n");
            File.AppendAllText(logFile, $"Game started at {DateTime.Now}\n");
        }

        public static void Log(string message)
        { 
            string line = $"[{DateTime.Now:HH:mm:ss}] {message}";
            File.AppendAllText(logFile, line + Environment.NewLine);
        }
    }
}
