using Microsoft.Xna.Framework.Graphics;
using Svennebanan;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TORPOT.src.level.entities
{
    public class Entity
    {

        protected float x, y;
        private bool removed;

        protected ResourceManager resources;

        public Entity(float x, float y)
        {
            this.x = x;
            this.y = y;
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

        public virtual void Update()
        {

        }

        public virtual void Draw(SpriteBatch batch)
        {

        }

    }
}
