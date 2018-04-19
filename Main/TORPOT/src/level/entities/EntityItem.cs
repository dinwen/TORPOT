using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TORPOT.src.level.entities
{
    class EntityItem : Entity
    {

        private float yAdd, sineCount, sineMax, sineAmount;
        public string sprite;

        public EntityItem(float x, float y, string sprite) : base(x, y)
        {
            sineMax = 120;
            sineCount = 0;
            sineAmount = 6;
            this.sprite = sprite;
        }

        public override void Update()
        {
            yAdd = (float)(Math.Sin((++sineCount / sineMax) * Math.PI * 2) * sineAmount);
        }

        public override void Draw(SpriteBatch batch)
        {
            batch.Draw(resources.images.GetImage(sprite), new Vector2(x, y + yAdd), Color.White);
        }

        public Rectangle GetBounds()
        {
            return new Rectangle((int)x, (int)y, 32, 32);
        }
    }
}
