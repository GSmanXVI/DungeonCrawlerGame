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

        Dictionary<int, List<Sprite>> spriteGroups;
        // Dictionary<int, Sprite> objectSprites = new Dictionary<int, Sprite>();

        public void InitResources(ContentManager content)
        {
            spriteGroups = new Dictionary<int, List<Sprite>>();

            spriteFont = content.Load<SpriteFont>("Fonts/Consolas");
            spriteSheet = content.Load<Texture2D>("Sprites/spritesheet");

            spriteGroups.Add((int)Resources.Texture.Grass, new List<Sprite>());
            spriteGroups[(int)Resources.Texture.Grass].Add(new Sprite(spriteSheet, new Rectangle(448, 288, 32, 32)));
            spriteGroups[(int)Resources.Texture.Grass].Add(new Sprite(spriteSheet, new Rectangle(512, 288, 32, 32)));
            spriteGroups[(int)Resources.Texture.Grass].Add(new Sprite(spriteSheet, new Rectangle(576, 288, 32, 32)));
            spriteGroups[(int)Resources.Texture.Grass].Add(new Sprite(spriteSheet, new Rectangle(704, 288, 32, 32)));
            spriteGroups[(int)Resources.Texture.Grass].Add(new Sprite(spriteSheet, new Rectangle(768, 288, 32, 32)));
            spriteGroups[(int)Resources.Texture.Grass].Add(new Sprite(spriteSheet, new Rectangle(832, 288, 32, 32)));
            spriteGroups[(int)Resources.Texture.Grass].Add(new Sprite(spriteSheet, new Rectangle(896, 288, 32, 32)));
            spriteGroups[(int)Resources.Texture.Grass].Add(new Sprite(spriteSheet, new Rectangle(960, 288, 32, 32)));
            spriteGroups[(int)Resources.Texture.Grass].Add(new Sprite(spriteSheet, new Rectangle(1024, 288, 32, 32)));
            spriteGroups[(int)Resources.Texture.Grass].Add(new Sprite(spriteSheet, new Rectangle(1088, 288, 32, 32)));
            spriteGroups[(int)Resources.Texture.Grass].Add(new Sprite(spriteSheet, new Rectangle(1152, 288, 32, 32)));
            spriteGroups[(int)Resources.Texture.Grass].Add(new Sprite(spriteSheet, new Rectangle(1216, 288, 32, 32)));
            spriteGroups[(int)Resources.Texture.Grass].Add(new Sprite(spriteSheet, new Rectangle(1280, 288, 32, 32)));
            spriteGroups[(int)Resources.Texture.Grass].Add(new Sprite(spriteSheet, new Rectangle(1344, 288, 32, 32)));

            spriteGroups.Add((int)Resources.Texture.Wall, new List<Sprite>());
            spriteGroups[(int)Resources.Texture.Wall].Add(new Sprite(spriteSheet, new Rectangle(0, 608, 32, 32)));
            spriteGroups[(int)Resources.Texture.Wall].Add(new Sprite(spriteSheet, new Rectangle(32, 608, 32, 32)));
            spriteGroups[(int)Resources.Texture.Wall].Add(new Sprite(spriteSheet, new Rectangle(64, 608, 32, 32)));
            spriteGroups[(int)Resources.Texture.Wall].Add(new Sprite(spriteSheet, new Rectangle(96, 608, 32, 32)));
            spriteGroups[(int)Resources.Texture.Wall].Add(new Sprite(spriteSheet, new Rectangle(128, 608, 32, 32)));
            spriteGroups[(int)Resources.Texture.Wall].Add(new Sprite(spriteSheet, new Rectangle(160, 608, 32, 32)));
            spriteGroups[(int)Resources.Texture.Wall].Add(new Sprite(spriteSheet, new Rectangle(192, 608, 32, 32)));

            spriteGroups.Add((int)Resources.Texture.Water, new List<Sprite>());
            spriteGroups[(int)Resources.Texture.Water].Add(new Sprite(spriteSheet, new Rectangle(32, 736, 32, 32)));
            spriteGroups[(int)Resources.Texture.Water].Add(new Sprite(spriteSheet, new Rectangle(64, 736, 32, 32)));
            spriteGroups[(int)Resources.Texture.Water].Add(new Sprite(spriteSheet, new Rectangle(96, 736, 32, 32)));
            spriteGroups[(int)Resources.Texture.Water].Add(new Sprite(spriteSheet, new Rectangle(128, 736, 32, 32)));
            spriteGroups[(int)Resources.Texture.Water].Add(new Sprite(spriteSheet, new Rectangle(160, 736, 32, 32)));
            // spriteGroups[(int)Resources.Texture.Water].Add(new Sprite(spriteSheet, new Rectangle(192, 736, 32, 32)));
            // spriteGroups[(int)Resources.Texture.Water].Add(new Sprite(spriteSheet, new Rectangle(256, 736, 32, 32)));
            // spriteGroups[(int)Resources.Texture.Water].Add(new Sprite(spriteSheet, new Rectangle(320, 736, 32, 32)));

            spriteGroups.Add((int)Resources.Texture.Floor, new List<Sprite>());
            spriteGroups[(int)Resources.Texture.Floor].Add(new Sprite(spriteSheet, new Rectangle(544, 192, 32, 32)));

            spriteGroups.Add((int)Resources.Texture.Player, new List<Sprite>());
            spriteGroups[(int)Resources.Texture.Player].Add(new Sprite(spriteSheet, new Rectangle(1952, 2528, 32, 32)));

            spriteGroups.Add((int)Resources.Texture.Enemy, new List<Sprite>());
            spriteGroups[(int)Resources.Texture.Enemy].Add(new Sprite(spriteSheet, new Rectangle(992, 1952, 32, 32)));

                        spriteGroups.Add((int)Resources.Texture.Dead, new List<Sprite>());
            spriteGroups[(int)Resources.Texture.Dead].Add(new Sprite(spriteSheet, new Rectangle(256, 1280, 32, 32)));

            spriteGroups.Add((int)Resources.Texture.Tree, new List<Sprite>());
            spriteGroups[(int)Resources.Texture.Tree].Add(new Sprite(spriteSheet, new Rectangle(480, 416, 32, 32)));

            spriteGroups.Add((int)Resources.Texture.Target, new List<Sprite>());
            spriteGroups[(int)Resources.Texture.Target].Add(new Sprite(spriteSheet, new Rectangle(1760, 1568, 32, 32)));

            spriteGroups.Add((int)Resources.Texture.Health, new List<Sprite>());
            spriteGroups[(int)Resources.Texture.Health].Add(new Sprite(spriteSheet, new Rectangle(736, 3008, 32, 32)));

            spriteGroups.Add((int)Resources.Texture.Shield, new List<Sprite>());
            spriteGroups[(int)Resources.Texture.Shield].Add(new Sprite(spriteSheet, new Rectangle(128, 2752, 32, 32)));

            spriteGroups.Add((int)Resources.Texture.Sword, new List<Sprite>());
            spriteGroups[(int)Resources.Texture.Sword].Add(new Sprite(spriteSheet, new Rectangle(992, 2816, 32, 32)));
        }

        public Sprite GetSprite(Texture texture, int appearence = 0)
        {
            return GetSprite((int)texture, appearence);
        }

        public Sprite GetSprite(int textureCode, int appearence = 0)
        {
            return spriteGroups[textureCode][appearence];
        }
    }
}