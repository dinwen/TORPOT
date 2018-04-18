using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TORPOT.level;

namespace TORPOT.src.utils.gui
{
    public class HUD
    {
        private Level level;
        private int x, y;

        public float health = 178;

        Vector2 position = new Vector2();
      

        public HUD(Level level)
        {
            this.level = level;
        }

        public void Update()
        {

            
        }

        public void Draw(SpriteBatch batch)
        {
            batch.Draw(level.resourceManager.images.GetImage("HealthbarFrame"), new Rectangle(0, 0, 178, 30), null, Color.White, 0, Vector2.Zero, SpriteEffects.None, 0.2f);
            batch.Draw(level.resourceManager.images.GetImage("HealthbarHealth"), new Rectangle(0, 0, (int)health, 30), null, Color.White, 0, Vector2.Zero, SpriteEffects.None, 0.1f);
            batch.Draw(level.resourceManager.images.GetImage("HealthbarBackground"), new Rectangle(0, 0, 178, 30), null, Color.White, 0, Vector2.Zero, SpriteEffects.None, 0.3f);
            batch.Draw(level.resourceManager.images.GetImage("ItemHUD"), new Rectangle(850, 0, 64, 116), null, Color.White, 0, Vector2.Zero, SpriteEffects.None, 1f);
            
            


        }





    }
}
