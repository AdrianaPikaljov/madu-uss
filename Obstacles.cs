using System;
using System.Collections.Generic;

namespace madu
{
    class Obstacles
    {
        List<Figure> obstacleList;

        public Obstacles()
        {
            obstacleList = new List<Figure>();

            obstacleList.Add(new HorizontalLine(20, 30, 10, '#'));
            obstacleList.Add(new HorizontalLine(50, 60, 15, '#'));
            obstacleList.Add(new HorizontalLine(10, 25, 20, '#'));
            obstacleList.Add(new VerticalLine(35, 40, 25, '#'));
            obstacleList.Add(new VerticalLine(5, 15, 45, '#'));
        }

        public void Draw()
        {
            foreach (var obs in obstacleList)
            {
                obs.Draw();
            }
        }

        public bool IsHit(Figure figure)
        {
            foreach (var obs in obstacleList)
            {
                if (obs.IsHit(figure))
                    return true;
            }
            return false;
        }

        public bool IsPointInObstacle(Point point)
        {
            foreach (var obs in obstacleList)
            {
                foreach (var p in obs.GetPoints())
                {
                    if (p.IsHit(point))
                        return true;
                }
            }
            return false;
        }

        public List<Point> GetAllPoints()
        {
            List<Point> all = new List<Point>();
            foreach (var obs in obstacleList)
            {
                all.AddRange(obs.GetPoints());
            }
            return all;
        }
    }
}

