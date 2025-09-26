using madu;
using System;
using System.Threading;

namespace Madu
{
    class Program
    {
        static void Main(string[] args)
        {
            Menu menu = new Menu();
            menu.NavigateMenu();

            // Get selected option
            int selectedOption = menu.GetSelectedOption();

            switch (selectedOption)
            {
                case 0: // Start game
                    StartGame();  // Start the game after name input
                    break;

                case 1: // Show high scores
                    ShowHighScores();
                    break;

                case 2: // Exit
                    Environment.Exit(0);
                    break;
            }
        }

        static void StartGame()
        {
            Console.Clear();

            // Ask for player name before starting the game
            Console.SetCursorPosition(0, 0);
            Console.Write("Sisesta oma nimi: ");
            string playerName = Console.ReadLine();
            Player player = new Player(playerName);

            // Clear the first row after name input
            Console.SetCursorPosition(0, 0);
            Console.Write(new string(' ', 80)); // Clear the first row

            // Draw game field after name input
            Console.ForegroundColor = ConsoleColor.Yellow;
            Walls walls = new Walls(80, 25);
            walls.Draw();
            Console.ResetColor();

            // Setup game objects
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Point p = new Point(4, 5, '*');
            Snake snake = new Snake(p, 4, Direction.Right);
            snake.Draw();
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.DarkGreen;
            FoodCreator foodCreator = new FoodCreator(80, 25, '$');
            Point food = foodCreator.CreateFood();
            food.Draw();
            Console.ResetColor();

            Score score = new Score();
            Level level = new Level();

            bool playing = true;
            while (playing)
            {
                if (walls.IsHit(snake) || snake.IsHitTail())
                {
                    playing = false;
                    break;
                }

                Sounds sounds = new Sounds();
                if (snake.Eat(food))
                {
                    sounds.PlayEat();
                    score.EatFood();
                    food = foodCreator.CreateFood();
                    Console.ForegroundColor = ConsoleColor.Green;
                    food.Draw();
                    Console.ResetColor();

                    if (score.CurrentScore % 5 == 0)
                    {
                        level.LevelUp();
                    }
                }
                else
                {
                    snake.Move();
                }

                // Display score, level, and player name with different colors
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.SetCursorPosition(0, 0);
                Console.Write($"SCORE: {score.CurrentScore}");

                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.SetCursorPosition(20, 0);
                Console.Write($"LEVEL: {level.CurrentLevel}");

                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.SetCursorPosition(40, 0);
                Console.Write($"PLAYER: {player.Name}");
                Console.ResetColor();

                level.DisplayLevel(60, 0);

                Thread.Sleep(level.Speed);

                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo key = Console.ReadKey(true);
                    snake.HandleKey(key.Key);
                }
            }

            // End of the game display
            Console.Clear();

            Console.ForegroundColor = ConsoleColor.Red;
            Console.SetCursorPosition(35, 5);
            Console.WriteLine("=== GAME OVER ===");
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.SetCursorPosition(35, 6);
            Console.WriteLine($"PLAYER: {player.Name}");

            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.SetCursorPosition(35, 7);
            Console.WriteLine($"SCORE: {score.CurrentScore}");
            Console.ResetColor();

            player.SetFinalScore(score.CurrentScore);
            player.SaveResult();

            Console.WriteLine("\nTabel rekorditega:");
            Player.DisplayResults();

            Console.WriteLine("\nVajuta suvalist klahvi, et väljuda...");
            Console.ReadKey();
        }

        static void ShowHighScores()
        {
            Console.Clear();
            Console.SetCursorPosition(35, 5);
            Console.WriteLine("=== Rekorditabel ===");
            // Display high scores (implement as per your game logic)
            Player.DisplayResults();

            Console.WriteLine("\nVajuta suvalist klahvi, et tagasi minna...");
            Console.ReadKey();
        }
    }
}
