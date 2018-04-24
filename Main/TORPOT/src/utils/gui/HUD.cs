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

        public bool itemOne, itemTwo, itemThree, itemFour;

        public HUD(Level level)
        {
            this.level = level;
        }

        public void Update()
        {
            this.health = level.GetPlayer().health;
            
        }

        public void Draw(SpriteBatch batch)
        {
            batch.Draw(level.resourceManager.images.GetImage("HealthbarFrame"), new Rectangle(0, 0, 178, 30), null, Color.White, 0, Vector2.Zero, SpriteEffects.None, 0.2f);
            batch.Draw(level.resourceManager.images.GetImage("HealthbarHealth"), new Rectangle(0, 0, (int)health, 30), null, Color.White, 0, Vector2.Zero, SpriteEffects.None, 0.1f);
            batch.Draw(level.resourceManager.images.GetImage("HealthbarBackground"), new Rectangle(0, 0, 178, 30), null, Color.White, 0, Vector2.Zero, SpriteEffects.None, 0.3f);

#pragma warning disable CS0618 // Type or member is obsolete

            batch.Draw(level.resourceManager.images.GetImage("ItemHUD"), new Vector2(Game.WIDTH - 150, 15), null, null, new Vector2(0, 0), 0, new Vector2(1, 1), Color.White, SpriteEffects.None, 0.5f);

            if (itemOne) batch.Draw(level.resourceManager.images.GetImage("shell"), new Vector2(Game.WIDTH - 102, 37), null, null, new Vector2(0, 0), 0, new Vector2(1, 1), Color.White, SpriteEffects.None, 0.5f);
            if(itemTwo) batch.Draw(level.resourceManager.images.GetImage("medaljong"), new Vector2(Game.WIDTH - 102, 37 + 32), null, null, new Vector2(0, 0), 0, new Vector2(1, 1), Color.White, SpriteEffects.None, 0.5f);
            if (itemThree) batch.Draw(level.resourceManager.images.GetImage("book"), new Vector2(Game.WIDTH - 102, 37 + 116), null, null, new Vector2(0, 0), 0, new Vector2(1, 1), Color.White, SpriteEffects.None, 0.5f);
            if (itemFour) batch.Draw(level.resourceManager.images.GetImage("mirror"), new Vector2(Game.WIDTH - 102, 37 + 150), null, null, new Vector2(0, 0), 0, new Vector2(1, 1), Color.White, SpriteEffects.None, 0.5f);

#pragma warning restore CS0618 // Type or member is obsolete





        }





    }
}
