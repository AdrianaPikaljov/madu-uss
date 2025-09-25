using System;
using System.Threading;
using System.Media;
using madu;

Console.SetWindowSize(90, 25);
Console.SetBufferSize(90, 25);
Console.CursorVisible = false;

Walls walls = new Walls(80, 25);
walls.Draw();

// Küsi mängija nime enne mängu alustamist
Console.SetCursorPosition(0, 0);
Console.Write("Sisesta nimi: ");
string playerName = Console.ReadLine();
Player player = new Player(playerName);

// Tühjendame ülemise rea pärast nime sisestust
Console.SetCursorPosition(0, 0);
Console.Write(new string(' ', 80));

// Mängu objektid
Point p = new Point(4, 5, '*');
Snake snake = new Snake(p, 4, Direction.Right);
snake.Draw();

FoodCreator foodCreator = new FoodCreator(80, 25, '$');
Point food = foodCreator.CreateFood();
food.Draw();

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

    if (snake.Eat(food))
    {
        // Replace the problematic code with the following:  
        //var nam = new SoundPlayer("eat.wav");
        //nam.Load();
        //nam.Play();
        //nam.PlaySync();

        score.EatFood();
        food = foodCreator.CreateFood();
        food.Draw();

        if (score.CurrentScore % 5 == 0)
        {
            level.LevelUp();
        }
    }
    else
    {
        snake.Move();
    }

    // === Kuvame skoori ja mängija nime ülemises reas ===
    Console.SetCursorPosition(0, 0);
    Console.Write($"Skoor: {score.CurrentScore}   Tase: {level.CurrentLevel}");

    Console.SetCursorPosition(40, 0);
    Console.Write($"Mängija: {player.Name}");

    Thread.Sleep(level.Speed);

    if (Console.KeyAvailable)
    {
        ConsoleKeyInfo key = Console.ReadKey(true);
        snake.HandleKey(key.Key);
    }
}
BonusFood bonusFood = new BonusFood(10, 5, '@');
Console.WriteLine("BonusFood created!");

// Kontrollime iga sekundi tagant, kas bonus toit on aegunud
while (true)
{
    if (bonusFood.IsExpired())
    {
        Console.WriteLine("BonusFood is expired.");
        break;
    }
    else
    {
        Console.WriteLine("BonusFood is still valid.");
    }
    System.Threading.Thread.Sleep(1000); // ootab 1 sekundi
}


// Mäng läbi
Console.Clear();
Console.WriteLine("=== MÄNG LÄBI ===");
Console.WriteLine($"Mängija: {player.Name}");
Console.WriteLine($"Skoor: {score.CurrentScore}");

player.SetFinalScore(score.CurrentScore);
player.SaveResult();

Console.WriteLine("\nTabel rekorditega:");
Player.DisplayResults();

Console.WriteLine("\nVajuta suvalist klahvi, et väljuda...");
Console.ReadKey();
