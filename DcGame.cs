using System;
using System.Collections.Generic;
using DungeonCrawlerGame.Actors;
using DungeonCrawlerGame.Graphics;
using DungeonCrawlerGame.Map;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace DungeonCrawlerGame
{
    public class DcGame : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        SpriteFont spriteFont;
        Texture2D spriteSheet;

        // List<Sprite> sprites = new List<Sprite>();

        Dictionary<MapTexture, Sprite> mapSprites = new Dictionary<MapTexture, Sprite>();
        Dictionary<ActorTexture, Sprite> actorSprites = new Dictionary<ActorTexture, Sprite>();

        Player player = new Player();

        Camera camera;

        public DcGame()
        {
            graphics = new GraphicsDeviceManager(this);
            graphics.PreferredBackBufferWidth = 640;
            graphics.PreferredBackBufferHeight = 640;
            graphics.ApplyChanges();

            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            TargetElapsedTime = TimeSpan.FromSeconds(1d / 15d);

            camera = new Camera(GraphicsDevice.Viewport);
        }

        protected override void Initialize()
        {
            GameMap.LoadMap();
            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            spriteFont = Content.Load<SpriteFont>("Fonts/Consolas");
            spriteSheet = Content.Load<Texture2D>("Sprites/spritesheet");

            mapSprites.Add(MapTexture.Grass, new Sprite(spriteSheet, new Rectangle(448, 288, 32, 32)));
            mapSprites.Add(MapTexture.Wall, new Sprite(spriteSheet, new Rectangle(0, 608, 32, 32)));
            mapSprites.Add(MapTexture.Tree, new Sprite(spriteSheet, new Rectangle(1568, 160, 32, 32)));
            mapSprites.Add(MapTexture.Water, new Sprite(spriteSheet, new Rectangle(32, 736, 32, 32)));
            mapSprites.Add(MapTexture.Floor, new Sprite(spriteSheet, new Rectangle(544, 192, 32, 32)));

            actorSprites.Add(ActorTexture.Player, new Sprite(spriteSheet, new Rectangle(1952, 2528, 32, 32)));
        }

        protected override void Update(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            if (Keyboard.GetState().IsKeyDown(Keys.W))
            {
                player.Move(Direction.Up);
                camera.MoveCamera(new Vector2(0, -32));
            }
            if (Keyboard.GetState().IsKeyDown(Keys.S))
            {
                player.Move(Direction.Down);
                camera.MoveCamera(new Vector2(0, 32));
            }
            if (Keyboard.GetState().IsKeyDown(Keys.A))
            {
                player.Move(Direction.Left);
                camera.MoveCamera(new Vector2(-32, 0));
            }
            if (Keyboard.GetState().IsKeyDown(Keys.D))
            {
                player.Move(Direction.Right);
                camera.MoveCamera(new Vector2(32, 0));
            }

            camera.UpdateCamera(GraphicsDevice.Viewport);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            spriteBatch.Begin(transformMatrix: camera.Transform);

            Vector2 position = Vector2.Zero;

            for (int y = 0; y < GameMap.Map.GetLength(0); y++)
            {
                for (int x = 0; x < GameMap.Map.GetLength(1); x++)
                {
                    position.X = x * 32;
                    position.Y = y * 32;

                    spriteBatch.Draw(mapSprites[(MapTexture)GameMap.Map[y, x]], position);
                }
            }

            spriteBatch.Draw(actorSprites[ActorTexture.Player], new Vector2(player.X * 32, player.Y * 32));

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
