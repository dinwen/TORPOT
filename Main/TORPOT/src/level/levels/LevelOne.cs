using Svennebanan;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TORPOT.src.level.entities.living;

namespace TORPOT.level.Levels
{
    public class LevelOne : Level
    {

        public LevelOne(ResourceManager resources) : base(resources)
        {
            LoadLevel("Content/levels/test.txt");

            AddEntity(new EntityPlayer(400, 0));
        }

    }
}
