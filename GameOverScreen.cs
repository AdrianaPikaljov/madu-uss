using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace madu
{
    public class GameOverScreen
    {
        public void Display()
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.SetCursorPosition(27, 5);
            Console.WriteLine(" ___ ___ _____ ___    ___ _ _ ___ ___ ");
            Console.SetCursorPosition(27, 6);
            Console.WriteLine("| . | .'|     | -_|  | . | | | -_|  _|");
            Console.SetCursorPosition(27, 7);
            Console.WriteLine("|_  |__,|_|_|_|___|  |___|\\_/|___|_|  ");
            Console.SetCursorPosition(27, 8);
            Console.WriteLine("|___|                                  ");
            Console.ResetColor();
        }
    }
}
