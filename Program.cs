using System;
using System.Threading;

namespace madu
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.SetWindowSize(80, 25);
            Console.SetBufferSize(80, 25);
            Console.CursorVisible = false;

            Walls walls = new Walls(80, 25);
            walls.Draw();

            // начальные параметры
            Point p = new Point(4, 5, '*');
            Snake snake = new Snake(p, 4, Direction.Right);
            snake.Draw();

            FoodCreator foodCreator = new FoodCreator(80, 25, '$');
            Point food = foodCreator.CreateFood();
            food.Draw();

            // классы игрока, уровня и очков
            Console.SetCursorPosition(0, 0);
            Console.Write("kirjuta nimi: ");
            string playerName = Console.ReadLine();
            Player player = new Player(playerName);

            Score score = new Score();
            Level level = new Level();

            bool playing = true;
            while (playing)
            {
                // проверка на проигрыш
                if (walls.IsHit(snake) || snake.IsHitTail())
                {
                    playing = false;
                    break;
                }

                // если змейка съела еду
                if (snake.Eat(food))
                {
                    score.EatFood();
                    food = foodCreator.CreateFood();
                    food.Draw();

                    // каждые 5 очков – новый уровень
                    if (score.CurrentScore % 5 == 0)
                    {
                        level.LevelUp();
                    }
                }
                else
                {
                    snake.Move();
                }

                // отображение очков и уровня
                score.DisplayScore(2, 0);
                level.DisplayLevel(2, 1);

                Thread.Sleep(level.Speed);

                // управление
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo key = Console.ReadKey(true);
                    snake.HandleKey(key.Key);
                }
            }

            // конец игры
            Console.Clear();
            Console.WriteLine("=== game over ===");
            Console.WriteLine($"player: {player.Name}");
            Console.WriteLine($"score: {score.CurrentScore}");

            // сохранить результат
            player.SetFinalScore(score.CurrentScore);
            player.SaveResult();

            Console.WriteLine("\ntabel rekorditega:");
            Player.DisplayResults();

            Console.WriteLine("\nvajuta suvalist nuppu et valjuda");
            Console.ReadKey();
        }
    }
}
