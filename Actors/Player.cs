using DungeonCrawlerGame.Map;

namespace DungeonCrawlerGame.Actors
{
    public class Player : Actor
    {
        public Player(int x, int y)
        {
            X = x;
            Y = y;
            HP = MaxHP = 100;
            SP = MaxSP = 100;
            Damage = 10;
            Solid = true;
            Texture = (int)Resources.Texture.Player;
        }   
    }
}