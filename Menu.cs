using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace madu
{
    using System;

    public class Menu
    {
        private int selectedOption;
        private string[] options = { "Alusta mängu", "Vaata rekordid", "Välju" };

        public Menu()
        {
            selectedOption = 0; 
        }

        public void ShowMenu()
        {
            Console.Clear();
            Console.SetWindowSize(90, 25);
            Console.SetBufferSize(90, 25);
            Console.CursorVisible = false;

            // Title
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.SetCursorPosition(20, 5);
            Console.WriteLine("  ________  _____  ___        __       __   ___  _______  ");
            Console.SetCursorPosition(20, 6);
            Console.WriteLine(" /\"       )(\"   \\|\"  \\      /\"\"\\     |/\"| /  \")/\"     \"| ");
            Console.SetCursorPosition(20, 7);
            Console.WriteLine("(:   \\___/ |.\\\\   \\    |    /    \\    (: |/   /(: ______) ");
            Console.SetCursorPosition(20, 8);
            Console.WriteLine(" \\___  \\   |: \\.   \\\\  |   /' /\\  \\   |    __/  \\/    |   ");
            Console.SetCursorPosition(20, 9);
            Console.WriteLine("  __/  \\\\  |.  \\    \\. |  //  __'  \\  (// _  \\  // ___)_  ");
            Console.SetCursorPosition(20, 10);
            Console.WriteLine(" /\" \\   :) |    \\    \\ | /   /  \\\\  \\ |: | \\  \\(:      \"| ");
            Console.SetCursorPosition(20, 11);
            Console.WriteLine("(_______/   \\___|\\____\\)(___/    \\___)(__|  \\__)\\_______) ");


            for (int i = 0; i < options.Length; i++)
            {
                Console.SetCursorPosition(35, 13 + i);

                if (i == selectedOption)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("► ");  
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    Console.Write("  ");  
                }

                Console.WriteLine(options[i]);
                Console.ResetColor();
            }
        }

        public int GetSelectedOption()
        {
            return selectedOption;
        }

        public void NavigateMenu()
        {
            bool isNavigating = true;
            while (isNavigating)
            {
                ShowMenu();
                ConsoleKeyInfo key = Console.ReadKey(true);

                if (key.Key == ConsoleKey.UpArrow)
                {
                    selectedOption = (selectedOption == 0) ? options.Length - 1 : selectedOption - 1;
                }
                else if (key.Key == ConsoleKey.DownArrow)
                {
                    selectedOption = (selectedOption == options.Length - 1) ? 0 : selectedOption + 1;
                }
                else if (key.Key == ConsoleKey.Enter)
                {
                    isNavigating = false;  
                }
            }
        }
    }

}
