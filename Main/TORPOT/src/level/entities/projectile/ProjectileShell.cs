using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace TORPOT.src.level.entities.projectile
{
    class ProjectileShell : EntityProjectile
    {
        public ProjectileShell(float x, float y, int direction) : base(x, y, direction)
        {
            this.speed = 10;
        }

        public override void Draw(SpriteBatch batch)
        {
            batch.Draw(resources.images.GetImage("projectile"), new Vector2(x, y), Color.White);
        }
    }
}
