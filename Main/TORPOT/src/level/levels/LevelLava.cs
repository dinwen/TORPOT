using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Svennebanan;
using TORPOT.level;
using TORPOT.src.level.entities.living;
using TORPOT.src.level.entities;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace TORPOT.src.level.Levels
{
    class LevelLava : Level
    {
        public LevelLava(ResourceManager resources) : base(resources)
        {

            LoadLevel("Content/levels/lava map v2._interaktiv.txt", "Content/levels/lava map v2._overlay.txt");
            AddEntity(new EntityPlayer(400, 150));
            AddEntity(new EntityEnemy01(400, 150));

            AddEntity(new LavaOverlay(5 * 32, 0));
            AddEntity(new LavaOverlay(20 * 32, 0));
            AddEntity(new LavaOverlay(37 * 32, 0));
            AddEntity(new LavaOverlay(55 * 32, 0));
            AddEntity(new LavaOverlay(69 * 32, 0));
            AddEntity(new LavaOverlay(101 * 32, 0));
            AddEntity(new LavaOverlay(120 * 32, 0));
            AddEntity(new LavaOverlay(139 * 32, 0));

            AddEntity(new LavaWave(-400, 8 * 32 - 255));

            AddEntity(new EntityItem(149 * 32, 4 * 32, "medaljong"));
        }

        public override void Reset()
        {
            base.Reset();
            LoadLevel("Content/levels/lava map v2._interaktiv.txt", "Content/levels/lava map v2._overlay.txt");
            AddEntity(new EntityPlayer(400, 150));
            AddEntity(new EntityEnemy01(400, 150));

            AddEntity(new LavaOverlay(5 * 32, 0));
            AddEntity(new LavaOverlay(20 * 32, 0));
            AddEntity(new LavaOverlay(37 * 32, 0));
            AddEntity(new LavaOverlay(55 * 32, 0));
            AddEntity(new LavaOverlay(69 * 32, 0));
            AddEntity(new LavaOverlay(101 * 32, 0));
            AddEntity(new LavaOverlay(120 * 32, 0));
            AddEntity(new LavaOverlay(139 * 32, 0));

            AddEntity(new LavaWave(-400, 8 * 32 - 255));

            AddEntity(new EntityItem(149 * 32, 4 * 32, "medaljong"));
        }

        public override void Draw(SpriteBatch batch, SpriteBatch hudBatch)
        {
            batch.Draw(resourceManager.images.GetImage("background_lava"), new Vector2((int)(GetPlayer().GetX() / 480f) * 480, 0), null, Color.White, 0f, new Vector2(0, 0), 1, SpriteEffects.None, 0f);
            batch.Draw(resourceManager.images.GetImage("background_lava"), new Vector2((int)((GetPlayer().GetX() / 480f) - 1) * 480, 0), null, Color.White, 0f, new Vector2(0, 0), 1, SpriteEffects.None, 0f);
            batch.Draw(resourceManager.images.GetImage("background_lava"), new Vector2((int)((GetPlayer().GetX() / 480f) + 1) * 480, 0), null, Color.White, 0f, new Vector2(0, 0), 1, SpriteEffects.None, 0f);

            base.Draw(batch, hudBatch);
        }

    }
}
