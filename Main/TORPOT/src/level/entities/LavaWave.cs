using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using TORPOT.src.level.entities.living;
using SpelProjekt.src.utils;
using Microsoft.Xna.Framework;

namespace TORPOT.src.level.entities
{
    class LavaWave : EntityEnemy
    {

        private Animation anim;

        public LavaWave(float x, float y) : base(x, y)
        {
            this.attackDamage = 100;
            this.movementSpeed = 3.5f;

            this.width = 310;
            this.height = 255;

            anim = new Animation(5, 0, 0, 310, 255, 1240, 255, true);
        }

        public override void Update()
        {
            //base.Update();
            anim.Update();
            this.x += movementSpeed;
        }

        public override void Draw(SpriteBatch batch)
        {
            base.Draw(batch);
            batch.Draw(resources.images.GetImage("LavaWave"), new Vector2(x, y), anim.GetRectangle(), Color.White, 0f, new Vector2(0, 0), 1, SpriteEffects.None, 0.6f);

        }
    }
}
