namespace madu
{
    class Walls
    {
        List<Figure> wallList;

        public Walls(int mapWidth, int mapHeight)
        {
            wallList = new List<Figure>();

            // Skip the first row (0) so score can be displayed
            HorizontalLine upLine = new HorizontalLine(0, mapWidth - 2, 1, '+');   // start at row 1
            HorizontalLine downLine = new HorizontalLine(0, mapWidth - 2, mapHeight - 1, '+');

            // Skip row 0, so vertical walls start at row 1 and end at bottom - 1
            VerticalLine leftLine = new VerticalLine(1, mapHeight - 2, 0, '+');    // col 0
            VerticalLine rightLine = new VerticalLine(1, mapHeight - 2, mapWidth - 2, '+'); // right wall

            wallList.Add(upLine);
            wallList.Add(downLine);
            wallList.Add(leftLine);
            wallList.Add(rightLine);
        }

        internal bool IsHit(Figure figure)
        {
            foreach (var wall in wallList)
            {
                if (wall.IsHit(figure))
                {
                    return true;
                }
            }
            return false;
        }

        public void Draw()
        {
            foreach (var wall in wallList)
            {
                wall.Draw();
            }
        }
    }
}