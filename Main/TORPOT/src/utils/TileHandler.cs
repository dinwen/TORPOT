using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Svennebanan
{
    public class TileHandler
    {

        private const int TILESIZE = 32;
        private Dictionary<int, Tile> tiles = new Dictionary<int, Tile>();

        public void AddTile(Tile tile)
        {
            int id = (tile.texturePosition.X + (tile.texturePosition.Y * 15)) / TILESIZE;
            tiles.Add(id, tile);
        }

        public Tile GetTile(int id)
        {
            return tiles[id];
        }
    }
}
