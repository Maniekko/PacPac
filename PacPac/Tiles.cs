using Microsoft.Xna.Framework;

namespace PacPac
{
    public struct Tile(TileType tileType, Vector2 position, bool isVisible = true)
    {
        public TileType TileType = tileType;
        public Vector2 Position = position;
        public bool IsVisible = isVisible;
    }

    public enum TileType
    {
        // World
        Space,            // Empty space, 's' in map.txt (in Content/ folder)
        Wall,             // Tile that no one can pass, 'w'
        Door,             // Tile that only ghosts can pass, 'x' 
        // Collectibles
        Dot,              // Dots that the player must collect, 'd'
        Energizer,        // Power up that makes the player temporarily invincible, 'e'
        Bonus,            // Grants additional score to player. Not used in map.txt and spawns randomly in place of Dots.
        // Special
        Teleport,         // Teleport tile, transfers players and ghosts between each other, 't'. Exactly 2 must exist.
        GhostSpawnpoint,  // Where ghosts (re)spawn, 'g'. At least 1 must exist.
        PlayerSpawnpoint, // Where player (re)spawns, 'p'. Exactly 1 must exist.
    }
}
