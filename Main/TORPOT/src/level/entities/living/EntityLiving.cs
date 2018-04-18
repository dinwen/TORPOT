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

        public virtual void UpdateMovement()
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

        public virtual bool CheckCollision()
        {

            foreach (Tile t in level.tiles)
            {
                if (GetDistance(t.position) < 400)
                {
                    if (GetBoundsTop().Intersects(t.GetBounds()))
                    {
                        y = t.position.Y + t.collision.Height;
                        velY = 1;
                        
                    }
                    if (GetBoundsBottom().Intersects(t.GetBounds()))
                    {
                        if (velY > 0)
                        {
                            velY = 0;
                        }
                        y = t.position.Y - height + t.offset.Y;
                        
                    }
                    if (GetBoundsLeft().Intersects(t.GetBounds()))
                    {
                        if(this == level.GetPlayer())
                        {
                            if (GetBoundsWallslideLeft().Intersects(t.GetBounds()))
                            {
                                if (velY >= 0) velY = 0.2f;
                                level.GetPlayer().wallsliding = true;
                            }
                        }
                        x = t.position.X + t.collision.Height;
                        velX = 0;
                    }
                    if (GetBoundsRight().Intersects(t.GetBounds()))
                    {
                        if (this == level.GetPlayer())
                        {
                            if (GetBoundsWallslideRight().Intersects(t.GetBounds()))
                            {
                                if (velY >= 0) velY = 0.2f;
                                level.GetPlayer().wallsliding = true;
                            }
                        }
                        x = t.position.X - width + t.offset.X;
                        velX = 0;

                    }
                }
            }
            return false;
        }

        public Rectangle GetBoundsInGround()
        {
            return new Rectangle(GetXi() + (int)movementSpeed, GetYi() + height, width - (int)movementSpeed * 2, (int)movementSpeed * 2);
        }

        public Rectangle GetBoundsW()
        {
            return new Rectangle(GetXi() + (int)movementSpeed, GetYi() + height, width - (int)movementSpeed * 2, (int)movementSpeed * 2);
        }

        public Rectangle GetBoundsBottom()
        {
            return new Rectangle(GetXi() + (int)movementSpeed, GetYi() + height - (int)movementSpeed, width - (int)movementSpeed * 2, (int)movementSpeed);
        }

        public Rectangle GetBoundsTop()
        {
            return new Rectangle(GetXi() + (int)movementSpeed, GetYi(), width - (int)movementSpeed * 2, (int)movementSpeed);
        }

        public Rectangle GetBoundsWallslideLeft()
        {
            return new Rectangle(GetXi(), GetYi() + (int)movementSpeed, (int)movementSpeed, height / 2 - 2 * (int)movementSpeed);
        }

        public Rectangle GetBoundsWallslideRight()
        {
            return new Rectangle(GetXi() + width - (int)movementSpeed, GetYi() + (int)movementSpeed, (int)movementSpeed, height / 2 - 2 * (int)movementSpeed);
        }

        public Rectangle GetBoundsRight()
        {
            return new Rectangle(GetXi() + width - (int)movementSpeed, GetYi() + (int)movementSpeed, (int)movementSpeed, height - 2 * (int)movementSpeed);
        }

        public Rectangle GetBoundsLeft()
        {
            return new Rectangle(GetXi(), GetYi() + (int)movementSpeed, (int)movementSpeed, height - 2 * (int)movementSpeed);
        }

        public Rectangle GetBoundsFull()
        {
            return new Rectangle(GetXi(), GetYi(), width, height);
        }

    }
}
