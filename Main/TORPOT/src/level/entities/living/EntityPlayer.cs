using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Svennebanan;
using SpelProjekt.src.utils;

namespace TORPOT.src.level.entities.living
{
    public class EntityPlayer : EntityLiving
    {

        private Animation sprint;

        public EntityPlayer(float x, float y) : base(x, y)
        {
            this.width = 64;
            this.height = 64;
            this.movementSpeed = 5;
            this.jumpHeight = 6;

            sprint = new Animation(3, 0, 0, 64, 64, 448, 64, true);
        }

        public override void Update()
        {
            base.Update();
            sprint.Update();
           

            if(velY == 0 && OnGround() && InputHandler.jump)
            {
                velY -= jumpHeight;
                InputHandler.releaseJump = true;
            }

        }

        public override void UpdateMovement()
        {
            base.UpdateMovement();
            if (InputHandler.right) x += movementSpeed;
            if (InputHandler.left) x -= movementSpeed;
        }

        public override void Draw(SpriteBatch batch)
        {
            batch.Draw(resources.images.GetImage("player"), new Vector2(GetXi(), GetYi()), sprint.GetRectangle(), Color.White);
        }


    }
}
