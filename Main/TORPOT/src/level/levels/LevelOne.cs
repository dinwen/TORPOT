using Svennebanan;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TORPOT.src.level.entities.living;
using TORPOT.src.level.entities.particles;

namespace TORPOT.level.Levels
{
    public class LevelOne : Level
    {

        Random rdn = new Random();
        public LevelOne(ResourceManager resources) : base(resources)
        {

            LoadLevel("Content/levels/test.txt");

            AddEntity(new EntityPlayer(400, 0));
            AddEntity(new ParticleTest(400, rdn.Next(100, 300)));
        }

    }
}
