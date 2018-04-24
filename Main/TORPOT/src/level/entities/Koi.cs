using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using SpelProjekt.src.utils;
using Microsoft.Xna.Framework;

namespace TORPOT.src.level.entities
{
    class Koi : Entity
    {

        private Animation anim;

        public Koi(float x, float y) : base(x, y)
        {
            anim = new Animation(5, 0, 0, 112, 288, 336, 288, true);
            this.y -= 16;
        }

        public override void Update()
        {
            base.Update();
            //anim.Update();
        }

        public override void Draw(SpriteBatch batch)
        {
            base.Draw(batch);
            batch.Draw(resources.images.GetImage("Koi_head"), new Vector2(x, y), null, Color.White, 0f, new Vector2(0, 0), 1, SpriteEffects.None, 0.9f);

        }
    }
}
