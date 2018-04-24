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
using Microsoft.Xna.Framework.Graphics;
using System.Diagnostics;

namespace TORPOT.level.Levels
{
    public class LevelHub : Level
    {
        Random rdn = new Random();
        public LevelHub(ResourceManager resources) : base(resources)
        {

            LoadLevel("Content/levels/world map v2._interaktiv.txt", "Content/levels/world map v2._overlay.txt");

            AddEntity(new EntityPlayer(1250, 1200));
        }

        public override void Reset()
        {
            base.Reset();
            LoadLevel("Content/levels/world map v2._interaktiv.txt", "Content/levels/world map v2._overlay.txt");
            AddEntity(new EntityPlayer(1250, 1200));
        }

        public override void Update(GameTime gameTime)
        {
            if (GetPlayer().GetX() > 34 && GetPlayer().GetX() < 74 && GetPlayer().GetY() >= 1200)
            {
                if (InputHandler.interactDoor)
                {
                    Game.state = Game.STATE.Levellava;
                }
            }
            else if (GetPlayer().GetX() > 112 && GetPlayer().GetX() < 142 && GetPlayer().GetY() > 800 && GetPlayer().GetY() < 1000)
            {
                if (InputHandler.interactDoor)
                {
                    Game.state = Game.STATE.Levelforest;
                }
            }
            else if (GetPlayer().GetX() > 1570 && GetPlayer().GetX() < 1615 && GetPlayer().GetY() > 600 && GetPlayer().GetY() < 800)
            {
                if (InputHandler.interactDoor)
                {
                    Game.state = Game.STATE.Levelcloud;
                }
            }
            else if (GetPlayer().GetX() > 1765 && GetPlayer().GetX() < 1810 && GetPlayer().GetY() >= 1200)
            {
                if (InputHandler.interactDoor)
                {
                    Game.state = Game.STATE.Levelwater;
                }
            }

            //Debug.Write("x=");
            //Debug.WriteLine(GetPlayer().GetX());
            //Debug.Write("y=");
            //Debug.WriteLine(GetPlayer().GetY());

            base.Update(gameTime);
            //AddEntity(new ParticleTest(100, rdn.Next(100, 200)));
            //AddEntity(new ParticleTest(GetPlayer().GetX(), GetPlayer().GetY()));
        }

        public override void Draw(SpriteBatch batch, SpriteBatch hudBatch)
        {
            base.Draw(batch, hudBatch);
            batch.Draw(resourceManager.images.GetImage("control"), new Vector2(1300, 1320), Color.White);
            batch.Draw(resourceManager.images.GetImage("worldmap"), new Vector2(0, 0), Color.White);
            
        }
    }
}
