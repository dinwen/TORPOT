using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TORPOT.level;

namespace Svennebanan.gui
{
    public class Button
    {
        public bool trigger;
        private Vector2 position;
        private int width, height;
        private string textureID;
        private Game game;
        
        private Level level;




        public Button(Vector2 position, int width, int height, string textureID, Level level)
        {
            this.level = level;
            this.position = position;
            this.width = width;
            this.height = height;

            this.textureID = textureID;
        }

        public void Update()
        {

            if ((Mouse.GetState().X >= position.X && Mouse.GetState().X <= position.X + width) && (Mouse.GetState().Y >= position.Y && Mouse.GetState().Y <= position.Y + height))
            {


                if (Mouse.GetState().LeftButton == ButtonState.Pressed)
                {
                    trigger = true;
                }
                else
                {
                    trigger = false;
                }
            }
            else
            {
                trigger = false;
            }

        }

        public void Draw(SpriteBatch batch)
        {
            batch.Draw(level.resourceManager.images.GetImage(textureID), position, Color.White);
        }
    }
}