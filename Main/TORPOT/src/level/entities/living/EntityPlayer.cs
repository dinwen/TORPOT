using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Svennebanan;
using SpelProjekt.src.utils;
using TORPOT.src.level.entities.projectile;

namespace TORPOT.src.level.entities.living
{
    public class EntityPlayer : EntityLiving
    {

        private Animation sprint, idle, jump;
        private int direction = 1;

        public bool wallsliding = false;
        private int wallslideCooldown = 10;

        private enum STATE
        {
            sprint, idle, jumping
        }

        private STATE playerState = STATE.idle;

        public EntityPlayer(float x, float y) : base(x, y)
        {
            this.width = 64;
            this.height = 64;
            this.movementSpeed = 5;
            this.jumpHeight = 12;

            sprint = new Animation(3, 0, 0, 64, 64, 448, 64, true);
            idle = new Animation(35, 0, 3, 64, 64, 128, 64, true);
            jump = new Animation(0, 0, 5, 64, 64, 384, 64, true);
        }

        public override void Update()
        {
            wallsliding = false;
            base.Update();

            if (Math.Abs(velY) <= 0.01f) velY = 0;

            if(velY == 0 && OnGround() && InputHandler.jump)
            {

                velY -= jumpHeight;
                InputHandler.releaseJump = true;
            }

            if(wallsliding && --wallslideCooldown <= 0 && InputHandler.jump)
            {
                wallslideCooldown = 10;
                velY -= jumpHeight;
                velX = 10f * direction * -1;
                InputHandler.releaseJump = true;
            }

            if (velY < -jumpHeight) velY = -jumpHeight;
            velX /= 1.2f;
            x += velX;

            if (OnGround())
            {
                wallsliding = false;
            }
            else
            {
                playerState = STATE.jumping;

                if (jumpHeight + velY < 3) jump.setFrame(0);
                else if (velY < -3) jump.setFrame(1);
                else if (velY < 3) jump.setFrame(2);
                else if (velY >= 3) jump.setFrame(3);
            }

            if(InputHandler.shoot)
            {
                InputHandler.releaseShoot = true;
                InputHandler.shoot = false;

                level.AddEntity(new ProjectileShell(x, y, direction));
            }
        }

        public override void UpdateMovement()
        {
            base.UpdateMovement();
            Vector2 move = Vector2.Zero;
            if (InputHandler.right) move.X += movementSpeed;
            if (InputHandler.left) move.X -= movementSpeed;

            if(move != Vector2.Zero)
            {
                if (move.X > 0) direction = 1;
                else direction = -1;
                x += move.X;
                sprint.Update();
                playerState = STATE.sprint;
            }
            else
            {
                idle.Update();
                playerState = STATE.idle;
            }
                        
        }

        public override void Draw(SpriteBatch batch)
        {
            bool flip = direction == 1 ? false : true;
            if(wallsliding) batch.Draw(resources.images.GetImage("player"), new Vector2(GetXi(), GetYi()), null, new Rectangle(0, 4*64, 64, 64), new Vector2(0, 0), 0, new Vector2(1, 1), Color.White, direction == 1 ? SpriteEffects.FlipHorizontally : SpriteEffects.None, 0.5f);
            else if(playerState == STATE.sprint) batch.Draw(resources.images.GetImage("player"), new Vector2(GetXi(), GetYi()), null, sprint.GetRectangle(), new Vector2(0, 0), 0, new Vector2(1, 1), Color.White, direction == -1 ? SpriteEffects.FlipHorizontally : SpriteEffects.None, 0.5f);
            else if (playerState == STATE.idle) batch.Draw(resources.images.GetImage("player"), new Vector2(GetXi(), GetYi()), null, idle.GetRectangle(), new Vector2(0, 0), 0, new Vector2(1, 1), Color.White, direction == -1 ? SpriteEffects.FlipHorizontally : SpriteEffects.None, 0.5f);
            else if(playerState == STATE.jumping) batch.Draw(resources.images.GetImage("player"), new Vector2(GetXi(), GetYi()), null, jump.GetRectangle(), new Vector2(0, 0), 0, new Vector2(1, 1), Color.White, direction == -1 ? SpriteEffects.FlipHorizontally : SpriteEffects.None, 0.5f);
        }


    }
}
