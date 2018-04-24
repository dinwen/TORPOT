using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Svennebanan;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TORPOT.level;
using TORPOT.src.level.entities;
using TORPOT.src.level.entities.living;

namespace TORPOT.src.level.Levels
{
    class LevelForest : Level
    {

        public LevelForest(ResourceManager resources) : base(resources)
        {

            LoadLevel("Content/levels/forest map v2._interaktiv.txt", "Content/levels/forest map v2._overlay.txt");
            AddEntity(new EntityPlayer(400, 150));
            AddEntity(new EntityEnemy01(400, 150));

            AddEntity(new Spikes(46 * 32, 8 * 32));
            AddEntity(new Spikes(48 * 32, 8 * 32));
            AddEntity(new Spikes(50 * 32, 8 * 32));
            AddEntity(new Spikes(52 * 32, 8 * 32));

            AddEntity(new Spikes(76 * 32, 8 * 32));
            AddEntity(new Spikes(100 * 32, 8 * 32));
            AddEntity(new Spikes(102 * 32, 8 * 32));
            AddEntity(new Spikes(109 * 32, 8 * 32));
            AddEntity(new Spikes(111 * 32, 8 * 32));

            AddEntity(new EntityItem(149*32, 4 * 32, "book"));
        }

        public override void Reset()
        {
            base.Reset();
            LoadLevel("Content/levels/forest map v2._interaktiv.txt", "Content/levels/forest map v2._overlay.txt");
            AddEntity(new EntityPlayer(400, 150));
            AddEntity(new EntityEnemy01(400, 150));

            AddEntity(new Spikes(46 * 32, 8 * 32));
            AddEntity(new Spikes(48 * 32, 8 * 32));
            AddEntity(new Spikes(50 * 32, 8 * 32));
            AddEntity(new Spikes(52 * 32, 8 * 32));

            AddEntity(new Spikes(76 * 32, 8 * 32));
            AddEntity(new Spikes(100 * 32, 8 * 32));
            AddEntity(new Spikes(102 * 32, 8 * 32));
            AddEntity(new Spikes(109 * 32, 8 * 32));
            AddEntity(new Spikes(111 * 32, 8 * 32));

            AddEntity(new EntityItem(149 * 32, 4 * 32, "book"));
        }

        public override void Draw(SpriteBatch batch, SpriteBatch hudBatch)
        {
            batch.Draw(resourceManager.images.GetImage("background_forest"), new Vector2((int)(GetPlayer().GetX() / 480f) * 480, 0), null, Color.White, 0f, new Vector2(0, 0), 1, SpriteEffects.None, 0f);
            batch.Draw(resourceManager.images.GetImage("background_forest"), new Vector2((int)((GetPlayer().GetX() / 480f) - 1) * 480, 0), null, Color.White, 0f, new Vector2(0, 0), 1, SpriteEffects.None, 0f);
            batch.Draw(resourceManager.images.GetImage("background_forest"), new Vector2((int)((GetPlayer().GetX() / 480f) + 1) * 480, 0), null, Color.White, 0f, new Vector2(0, 0), 1, SpriteEffects.None, 0f);

            base.Draw(batch, hudBatch);
        }

    }
}
