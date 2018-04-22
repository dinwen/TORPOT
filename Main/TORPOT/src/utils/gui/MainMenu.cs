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

        private Level level;




        public MainMenu(ResourceManager res, Vector2 position, Level level)
        {
            this.res = res;
            this.level = level;

            start = new Button(new Vector2(1920 / 2 - 255 / 2, 1080 / (float)3.5 - 31 / (float)3.5), 255 * 2, 31 * 2, "Play", level);

            quit = new Button(new Vector2(1920 / 2 - 255 / 2, 1080 / (float)1.25 - 31 / (float)1.25), 255 * 2, 31 * 2, "Quit", level);

        }


        public void Update()
        {
            start.Update();

            quit.Update();


            if (start.trigger)
            {
                
                Game.state = Game.STATE.Levellava;
                start.trigger = false;
            }



            if (quit.trigger)
            {
                Game.state = Game.STATE.Quit;
            }


        }

        public void Draw(SpriteBatch batch)
        {
            batch.Draw(level.resourceManager.images.GetImage("mainMenu"), new Vector2(0, 0), Color.White);


            start.Draw(batch);

            quit.Draw(batch);

        }

    }
}