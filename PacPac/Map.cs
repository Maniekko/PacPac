using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace PacPac
{
    public class Map
    {
        private readonly Dictionary<char, TileType> mapTiles = new()
        {
            { 'w', TileType.Wall },
            { 'd', TileType.Dot },
            { 'x', TileType.Door },
            { 's', TileType.Space },
            { 't', TileType.Teleport },
            { 'e', TileType.Energizer },
            { 'g', TileType.GhostSpawnpoint },
            { 'p', TileType.PlayerSpawnpoint },
        };

        public readonly List<List<Tile>> MapTiles = [];

        public Map(string[] mapString)
        {
            int x = 0, y = 0;
            foreach (string tileLine in mapString)
            {
                List<Tile> tiles = [];
                foreach (char tile in tileLine)
                {
                    TileType type = mapTiles[tile];
                    bool isVisible = type switch
                    {
                        TileType.Space => false,
                        TileType.Teleport => false,
                        TileType.GhostSpawnpoint => false,
                        TileType.PlayerSpawnpoint => false,
                        _ => true
                    };

                    tiles.Add(new Tile(type, new Vector2(x, y), isVisible));
                    x++;
                }
                MapTiles.Add(tiles);
                x = 0;
                y++;
            }
        }
    }
}
