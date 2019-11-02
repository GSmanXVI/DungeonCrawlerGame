using System;
using System.Collections.Generic;
using DungeonCrawlerGame.Actors;
using DungeonCrawlerGame.Graphics;
using DungeonCrawlerGame.Map;
using DungeonCrawlerGame.Objects;
using DungeonCrawlerGame.Resources;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace DungeonCrawlerGame
{
    public class DcGame : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        public ResourceManager ResManager { get; set; } = new ResourceManager();

        Player player = new Player(15, 15);

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
            camera.MoveCamera(new Vector2(player.X * 32, player.Y * 32));
            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            ResManager.InitResources(Content);
        }

        protected override void Update(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            if (Keyboard.GetState().IsKeyDown(Keys.W))
                player.Move(Direction.Up);
            if (Keyboard.GetState().IsKeyDown(Keys.S))
                player.Move(Direction.Down);
            if (Keyboard.GetState().IsKeyDown(Keys.A))
                player.Move(Direction.Left);
            if (Keyboard.GetState().IsKeyDown(Keys.D))
                player.Move(Direction.Right);

            camera.Position = new Vector2(player.X * 32, player.Y * 32);

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

                    spriteBatch.Draw(ResManager.GetSprite(GameMap.GetCell(x, y).Texture), position);
                    if (GameMap.GetCell(x, y).Object != null)
                        spriteBatch.Draw(ResManager.GetSprite(GameMap.GetCell(x, y).Object.Texture), position);
                }
            }

            spriteBatch.Draw(ResManager.GetSprite(Resources.Texture.Player), new Vector2(player.X * 32, player.Y * 32));

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
