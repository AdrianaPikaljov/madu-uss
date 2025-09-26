using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace madu
{
    class Level
    {
        public int CurrentLevel { get; set; }
        public int Speed { get; set; }

        public Level()
        {
            CurrentLevel = 1;
            Speed = 150; // начальная 
        }

        public void LevelUp()
        {
            CurrentLevel++;
            Speed = Math.Max(50, Speed - 30);
        }

        public void DisplayLevel(int x, int y)
        {
            Console.SetCursorPosition(x, y);
        }
    }
}

