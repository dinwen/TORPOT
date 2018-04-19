using Microsoft.Xna.Framework;
using Svennebanan;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TORPOT.src.level.entities;
using TORPOT.src.level.entities.living;
using TORPOT.src.level.entities.particles;
using TORPOT.src.utils.gui;

namespace TORPOT.level.Levels
{
    public class LevelOne : Level
    {

        Random rdn = new Random();
        public LevelOne(ResourceManager resources) : base(resources)
        {

            LoadLevel("Content/levels/NewTest.txt", "Content/levels/j.txt");

            AddEntity(new EntityPlayer(400, 150));
            AddEntity(new EntityEnemy01(400, 150));

            AddEntity(new EntityItem(400, 24*32- 8, "shell"));
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            AddEntity(new ParticleTest(100, rdn.Next(100, 200)));
        }

    }
}
