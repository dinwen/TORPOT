using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Svennebanan
{
    public class InputHandler
    {
        public static bool left;
        public static bool right;
        public static bool up;
        public static bool down;
        public static bool jump;
        public static bool interactDoor;
        public static bool shoot;

        public static bool releaseJump = false;
        public static bool releaseShoot = false;
        public static bool releaseShift = false;

        public static bool escape;
        public static bool shift;

        public void Update()
        {
            GamePadCapabilities capabilities = GamePad.GetCapabilities(PlayerIndex.One);

            if (Keyboard.GetState().IsKeyDown(Keys.K))
            {
                interactDoor = true;
            }
            else
            {
                interactDoor = false;
            }

            if (Keyboard.GetState().IsKeyDown(Keys.D))
            {
                right = true;
            }
            else
            {
                right = false;
            }

            if (Keyboard.GetState().IsKeyDown(Keys.A))
            {
                left = true;
            }
            else
            {
                left = false;
            }

            if (Keyboard.GetState().IsKeyDown(Keys.S))
            {
                down = true;
            }
            else
            {
                down = false;
            }

            if (Keyboard.GetState().IsKeyDown(Keys.W))
            {
                up = true;
            }
            else
            {
                up = false;
            }

            if(Keyboard.GetState().IsKeyDown(Keys.J))
            {
                if (!releaseShoot)
                {
                    shoot = true;
                }
            }
            else
            {
                releaseShoot = false;
                shoot = false;
            }

            if (Keyboard.GetState().IsKeyDown(Keys.Space) || Keyboard.GetState().IsKeyDown(Keys.W))
            {
                if(!releaseJump) jump = true;
            }
            else
            {
                if(!capabilities.IsConnected) releaseJump = false;
                jump = false;
            }

            if(Keyboard.GetState().IsKeyDown(Keys.LeftShift))
            {
                shift = true;
            }
            else
            {
                shift = false;
            }


            if (capabilities.IsConnected)
            {
                GamePadState state = GamePad.GetState(PlayerIndex.One);

                if (state.IsConnected && state.ThumbSticks.Left.X <= -0.5f)
                {
                    left = true;
                }
                else
                {
                    left = false;
                }
                if (state.IsConnected && state.ThumbSticks.Left.X >= 0.5f)
                {
                    right = true;
                }
                else
                {
                    right = false;
                }
                if (state.IsConnected && state.Buttons.A == ButtonState.Pressed)
                {
                    if (!releaseJump) jump = true;
                }
                else
                {
                    releaseJump = false;
                    jump = false;
                }
                if (state.IsConnected && state.Buttons.B == ButtonState.Pressed)
                {
                    if(!releaseShift) shift = true;
                }
                else
                {
                    releaseShift = false;
                    shift = false;
                }
                

            }
        }

    }
}
