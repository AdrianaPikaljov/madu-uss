using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace madu
{
    class Level
    {
        public int CurrentLevel { get; private set; }
        public int Speed { get; private set; }

        public Level()
        {
            CurrentLevel = 1;
            Speed = 150; // начальная задержка
        }

        public void LevelUp()
        {
            CurrentLevel++;
            Speed = Math.Max(50, Speed - 10);
        }

        public void DisplayLevel(int x, int y)
        {
            Console.SetCursorPosition(x, y);
            Console.WriteLine($"level: {CurrentLevel}   ");
        }
    }
}

