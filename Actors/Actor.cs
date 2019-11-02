using Microsoft.Xna.Framework;

namespace DungeonCrawlerGame.Actors
{
    public class Actor
    {
        public int X { get; set; }
        public int Y { get; set; }

        public void Move(Direction direction)
        {
            switch (direction)
            {
                case Direction.Up:
                    Y--;
                    break;
                case Direction.Down:
                    Y++;
                    break;
                case Direction.Left:
                    X--;
                    break;
                case Direction.Right:
                    X++;
                    break;
            }
        }
        
    }
}