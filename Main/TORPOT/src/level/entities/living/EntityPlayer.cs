using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Svennebanan;

namespace TORPOT.src.level.entities.living
{
    public class EntityPlayer : EntityLiving
    {

        public EntityPlayer(float x, float y) : base(x, y)
        {
            this.width = 64;
            this.height = 64;
        }

        public override void Update()
        {
            base.Update();
            if (InputHandler.right) x++;
            if (InputHandler.left) x--;

        }

        public override void Draw(SpriteBatch batch)
        {
            batch.Draw(resources.images.GetImage("player"), new Vector2(GetXi(), GetYi()), Color.White);
        }


    }
}
