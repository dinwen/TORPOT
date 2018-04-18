using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;

namespace TORPOT.src.level.entities.living
{
    class EntityEnemy : EntityLiving
    {

        public float attackDamage;

        public EntityEnemy(float x, float y) : base(x, y)
        {

        }

        public override void Update()
        {
            base.Update();
        }

        public override void Draw(SpriteBatch batch)
        {
            base.Draw(batch);
        }
    }
}
