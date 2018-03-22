using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Svennebanan;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TORPOT.level;

namespace TORPOT.src.level.entities
{
    public class Entity
    {

        protected float x, y;
        private bool removed;

        protected ResourceManager resources;
        protected Level level;

        public Entity(float x, float y)
        {
            this.x = x;
            this.y = y;
        }

        public void Init(Level level, ResourceManager resources)
        {
            this.level = level;
            this.resources = resources;
        }

        public void Remove()
        {
            removed = true;
        }

        public bool isRemoved()
        {
            return removed;
        }

        public int GetXi()
        {
            return (int)x;
        }

        public int GetYi()
        {
            return (int)y;
        }
        
        public float GetX()
        {
            return x;
        }

        public float GetY()
        {
            return y;
        }

        public float GetDistance(Vector2 secondPosition)
        {
            float distance = Vector2.Distance(new Vector2(x, y), secondPosition);
            return distance;
        }

        public virtual void Update()
        {

        }

        public virtual void Draw(SpriteBatch batch)
        {

        }

    }
}
