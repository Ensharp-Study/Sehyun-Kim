using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.View
{
    internal class PasswordMasker
    {
        public string HideConsoleInput()
        {
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
                else
                {
                    if (key.Key == ConsoleKey.Backspace && input.Length > 0)
                    {
                        input = input.Substring(0, (input.Length - 1));
                        ClearLine(Console.CursorLeft, Console.CursorTop);
                        Console.Write(new string(' ', Console.WindowWidth));
                        ClearLine(Console.CursorLeft, Console.CursorTop);
                        for (int i = 0; i < input.Length; i++)
                        {
                            Console.Write("*");
                        }
                    }
                }
            } while (key.Key != ConsoleKey.Enter);
            return input;
        }
        private void ClearLine(int left, int top)
        {
            Console.SetCursorPosition(left, top);
            Console.Write(new string(' ', Console.WindowWidth));
            Console.SetCursorPosition(left, top);
        }
    }
}
