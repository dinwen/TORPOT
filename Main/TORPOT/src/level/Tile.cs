using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Svennebanan
{
    public class Tile
    {

        public Vector2 position;
        public Rectangle texturePosition;
        public Rectangle collision, offset;
        public bool solid;

        public Tile(int texPosX, int texPosY, Rectangle offset, bool solid)
        {
            this.texturePosition = new Rectangle(texPosX * 32, texPosY * 32, 32, 32);
            this.solid = solid;
            this.offset = offset;
        }

        public Tile(Vector2 position, Tile tile, bool collisionEnabled)
        {
            this.position = position;
            this.texturePosition = tile.texturePosition;

            if (collisionEnabled)
            {
                this.solid = tile.solid;
                this.offset = tile.offset;
                collision = offset;
                collision.X += (int)position.X;
                collision.Y += (int)position.Y;
            }
            else this.solid = false;

        }

        public Rectangle GetBounds()
        {
            return collision;
        }

    }
}
