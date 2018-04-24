using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using TORPOT.src.level.entities.living;

namespace TORPOT.src.level.entities
{
    class Spikes : EntityEnemy
    {
        public Spikes(float x, float y) : base(x, y)
        {
            this.attackDamage = 50;
            this.health = int.MaxValue;
        }

        public override void Update()
        {

        }

        public override void Draw(SpriteBatch batch)
        {
            base.Draw(batch);

            batch.Draw(resources.images.GetImage("Spikes"), new Vector2(x, y), null, Color.White, 0f, new Vector2(0, 0), 1, SpriteEffects.None, 0.6f);

        }

    }
}
