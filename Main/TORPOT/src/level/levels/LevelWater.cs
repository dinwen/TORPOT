using Svennebanan;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TORPOT.level;
using TORPOT.src.level.entities;
using TORPOT.src.level.entities.living;

namespace TORPOT.src.level.Levels
{
    class LevelWater : Level
    {
        public LevelWater(ResourceManager resources) : base(resources)
        {

            LoadLevel("Content/levels/water map v2._interaktiv.txt", "Content/levels/water map v2._overlay.txt");
            AddEntity(new EntityPlayer(400, 150));
            AddEntity(new EntityEnemy01(400, 150));

            AddEntity(new EntityItem(400, 24 * 32 - 8, "shell"));
        }

        public override void Reset()
        {
            base.Reset();
            LoadLevel("Content/levels/water map v2._interaktiv.txt", "Content/levels/water map v2._overlay.txt");
            AddEntity(new EntityPlayer(400, 150));
            AddEntity(new EntityEnemy01(400, 150));
        }
    }
}
