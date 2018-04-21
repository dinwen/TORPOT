using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Media;
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
    public class LevelHub : Level
    {
        Random rdn = new Random();
        public LevelHub(ResourceManager resources) : base(resources)
        {

            LoadLevel("Content/levels/LevelHub.txt", "Content/levels/LevelHub2.txt");
            resourceManager.audio.GetSound(0).Play();
            MediaPlayer.IsRepeating = true;
            AddEntity(new EntityPlayer(0, 0));
        }

        public override void Update(GameTime gameTime)
        {
            //if(GetPlayer().GetX() == )
            //{
            //    if (InputHandler.interactDoor)
            //    {
            //        Game.state = Game.STATE.Levelhub;
            //        //Game.SwitchLevel(new LevelHub(resourceManager));
            //    }
            //}

            base.Update(gameTime);
            //AddEntity(new ParticleTest(100, rdn.Next(100, 200)));
            AddEntity(new ParticleTest(GetPlayer().GetX(), GetPlayer().GetY()));
        }
    }
}
