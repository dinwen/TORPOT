using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using Svennebanan;
using System;
using TORPOT.level;
using TORPOT.level.Levels;
using TORPOT.src.gui;
using TORPOT.src.level.Levels;
using TORPOT.src.utils.gui;

namespace TORPOT
{
    public class Game : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        ResourceManager resources;
        InputHandler inputHandler;
        SpriteBatch hudBatch;

        

        MainMenu mainMenu;
        public static Camera camera;
        
        public static Level levelHub;
        public static Level levelOne;
        public static Level levelWater;
        public static Level levelLava;
        public static Level levelForest;
        public static Level levelCloud;

        public static int scale = 2;
        public static int WIDTH = 480 * scale, HEIGHT = 288 * scale;

        public enum STATE
        {
            Game, Menu, Quit, Levelhub, Levelone, Leveltwo, Levelwater, Levellava, Levelforest, Levelcloud
        };

        public static STATE state;
       

        public Game()
        {
            resources = new ResourceManager();
            graphics = new GraphicsDeviceManager(this);
            graphics.PreferredBackBufferWidth = WIDTH;
            graphics.PreferredBackBufferHeight = HEIGHT;
            IsMouseVisible = true;
            Content.RootDirectory = "Content";
            graphics.IsFullScreen = false;


            

        }

        protected override void Initialize()
        {
            base.Initialize();

            inputHandler = new InputHandler();
            camera = new Svennebanan.Camera(GraphicsDevice.Viewport);

            camera.Zoom = scale;

            levelHub = new LevelHub(resources);
            levelOne = new LevelOne(resources);
            levelWater = new LevelWater(resources);
            levelLava = new LevelLava(resources);
            levelForest = new LevelForest(resources);
            levelCloud = new LevelCloud(resources);
            mainMenu = new MainMenu(resources, new Vector2(), levelHub);
<<<<<<< HEAD
            state = STATE.Menu;

            
=======

            state = STATE.Levelwater;

            if(state == STATE.Levelhub)
            {

                musicHub.Play();
            }
            if (state == STATE.Levelone)
            {

                musicCloud.Play();
                
            }
            if (state == STATE.Levellava)
            {

                musicLava.Play();
            }
            if (state == STATE.Levelwater)
            {

                musicWater.Play();
            }
            if(state == STATE.Levelforest)
            {

                musicForest.Play();
            }

>>>>>>> realMaster
        }

        protected override void LoadContent()
        {
            
            spriteBatch = new SpriteBatch(GraphicsDevice);
            hudBatch = new SpriteBatch(GraphicsDevice);
            resources.LoadContent(Content);
                

            
        }

        protected override void UnloadContent()
        {
        }

        protected override void Update(GameTime gameTime)
        {

            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            mainMenu.Update();
            inputHandler.Update();

            

            switch (state)
            {
                case STATE.Levelhub:
                    levelHub.Update(gameTime);
                    MediaPlayer.Stop();
                    break;

                case STATE.Levelone:
                    levelOne.Update(gameTime);
                    MediaPlayer.Stop();
                    
                    break;

                case STATE.Levelwater:
                    levelWater.Update(gameTime);
                    MediaPlayer.Stop();
                    
                    break;

                case STATE.Levellava:
                    levelLava.Update(gameTime);
                    
                    break;

                case STATE.Levelforest:
                    levelForest.Update(gameTime);
                    MediaPlayer.Stop();
                    break;
                case STATE.Levelcloud:
                    levelCloud.Update(gameTime);
                    break;
            }

            //if(state == STATE.Game)
            //{
            //    level.Update(gameTime);
            //}

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.DarkCyan);
            
            hudBatch.Begin(SpriteSortMode.BackToFront, null);
            
            switch (state)

            {
             



                case STATE.Levelhub:
                    spriteBatch.Begin(transformMatrix: camera.GetViewMatrix(), blendState: BlendState.NonPremultiplied, samplerState: SamplerState.PointClamp, depthStencilState: null, rasterizerState: null, effect: null, sortMode: SpriteSortMode.FrontToBack);
                    levelHub.Draw(spriteBatch, hudBatch);
                    spriteBatch.End();
                    break;

                case STATE.Levelone:
                    spriteBatch.Begin(transformMatrix: camera.GetViewMatrix(), blendState: BlendState.NonPremultiplied, samplerState: SamplerState.PointClamp, depthStencilState: null, rasterizerState: null, effect: null, sortMode: SpriteSortMode.FrontToBack);
                    levelOne.Draw(spriteBatch, hudBatch);
                    spriteBatch.End();
                    break;

                case STATE.Levelwater:
                    spriteBatch.Begin(transformMatrix: camera.GetViewMatrix(), blendState: BlendState.NonPremultiplied, samplerState: SamplerState.PointClamp, depthStencilState: null, rasterizerState: null, effect: null, sortMode: SpriteSortMode.FrontToBack);
                    levelWater.Draw(spriteBatch, hudBatch);
                    spriteBatch.End();
                    break;

                case STATE.Levellava:
                    spriteBatch.Begin(transformMatrix: camera.GetViewMatrix(), blendState: BlendState.NonPremultiplied, samplerState: SamplerState.PointClamp, depthStencilState: null, rasterizerState: null, effect: null, sortMode: SpriteSortMode.FrontToBack);
                    levelLava.Draw(spriteBatch, hudBatch);
                    spriteBatch.End();
                    break;

                case STATE.Levelforest:
                    spriteBatch.Begin(transformMatrix: camera.GetViewMatrix(), blendState: BlendState.NonPremultiplied, samplerState: SamplerState.PointClamp, depthStencilState: null, rasterizerState: null, effect: null, sortMode: SpriteSortMode.FrontToBack);
                    levelForest.Draw(spriteBatch, hudBatch);
                    spriteBatch.End();
                    break;

                case STATE.Levelcloud:
                    spriteBatch.Begin(transformMatrix: camera.GetViewMatrix(), blendState: BlendState.NonPremultiplied, samplerState: SamplerState.PointClamp, depthStencilState: null, rasterizerState: null, effect: null, sortMode: SpriteSortMode.FrontToBack);
                    levelCloud.Draw(spriteBatch, hudBatch);
                    spriteBatch.End();
                    break;

                case STATE.Menu:
                    spriteBatch.Begin();
                    mainMenu.Draw(spriteBatch);
                    spriteBatch.End();
                    break;
            }

            //else if(state == STATE.Menu)
            //{
                //spriteBatch.Begin();
               // mainMenu.Draw(spriteBatch);
            //}
            spriteBatch.End();
            hudBatch.End();

            //if(state == STATE.Game)
            //{
            //    spriteBatch.Begin(transformMatrix: camera.GetViewMatrix(), blendState: BlendState.NonPremultiplied, samplerState: SamplerState.PointClamp, depthStencilState: null, rasterizerState: null, effect: null, sortMode: SpriteSortMode.FrontToBack);
            //    level.Draw(spriteBatch);
            //}

            //spriteBatch.End();


            base.Draw(gameTime);
        }
    }
}

