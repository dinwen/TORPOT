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
    class LevelWater : Level
    {
        public LevelWater(ResourceManager resources) : base(resources)
        {

            LoadLevel("Content/levels/water map v2._interaktiv.txt", "Content/levels/water map v2._overlay.txt");
            AddEntity(new EntityPlayer(400, 150));
            AddEntity(new EntityEnemy01(400, 150));

            AddEntity(new Koi(18 * 32 - 6, 7*32));
            AddEntity(new Koi(54 * 32 - 6, 7*32));
            AddEntity(new Koi(73 * 32 - 6, 7*32));
            AddEntity(new Koi(105 * 32 - 6, 3*32));
            AddEntity(new Koi(140 * 32 - 6, 7*32));

            AddEntity(new EntityItem(149*32, 4 * 32, "shell"));
        }

        public override void Reset()
        {
            base.Reset();
            LoadLevel("Content/levels/water map v2._interaktiv.txt", "Content/levels/water map v2._overlay.txt");
            AddEntity(new EntityPlayer(400, 150));
            AddEntity(new EntityEnemy01(400, 150));

            AddEntity(new Koi(18 * 32 - 6, 7 * 32));
            AddEntity(new Koi(54 * 32 - 6, 7 * 32));
            AddEntity(new Koi(73 * 32 - 6, 7 * 32));
            AddEntity(new Koi(105 * 32 - 6, 3 * 32));
            AddEntity(new Koi(140 * 32 - 6, 7 * 32));

            AddEntity(new EntityItem(149 * 32, 4 * 32, "shell"));
        }

        public override void Draw(SpriteBatch batch, SpriteBatch hudBatch)
        {
            batch.Draw(resourceManager.images.GetImage("background_water"), new Vector2((int)(GetPlayer().GetX() / 480f) * 480, 0), null, Color.White, 0f, new Vector2(0, 0), 1, SpriteEffects.None, 0f);
            batch.Draw(resourceManager.images.GetImage("background_water"), new Vector2((int)((GetPlayer().GetX() / 480f) - 1) * 480, 0), null, Color.White, 0f, new Vector2(0, 0), 1, SpriteEffects.None, 0f);
            batch.Draw(resourceManager.images.GetImage("background_water"), new Vector2((int)((GetPlayer().GetX() / 480f) + 1) * 480, 0), null, Color.White, 0f, new Vector2(0, 0), 1, SpriteEffects.None, 0f);

            base.Draw(batch, hudBatch);
        }
    }
}
