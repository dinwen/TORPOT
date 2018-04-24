using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using SpelProjekt.src.utils;

namespace TORPOT.src.level.entities.projectile
{
    class ProjectileShell : EntityProjectile
    {

        private Animation anim;

        public ProjectileShell(float x, float y, int direction) : base(x, y, direction)
        {
            this.speed = 10;
            this.width = 32;
            this.height = 32;

            int r = new Random().Next(0, 4);
            anim = new Animation(3, 0, 0, 18, 13, 90, 13, false);
            anim.setFrame(r);
        }

        public override void Draw(SpriteBatch batch)
        {

            batch.Draw(resources.images.GetImage("projectile"), new Vector2(x, y), anim.GetRectangle(), Color.White, 0f, new Vector2(0, 0), 1, SpriteEffects.None, 0.1f);

        }
    }
}
