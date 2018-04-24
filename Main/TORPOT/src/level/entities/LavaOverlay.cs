using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace TORPOT.src.level.entities
{
    class LavaOverlay : Entity
    {

        private string sprite;

        public LavaOverlay(float x, float y) : base(x, y)
        {
            sprite = new Random().Next(0, 1) == 0 ? "Lava_overlay_1" : "Lava_overlay_2";
        }

        public override void Draw(SpriteBatch batch)
        {
            base.Draw(batch);
            batch.Draw(resources.images.GetImage(sprite), new Vector2(x, y), null, Color.White, 0f, new Vector2(0, 0), 1, SpriteEffects.None, 0.9f);

        }

    }
}
