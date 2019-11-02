using System.Collections.Generic;
using DungeonCrawlerGame.Graphics;
using DungeonCrawlerGame.Objects;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace DungeonCrawlerGame.Resources
{
    public class ResourceManager
    {
        SpriteFont spriteFont;
        Texture2D spriteSheet;

        Dictionary<int, Sprite> mapSprites = new Dictionary<int, Sprite>();
        // Dictionary<int, Sprite> objectSprites = new Dictionary<int, Sprite>();

        public void InitResources(ContentManager content)
        {
            spriteFont = content.Load<SpriteFont>("Fonts/Consolas");
            spriteSheet = content.Load<Texture2D>("Sprites/spritesheet");

            mapSprites.Add((int)Resources.Texture.Grass, new Sprite(spriteSheet, new Rectangle(448, 288, 32, 32)));
            mapSprites.Add((int)Resources.Texture.Wall, new Sprite(spriteSheet, new Rectangle(0, 608, 32, 32)));
            mapSprites.Add((int)Resources.Texture.Water, new Sprite(spriteSheet, new Rectangle(32, 736, 32, 32)));
            mapSprites.Add((int)Resources.Texture.Floor, new Sprite(spriteSheet, new Rectangle(544, 192, 32, 32)));
            mapSprites.Add((int)Resources.Texture.Player, new Sprite(spriteSheet, new Rectangle(1952, 2528, 32, 32)));
            mapSprites.Add((int)Resources.Texture.Tree, new Sprite(spriteSheet, new Rectangle(480, 416, 32, 32)));

            // objectSprites.Add((int)Resources.Texture.Player, new Sprite(spriteSheet, new Rectangle(1952, 2528, 32, 32)));
            // objectSprites.Add((int)Resources.Texture.Tree, new Sprite(spriteSheet, new Rectangle(480, 416, 32, 32)));
        }

        public Sprite GetSprite(Texture texture)
        {
            return GetSprite((int)texture);
        }

        public Sprite GetSprite(int textureCode)
        {
            return mapSprites[textureCode];
        }
    }
}