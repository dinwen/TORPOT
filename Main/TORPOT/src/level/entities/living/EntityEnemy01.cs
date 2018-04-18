using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SpelProjekt.src.utils;
using Svennebanan;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TORPOT.src.level.entities.living
{
    class EntityEnemy01 : EntityEnemy
    {

        private int direction;
        private Animation walking;

        public EntityEnemy01(float x, float y) : base(x, y)
        {
            this.attackDamage = 5;
            this.movementSpeed = 2f;
            this.direction = new Random().Next(0, 1);

            walking = new Animation(5, 0, 0, 32, 32, 48, 32, true);
            this.width = 32;
            this.height = 32;
        }

        public override void UpdateMovement()
        {
            base.UpdateMovement();
            if (direction == 1) this.x += movementSpeed;
            else if (direction == 0) this.x -= movementSpeed;
            
            walking.Update();
        }

        public override bool CheckCollision()
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
                        direction = 1;
                        x = t.position.X + t.collision.Height;
                        velX = 0;
                    }
                    if (GetBoundsRight().Intersects(t.GetBounds()))
                    {
                        direction = 0;
                        x = t.position.X - width + t.offset.X;
                        velX = 0;
                    }
                }
            }
            return false;
        }

        public override void Draw(SpriteBatch batch)
        {
            bool flip = direction == 1 ? false : true;

#pragma warning disable CS0618 // Type or member is obsolete
            batch.Draw(resources.images.GetImage("walker"), new Vector2(GetXi(), GetYi()), null, walking.GetRectangle(), new Vector2(0, 0), 0, new Vector2(1, 1), Color.White, direction == 0 ? SpriteEffects.None : SpriteEffects.FlipHorizontally, 0.5f);
#pragma warning restore CS0618 // Type or member is obsolete
        }

    }
}
