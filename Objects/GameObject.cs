using Microsoft.Xna.Framework;

namespace DungeonCrawlerGame.Objects
{
    public class GameObject
    {
        public int Texture { get; set; }
        public string Name { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public bool Solid { get; set; }
    }
}