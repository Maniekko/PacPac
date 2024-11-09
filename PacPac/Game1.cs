using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace PacPac
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        private Map map = null!;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this)
            {
                IsFullScreen = false,
                SynchronizeWithVerticalRetrace = false,
            };
            InactiveSleepTime = TimeSpan.Zero;
            TargetElapsedTime = TimeSpan.FromSeconds(1 / 60f);

            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // Load the map data
            map = new(File.ReadAllLines(Path.Combine(Content.RootDirectory, "map.txt")));
            // Resize the window to map size
            _graphics.PreferredBackBufferWidth = map.MapTiles[0].Count * 16;
            _graphics.PreferredBackBufferHeight = map.MapTiles.Count * 16;
            // Center the window
            Window.Position = new Point(
                (GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width - _graphics.PreferredBackBufferWidth) / 2,
                (GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height - _graphics.PreferredBackBufferHeight) / 2
            );
            _graphics.ApplyChanges(); // yes it has to be here.
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            // Load textures for tiles
            TileManager.LoadContent(Content);
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);
            _spriteBatch.Begin();

            // Draw map
            int x = 0, y = 0;
            foreach (List<Tile> line in map.MapTiles)
            {
                foreach (Tile tile in line)
                {
                    if (tile.IsVisible)
                    {
                        _spriteBatch.Draw(TileManager.GetTileTexture(tile.TileType), tile.Position * 16, Color.White);
                    }
                    x++;
                }
                x = 0;
                y++;
            }

            _spriteBatch.End();
        }
    }
}
