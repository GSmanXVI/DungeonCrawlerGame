using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace DungeonCrawlerGame.Graphics
{
    public class Sprite
    {
        public Texture2D Texture { get; set; }
        public Vector2 Position { get; set; }
        public Vector2 Origin { get; set; }
        public Rectangle Bounds { get; set; }

        public Sprite(Texture2D texture, Rectangle bounds)
        {
            Texture = texture;
            Position = Vector2.Zero;
            Origin = Vector2.Zero;
            Bounds = bounds;
        }
    }
}