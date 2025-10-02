using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace madu
{
    using System;


    class FoodCreator
    {
        int mapWidht;
        int mapHeight;
        char sym;

        Random random = new Random();
        Walls walls;
        Obstacles obstacles;
        Snake snake;

        public FoodCreator(int mapWidth, int mapHeight, char sym, Walls walls, Obstacles obstacles, Snake snake)
        {
            this.mapWidht = mapWidth;
            this.mapHeight = mapHeight;
            this.sym = sym;
            this.walls = walls;
            this.obstacles = obstacles;
            this.snake = snake;
        }

        public Point CreateFood()
        {
            Point food;

            do
            {
                int x = random.Next(2, mapWidht - 2);
                int y = random.Next(2, mapHeight - 1);
                food = new Point(x, y, sym);
            }
            while (walls.IsHit(food) || obstacles.IsPointInObstacle(food) || IsOnSnake(food));

            return food;
        }

        private bool IsOnSnake(Point point)
        {
            foreach (var p in snake.GetPoints())
            {
                if (p.IsHit(point))
                    return true;
            }
            return false;
        }
    }
}
