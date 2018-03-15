using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TORPOT.src.level.entities.living
{
    public class EntityLiving : Entity
    {

        protected float health;
        protected float movementSpeed;

        protected Texture2D sprite;

        public EntityLiving(float x, float y) : base(x, y)
        {
            
        }

        public override void Update()
        {

        }

        public override void Draw(SpriteBatch batch)
        {
            batch.Draw(sprite, new Vector2(GetXi(), GetYi()), Color.White);
        } 

    }
}
