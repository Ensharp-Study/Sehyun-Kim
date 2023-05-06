using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.View
{
    internal class PasswordMasker
    {
        public string HideConsoleInput(int xcooperation, int ycooperation)
        {
            Console.SetCursorPosition(xcooperation, ycooperation);
            string input = "";
            ConsoleKeyInfo key;
            do
            {
                key = Console.ReadKey(true);
                if (key.Key != ConsoleKey.Backspace && key.Key != ConsoleKey.Enter)
                {
                    input += key.KeyChar;
                    Console.Write("*");
                }
                else if (key.Key == ConsoleKey.Backspace && input.Length > 0)
                {
                    input = input.Remove(input.Length - 1);
                    Console.SetCursorPosition(xcooperation + input.Length, ycooperation);
                    Console.Write(" ");
                    Console.SetCursorPosition(xcooperation + input.Length, ycooperation);
                }
            } while (key.Key != ConsoleKey.Enter);
            Console.WriteLine();
            return input;
        }
    }
}
