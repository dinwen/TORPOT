using Svennebanan;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TORPOT.level;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using TORPOT.src.level.entities.living;
using TORPOT.src.level.entities;

namespace TORPOT.src.level.Levels
{
    class LevelCloud : Level
    {

        public LevelCloud(ResourceManager resources) : base(resources)
        {
            LoadLevel("Content/levels/cloud map._interaktiv.txt", "Content/levels/cloud map._overlay.txt");
            AddEntity(new EntityPlayer(0, 0));
            AddEntity(new EntityEnemy01(400, 150));

            AddEntity(new Cloud(32, 8 * 32));
            AddEntity(new Cloud(25 * 32, 7 * 32));
            AddEntity(new Cloud(37* 32, 2 * 32));
            AddEntity(new Cloud(42 * 32, 4 * 32));
            AddEntity(new Cloud(50 * 32, 8 * 32));
            AddEntity(new Cloud(63 * 32, 6 * 32));
            AddEntity(new Cloud(77 * 32, 8 * 32));
            AddEntity(new Cloud(84 * 32, 4 * 32));
            AddEntity(new Cloud(106 * 32, 2 * 32));
            AddEntity(new Cloud(130 * 32, 2 * 32));
            AddEntity(new Cloud(139 * 32, 7 * 32));

            AddEntity(new EntityItem(149 * 32, 4 * 32, "mirror"));
        }

        public override void Reset()
        {
            base.Reset();
            LoadLevel("Content/levels/cloud map._interaktiv.txt", "Content/levels/cloud map._overlay.txt");
            AddEntity(new EntityPlayer(0, 0));
            AddEntity(new EntityEnemy01(400, 150));

            AddEntity(new Cloud(32, 8 * 32));
            AddEntity(new Cloud(25 * 32, 7 * 32));
            AddEntity(new Cloud(37 * 32, 2 * 32));
            AddEntity(new Cloud(42 * 32, 4 * 32));
            AddEntity(new Cloud(50 * 32, 8 * 32));
            AddEntity(new Cloud(63 * 32, 6 * 32));
            AddEntity(new Cloud(77 * 32, 8 * 32));
            AddEntity(new Cloud(84 * 32, 4 * 32));
            AddEntity(new Cloud(106 * 32, 2 * 32));
            AddEntity(new Cloud(130 * 32, 2 * 32));
            AddEntity(new Cloud(139 * 32, 7 * 32));

            AddEntity(new EntityItem(149 * 32, 4 * 32, "mirror"));
        }

        public override void Draw(SpriteBatch batch, SpriteBatch hudBatch)
        {
            batch.Draw(resourceManager.images.GetImage("background_cloud"), new Vector2((int)(GetPlayer().GetX() / 480f) * 480, 0), null, Color.White, 0f, new Vector2(0, 0), 1, SpriteEffects.None, 0f);
            batch.Draw(resourceManager.images.GetImage("background_cloud"), new Vector2((int)((GetPlayer().GetX() / 480f) - 1) * 480, 0), null, Color.White, 0f, new Vector2(0, 0), 1, SpriteEffects.None, 0f);
            batch.Draw(resourceManager.images.GetImage("background_cloud"), new Vector2((int)((GetPlayer().GetX() / 480f) + 1) * 480, 0), null, Color.White, 0f, new Vector2(0, 0), 1, SpriteEffects.None, 0f);

            base.Draw(batch, hudBatch);
        }

    }
}
