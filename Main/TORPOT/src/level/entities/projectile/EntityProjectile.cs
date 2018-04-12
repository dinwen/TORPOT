using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
