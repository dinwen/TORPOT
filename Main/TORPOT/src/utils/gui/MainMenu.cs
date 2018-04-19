using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Svennebanan;
using Svennebanan.gui;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TORPOT.level;

namespace TORPOT.src.gui
{
    public class MainMenu
    {

        private ResourceManager res;
        private Button start;
        private Button options;
        private Button quit;
        private Game game;




        public MainMenu(ResourceManager res, Vector2 position, Level level)
        {
            this.res = res;
           

            start = new Button(new Vector2(1920 / 2 - 64 / 2, 1080 / (float)3.5 - 116 / (float)3.5), 64*2, 116*2, "Play", level);

            quit = new Button(new Vector2(1920 / 2 - 64 / 2, 1080 / (float)1.25 - 116 / (float)1.25), 64*2, 116*2, "Quit", level);

        }


        public void Update()
        {
            start.Update();

            quit.Update();


            if (start.trigger)
            {
                Game.state = Game.STATE.Levelhub;
                start.trigger = false;
            }



            if (quit.trigger)
            {
                Game.state = Game.STATE.Quit;
            }


        }

        public void Draw(SpriteBatch batch)
        {
            
            start.Draw(batch);

            quit.Draw(batch);

        }

    }
}