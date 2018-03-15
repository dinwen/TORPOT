using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TORPOT.src.level.entities.living
{
    public class EntityPlayer : EntityLiving
    {

        public EntityPlayer(float x, float y) : base(x, y)
        {
            this.sprite = resources.images.GetImage("player");
        }

    }
}
