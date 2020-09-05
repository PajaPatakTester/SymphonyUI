using System;

namespace Framework
{
   public static class Log
    {
        public static void Error(string message)
        {
            Console.WriteLine($"ERROR [{Time()}]: {message}");
        }

        public static void Info(string message)
        {
            Console.WriteLine($"INFO [{Time()}]: {message}");
        }


        public static void Warning(string message)
        {
            Console.WriteLine($"WARNING [{Time()}]: {message}");
        }

        private static string Time()
        {
            return DateTime.UtcNow.AddHours(2).ToString("dd/MM/yyyy HH:mm:ss");
        }
    }
}
