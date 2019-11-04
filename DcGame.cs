using System;
using System.Collections.Generic;
using DungeonCrawlerGame.Actors;
using DungeonCrawlerGame.Actors.Enemies;
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
        SpriteFont font;
        public ResourceManager ResManager { get; set; } = new ResourceManager();

        Player player = new Player(15, 15);

        Camera camera;

        Vector2 cursor = new Vector2(0, 0);

        Random rand = new Random();

        List<Enemy> enemies = new List<Enemy>();

        public DcGame()
        {
            graphics = new GraphicsDeviceManager(this);
            graphics.PreferredBackBufferWidth = 960;
            graphics.PreferredBackBufferHeight = 640;
            graphics.ApplyChanges();

            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            TargetElapsedTime = TimeSpan.FromSeconds(1d / 15d);

            camera = new Camera(new Viewport(0, 0, 640, 640));
            // camera = new Camera(GraphicsDevice.Viewport);
        }

        protected override void Initialize()
        {
            GameMap.LoadMap();
            camera.MoveCamera(new Vector2(player.X * 32, player.Y * 32));
            for (int i = 0; i < 10; i++)
            {
                int x, y;
                do
                {
                    x = rand.Next(0, 30);
                    y = rand.Next(0, 30);
                } while (!GameMap.isEmpty(x, y));
                enemies.Add(new Enemy(x, y));

            }
            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            font = Content.Load<SpriteFont>("Fonts/Consolas");
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

            int playerX = 320;
            int playerY = 320;

            int mouseX = Mouse.GetState().X;
            int mouseY = Mouse.GetState().Y;

            double angle = Math.Atan2(mouseY - playerY, mouseX - playerX) * (180 / Math.PI);
            double result = ((angle > 0 ? angle : 360 + angle) + 22.5) % 360;
            double selectedCell = Math.Floor(result / 45);

            if (selectedCell == 0) cursor = new Vector2((player.X + 1) * 32, (player.Y + 0) * 32);
            if (selectedCell == 1) cursor = new Vector2((player.X + 1) * 32, (player.Y + 1) * 32);
            if (selectedCell == 2) cursor = new Vector2((player.X + 0) * 32, (player.Y + 1) * 32);
            if (selectedCell == 3) cursor = new Vector2((player.X - 1) * 32, (player.Y + 1) * 32);
            if (selectedCell == 4) cursor = new Vector2((player.X - 1) * 32, (player.Y + 0) * 32);
            if (selectedCell == 5) cursor = new Vector2((player.X - 1) * 32, (player.Y - 1) * 32);
            if (selectedCell == 6) cursor = new Vector2((player.X + 0) * 32, (player.Y - 1) * 32);
            if (selectedCell == 7) cursor = new Vector2((player.X + 1) * 32, (player.Y - 1) * 32);

            if (Mouse.GetState().LeftButton == ButtonState.Pressed)
            {
                player.Attacking = true;
                if (GameMap.GetCell((int)cursor.X / 32, (int)cursor.Y / 32).Object is Enemy enemy)
                {
                    player.Attack(enemy);
                }
            }
            else if (Mouse.GetState().LeftButton == ButtonState.Released)
            {
                player.Attacking = false;
            }
             
            if (Mouse.GetState().RightButton == ButtonState.Pressed && player.SP > 0)
            {
                player.Defense = true;
            }
            else if (Mouse.GetState().RightButton == ButtonState.Released)
            {
                player.Defense = false;
            }

            // if (player.Defense)
            // {
            //     player.SP-=2;
            //     if (player.SP <= 0)
            //     {
            //         player.Defense = false;
            //     }
            // }
            // else
            // {
            //     if (player.SP < player.MaxSP)
            //     {
            //         player.SP++;   
            //     }
            // }


            if (!player.Defense)
            {
                if (player.SP < player.MaxSP)
                {
                    player.SP++;   
                }
            }


            foreach (var enemy in enemies)
            {
                if (enemy.IsNearby(player))
                {
                    enemy.Attack(player);
                    // System.Console.WriteLine(player.HP);
                }
            }

            camera.Position = new Vector2(player.X * 32 + 16, player.Y * 32 + 16);
            camera.UpdateCamera(new Viewport(0,0,640,640));

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

                    if (GameMap.GetCell(x, y).Texture == (int)Resources.Texture.Water)
                        spriteBatch.Draw(ResManager.GetSprite(Resources.Texture.Water, rand.Next(0, 5)), position);
                    else 
                        spriteBatch.Draw(ResManager.GetSprite(GameMap.GetCell(x, y).Texture, GameMap.GetCell(x, y).Appearance), position);
                    if (GameMap.GetCell(x, y).Object != null)
                    {
                        if (GameMap.GetCell(x, y).Object is Enemy enemy && enemy.TakingDamage)
                            spriteBatch.Draw(ResManager.GetSprite(GameMap.GetCell(x, y).Object.Texture), position, ResManager.GetSprite(GameMap.GetCell(x, y).Object.Texture).Bounds, Color.Red);
                        else
                            spriteBatch.Draw(ResManager.GetSprite(GameMap.GetCell(x, y).Object.Texture), position);
                    }
                }
            }

            foreach (var item in enemies)
            {
               spriteBatch.Draw(ResManager.GetSprite(Resources.Texture.Health), new Vector2(item.X * 32, item.Y * 32), new Rectangle(ResManager.GetSprite(Resources.Texture.Health).Bounds.X, ResManager.GetSprite(Resources.Texture.Health).Bounds.Y, (int)(32 * item.HP / (float)item.MaxHP), 32), Color.Red); 
            }

            //PLAYER
            spriteBatch.Draw(ResManager.GetSprite(Resources.Texture.Player), new Vector2(player.X * 32, player.Y * 32));
            spriteBatch.Draw(ResManager.GetSprite(Resources.Texture.Target), cursor);
            if (player.Defense)
                spriteBatch.Draw(ResManager.GetSprite(Resources.Texture.Shield), new Vector2(player.X * 32, player.Y * 32));
            if (player.Attacking)
                spriteBatch.Draw(ResManager.GetSprite(Resources.Texture.Sword), new Vector2(player.X * 32, player.Y * 32));
            
            

            spriteBatch.End();


            //GUI
            spriteBatch.Begin();
           
            // spriteBatch.Draw(ResManager.GetSprite(Resources.Texture.Health), new Vector2(player.X * 32, player.Y * 32), new Rectangle(ResManager.GetSprite(Resources.Texture.Health).Bounds.X, ResManager.GetSprite(Resources.Texture.Health).Bounds.Y, (int)(32 * player.HP / (float)player.MaxHP), 32), Color.DarkRed);             
            DrawRectangle(new Rectangle(640, 0, 320, 960), Color.MidnightBlue);

            spriteBatch.DrawString(font, $"{player.HP} / {player.MaxHP}", new Vector2(672, 32), Color.White);
            DrawRectangle(new Rectangle(672, 48, 256, 16), Color.DarkRed);
            DrawRectangle(new Rectangle(672, 48, (int)(256 * player.HP / (float)player.MaxHP), 16), Color.Red);

            spriteBatch.DrawString(font, $"{player.SP} / {player.MaxSP}", new Vector2(672, 96), Color.White);
            DrawRectangle(new Rectangle(672, 112, 256, 16), Color.DarkGreen);
            DrawRectangle(new Rectangle(672, 112, (int)(256 * player.SP / (float)player.MaxSP), 16), Color.Green);
           
            spriteBatch.End();

            base.Draw(gameTime);
        }

        private void DrawRectangle(Rectangle coords, Color color)
        {

            Texture2D rect = new Texture2D(graphics.GraphicsDevice, 1, 1);
            rect.SetData(new[] { Color.White });
            spriteBatch.Draw(rect, coords, color);
        }
    }
}
