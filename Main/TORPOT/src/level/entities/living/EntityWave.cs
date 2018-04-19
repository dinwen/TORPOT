using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TORPOT.src.level.entities.living
{
    class EntityWave : EntityEnemy
    {

        EntityPlayer player;


        public EntityWave(float x, float y) : base(x, y)
        {

        }

        public override void Update()
        {
            x++;

            if(level.GetPlayer().GetBoundsFull().Intersects(this.GetBoundsFull()))
            {
                level.GetPlayer().health = 0;
            }
           
        }

        public override void Draw(SpriteBatch batch)
        {
            batch.Draw(resources.images.GetImage("LavaWave"), new Vector2(x, y), Color.White);
        }
    }
}
