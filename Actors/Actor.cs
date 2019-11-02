using DungeonCrawlerGame.Map;
using DungeonCrawlerGame.Objects;

namespace DungeonCrawlerGame.Actors
{
    public class Actor : GameObject
    {
        public void Move(Direction direction)
        {

            switch (direction)
            {
                case Direction.Up:
                    if (GameMap.isEmpty(X, Y - 1))
                        Y--;
                    break;
                case Direction.Down:
                    if (GameMap.isEmpty(X, Y + 1))
                        Y++;
                    break;
                case Direction.Left:
                    if (GameMap.isEmpty(X - 1, Y))
                        X--;
                    break;
                case Direction.Right:
                    if (GameMap.isEmpty(X + 1, Y))
                        X++;
                    break;
            }
        }
    }
}