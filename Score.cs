using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace madu
{
    class Score
    {
        public int CurrentScore { get; private set; }

        public Score() => CurrentScore = 0;

        public void EatFood() => CurrentScore++;

        public void Reset() => CurrentScore = 0;

        public void DisplayScore(int x, int y)
        {
            Console.SetCursorPosition(x, y);
            Console.WriteLine($"score: {CurrentScore}   ");
        }
    }
}
