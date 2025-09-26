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
            selectedOption = 0; // Start with the first option selected
        }

        public void ShowMenu()
        {
            Console.Clear();
            Console.SetWindowSize(90, 25);
            Console.SetBufferSize(90, 25);
            Console.CursorVisible = false;

            // Title
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.SetCursorPosition(35, 5);
            Console.WriteLine("=== SNAKE ===");

            // Display menu options
            for (int i = 0; i < options.Length; i++)
            {
                if (i == selectedOption)
                {
                    Console.BackgroundColor = ConsoleColor.Gray;
                    Console.ForegroundColor = ConsoleColor.Red;
                }
                else
                {
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                }

                Console.SetCursorPosition(35, 7 + i);
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
                    isNavigating = false;  // Stop navigating when Enter is pressed
                }
            }
        }
    }

}
