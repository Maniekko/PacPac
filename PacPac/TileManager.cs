using System.Collections.Generic;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace PacPac
{
    public static class TileManager
    {
        private static readonly Dictionary<TileType, Texture2D> tileTextures = [];

        public static void LoadContent(ContentManager manager)
        {
            tileTextures[TileType.Wall] = manager.Load<Texture2D>("wall");
            tileTextures[TileType.Door] = manager.Load<Texture2D>("door");
            tileTextures[TileType.Dot] = manager.Load<Texture2D>("dot");
            tileTextures[TileType.Bonus] = manager.Load<Texture2D>("bonus");
            tileTextures[TileType.Energizer] = manager.Load<Texture2D>("energizer");
        }

        public static Texture2D GetTileTexture(TileType tileType)
        {
            return tileTextures[tileType];
        }
    }
}
