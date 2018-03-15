using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace TORPOT.src.level.entities.particles
{
    class ParticleTest : EntityParticle
    {
        Random rdn = new Random();
        public ParticleTest(float X, float Y) : base(X, Y)
        {
            x = X;
            y = Y;

            duration = rdn.Next(60, 80);
        }

        public override void Update()
        {
            if(--duration <= 0)
            {
                Remove();
            }
            x++;
        }

        public override void Draw(SpriteBatch batch)
        {
            batch.Draw(resources.images.GetImage("testParticle"), new Vector2(x, y), Color.White);
        }
    }
}
