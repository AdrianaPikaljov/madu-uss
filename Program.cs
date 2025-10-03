using madu;
using System;
using System.Threading;

namespace Madu
{
    class Program
    {
        static void Main(string[] args)
        {
            bool running = true;

            while (running)
            {
                Menu menu = new Menu();
                menu.NavigateMenu();

                int selectedOption = menu.GetSelectedOption();

                switch (selectedOption)
                {
                    case 0: // Start game
                        StartGame();
                        break;

                    case 1: // Show high scores
                        ShowHighScores();
                        break;

                    case 2: // Exit
                        running = false;
                        Environment.Exit(0);
                        break;
                }
            }
        }

        static void StartGame()
        {
            Console.Clear();

            Console.SetWindowSize(80, 50); 


            // nimi
            Console.SetCursorPosition(0, 0);
            Console.Write("Sisesta oma nimi: ");
            string playerName = Console.ReadLine();
            Player player = new Player(playerName);

            // Joonista
            
            Console.SetCursorPosition(0, 0);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(new string('>', 80));

            // Kustuta
            Console.SetCursorPosition(0, 0);
            Console.Write(new string(' ', 80));

            //  walls
            Console.ForegroundColor = ConsoleColor.Red;
            Walls walls = new Walls(80, 25);
            walls.Draw();

            Obstacles obstacles = new Obstacles();
            obstacles.Draw();

            Console.ResetColor();

            //  snake

            Point p = new Point(4, 5, '*');
            Snake snake = new Snake(p, 4, Direction.Right);
            snake.Draw();
     

            //  food
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            FoodCreator foodCreator = new FoodCreator(80, 25, '$', walls, obstacles, snake);
            Point food = foodCreator.CreateFood();
            food.Draw();
            Console.ResetColor();

            Score score = new Score();
            Level level = new Level();

            bool playing = true;
            while (playing)
            {
                if (walls.IsHit(snake) || obstacles.IsHit(snake) || snake.IsHitTail())
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

                
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.SetCursorPosition(0, 0);
                Console.Write($"SCORE: {score.CurrentScore}");

                Console.SetCursorPosition(20, 0);
                Console.Write($"LEVEL: {level.CurrentLevel}");

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

            
            Console.Clear();
            Sounds gameOverSound = new Sounds();
            gameOverSound.PlayGameOver();

            GameOverScreen gameOver = new GameOverScreen();
            gameOver.Display();

            Console.ForegroundColor = ConsoleColor.Red;
            Console.SetCursorPosition(35, 10);
            Console.WriteLine($"PLAYER: {player.Name}");

            Console.SetCursorPosition(35, 11);
            Console.WriteLine($"SCORE: {score.CurrentScore}");
            Console.ResetColor();

            
            player.SetFinalScore(score.CurrentScore);
            player.SaveResult();

            // paus ja ss menuu
            Thread.Sleep(5000);
        }

        static void ShowHighScores()
        {
            Console.Clear();
            Console.SetCursorPosition(23, 0);
            Console.WriteLine("=== Rekorditabel ===");
            Player.DisplayResults();

            Console.WriteLine("\nVajuta suvalist klahvi, et tagasi minna...");
            Console.ReadKey();
        }
    }
}
