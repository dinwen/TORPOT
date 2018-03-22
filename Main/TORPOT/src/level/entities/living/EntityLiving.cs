using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Svennebanan;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TORPOT.src.level.entities.living
{
    public class EntityLiving : Entity
    {

        protected float health;
        protected float movementSpeed;
        protected float jumpHeight;

        protected float velX, velY;

        protected int width, height;

        protected Texture2D sprite;

        public EntityLiving(float x, float y) : base(x, y)
        {
            
        }

        public override void Update()
        {
            OnGround();
            if (!OnGround()) velY += level.gravity;

            UpdateMovement();
            CheckCollision();
        }

        public void UpdateMovement()
        {
            x += velX;
            y += velY;
        }

        public override void Draw(SpriteBatch batch)
        {
            
        }

        public bool OnGround()
        {
            foreach (Tile t in level.tiles)
            {
                if (t.GetBounds().Intersects(GetBoundsInGround()))
                { 
                    return true;
                }
            }
            return false;
        }

        public bool CheckCollision()
        {
            foreach (Tile t in level.tiles)
            {
                if (GetDistance(t.position) < 400)
                {
                    if (GetBoundsTop().Intersects(t.GetBounds()))
                    {
                        y = t.position.Y + t.collision.Height;
                        velY = 1;
                        return true;
                    }
                    if (GetBoundsBottom().Intersects(t.GetBounds()))
                    {
                        if (velY > 0)
                        {
                            velY = 0;
                        }
                        y = t.position.Y - height + t.offset.Y;
                        return true;
                    }
                    if (GetBoundsLeft().Intersects(t.GetBounds()))
                    {
                        x = t.position.X + t.collision.Height;
                        return true;
                    }
                    if (GetBoundsRight().Intersects(t.GetBounds()))
                    {
                        x = t.position.X - width + t.offset.X;
                        return true;
                    }
                }
            }
            return false;
        }

        public Rectangle GetBoundsInGround()
        {
            return new Rectangle(GetXi() + (int)movementSpeed, GetYi() + height, width - (int)movementSpeed * 3, (int)movementSpeed * 3);
        }

        public Rectangle GetBoundsW()
        {
            return new Rectangle(GetXi() + (int)movementSpeed, GetYi() + height, width - (int)movementSpeed * 3, (int)movementSpeed * 3);
        }

        public Rectangle GetBoundsBottom()
        {
            return new Rectangle(GetXi() + (int)movementSpeed, GetYi() + height - (int)movementSpeed, width - (int)movementSpeed * 3, (int)movementSpeed);
        }

        public Rectangle GetBoundsTop()
        {
            return new Rectangle(GetXi() + (int)movementSpeed, GetYi(), width - (int)movementSpeed * 3, (int)movementSpeed);
        }

        public Rectangle GetBoundsRight()
        {
            return new Rectangle(GetXi() + width - (int)movementSpeed, GetYi() + (int)movementSpeed, (int)movementSpeed, height - 3 * (int)movementSpeed);
        }

        public Rectangle GetBoundsLeft()
        {
            return new Rectangle(GetXi(), GetYi() + (int)movementSpeed, (int)movementSpeed, height - 3 * (int)movementSpeed);
        }

        public Rectangle GetBoundsFull()
        {
            return new Rectangle(GetXi(), GetYi(), width, height);
        }

    }
}
