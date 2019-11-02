using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace DungeonCrawlerGame.Graphics
{
    public static class SpriteBatchExtensions
    {
        public static void Draw(this SpriteBatch spriteBatch, Sprite sprite)
        {
            spriteBatch.Draw(sprite.Texture, sprite.Position, sprite.Bounds, Color.White);
        }

        public static void Draw(this SpriteBatch spriteBatch, Sprite sprite, Vector2 position)
        {
            spriteBatch.Draw(sprite.Texture, position, sprite.Bounds, Color.White);
        }
    }
}