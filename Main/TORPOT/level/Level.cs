using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Svennebanan;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TORPOT.level
{
    public class Level
    {

        public ResourceManager resourceManager;
        public InputHandler inputHandler;

        public Level(ResourceManager resources)
        {
            this.resourceManager = resources;
        }

        public void Update(GameTime gameTime)
        {

        }
        
        public void Draw(SpriteBatch batch)
        {

        }

    }
}
