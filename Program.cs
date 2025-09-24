using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace madu
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.SetWindowSize(80, 25);
            Console.SetBufferSize(80, 25);

            HorizontalLine line = new HorizontalLine(0, 78, 0, '+');
            line.Draw();
            HorizontalLine line0 = new HorizontalLine(0, 78, 24, '+');
            line0.Draw();
            VerticalLine line1 = new VerticalLine(0, 24, 0, '+');
            line1.Draw();
            VerticalLine line2 = new VerticalLine(0, 24, 78, '+');
            line2.Draw();

            Point p = new Point(4, 5, '*');
            Snake snake = new Snake(p, 5, Direction.Right);
            snake.Draw();


            while (true)
            {
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo key = Console.ReadKey();
                    snake.HandlKey(key.Key);

                }
                Thread.Sleep(100);
                snake.Move();
            }
            Console.ReadKey();
        }
    }
}
