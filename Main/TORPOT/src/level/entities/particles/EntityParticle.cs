using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TORPOT.src.level.entities.particles
{
    public class EntityParticle : Entity
    {
        protected Vector2 velocity;
        protected float angle;
        protected Color color;
        protected float size;
        protected int duration;


        public EntityParticle(float x, float y) : base(x, y)
        {

        }
        public override void Update()
        {
        }
        public override void Draw(SpriteBatch batch)
        {

        }
    }
}
