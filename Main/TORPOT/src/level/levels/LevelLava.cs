using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Svennebanan;
using TORPOT.level;
using TORPOT.src.level.entities.living;
using TORPOT.src.level.entities;

namespace TORPOT.src.level.Levels
{
    class LevelLava : Level
    {
        public LevelLava(ResourceManager resources) : base(resources)
        {

            LoadLevel("Content/levels/lava map v2._interaktiv.txt", "Content/levels/lava map v2._overlay.txt");
            AddEntity(new EntityPlayer(400, 150));
            AddEntity(new EntityEnemy01(400, 150));

            AddEntity(new EntityItem(400, 24 * 32 - 8, "shell"));
        }

        public override void Reset()
        {
            base.Reset();
            LoadLevel("Content/levels/lava map v2._interaktiv.txt", "Content/levels/lava map v2._overlay.txt");
            AddEntity(new EntityPlayer(400, 150));
            AddEntity(new EntityEnemy01(400, 150));
        }

    }
}
