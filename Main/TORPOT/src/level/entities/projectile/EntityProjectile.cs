using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Svennebanan;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TORPOT.src.level.entities.living;

namespace TORPOT.src.level.entities.projectile
{
    class EntityProjectile : Entity
    {

        protected int direction;
        protected float speed;
        protected int width, height;

        public EntityProjectile(float x, float y, int direction) : base(x, y)
        {
            this.direction = direction;
        }

        public override void Update()
        {
            x += speed * direction;

            foreach (Entity e in level.entities)
            {
                if (!(e is EntityProjectile) && e is EntityEnemy)
                {
                    if (((EntityEnemy)e).GetBoundsFull().Intersects(GetBounds()))
                    {
                        e.Remove();
                        Remove();
                    }
                }
            }

            CheckCollision();
        }

        public bool CheckCollision()
        {
            foreach (Tile t in level.tiles)
            {
                if(t.GetBounds().Intersects(GetBounds()))
                {
                    Remove();
                }
            }
            return false;
        }

        public override void Draw(SpriteBatch batch)
        {

        }

        public Rectangle GetBounds()
        {
            return new Rectangle((int)x, (int)y, width, height);
        }

    }
}
