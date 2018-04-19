﻿using Microsoft.Xna.Framework;
using Svennebanan;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

            LoadLevel("Content/levels/TestLevel.txt");

            AddEntity(new EntityPlayer(300, 150));
        }

        public override void Update(GameTime gameTime)
        {
            if (InputHandler.interactDoor)
            {
                Game.state = Game.STATE.Levelhub;
                //Game.SwitchLevel(new LevelHub(resourceManager));
            }
            base.Update(gameTime);
            //AddEntity(new ParticleTest(100, rdn.Next(100, 200)));
            AddEntity(new ParticleTest(GetPlayer().GetX(), GetPlayer().GetY()));
        }
    }
}
