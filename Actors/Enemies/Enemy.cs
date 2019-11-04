using DungeonCrawlerGame.Map;

namespace DungeonCrawlerGame.Actors.Enemies
{
    public class Enemy : Actor
    {
        public Enemy(int x, int y)
        {
            X = x;
            Y = y;
            HP = MaxHP = 20;
            SP = MaxSP = 1000;
            Solid = true;
            Damage = 2;
            Texture = (int)Resources.Texture.Enemy;
            GameMap.GetCell(x, y).Object = this;
        }  
    }
}