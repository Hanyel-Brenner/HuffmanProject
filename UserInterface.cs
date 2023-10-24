using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Huffman
{
    public class UserInterface
    {
        public static void ShowIntroduction()
        {
            Console.WriteLine("------------------------------------------------------------------");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Huffman's Coding compression program . Compress your text files");
            Console.ResetColor();
            Console.WriteLine("Version 1.0  ,2023");
            Console.WriteLine("------------------------------------------------------------------");
        }
        public static void ShowMenu()
        {
            Console.WriteLine(" MENU");
            Console.WriteLine("");
            Console.WriteLine("1. Select and compress file");
            Console.WriteLine("2. Select and decompress file");
            Console.WriteLine("3. Exit application");
            Console.WriteLine("------------------------------------------------------------------");
        }

        public static void ShowExitingMessage()
        {
            Console.WriteLine("------------------------------------------------------------------");
            Console.WriteLine("Thanks for using my application. Goodbye");
            Console.WriteLine("------------------------------------------------------------------");
        }
    }
}
