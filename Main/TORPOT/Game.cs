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
        public static SoundEffectInstance musicHub;
        public static SoundEffectInstance musicLava;
        public static SoundEffectInstance musicForest;
        public static SoundEffectInstance musicWater;
        public static SoundEffectInstance musicCloud;

        MainMenu mainMenu;
        public static Camera camera;
        
        public static Level levelHub;
        public static Level levelOne;
        public static Level levelWater;
        public static Level levelLava;
        public static Level levelForest;
        public static Level levelCloud;

        public bool showControls = false;

        public static int scale = 1;
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

            state = STATE.Levelhub;
            levelHub.Reset();

        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            hudBatch = new SpriteBatch(GraphicsDevice);
            resources.LoadContent(Content);
                

            musicHub = resources.audio.GetSound(0).CreateInstance();
            musicLava = resources.audio.GetSound(5).CreateInstance();
            musicForest = resources.audio.GetSound(2).CreateInstance();
            musicCloud = resources.audio.GetSound(4).CreateInstance();
            musicWater = resources.audio.GetSound(3).CreateInstance();


            musicHub.IsLooped = true;
            musicLava.IsLooped = true;
            musicForest.IsLooped = true;
            musicCloud.IsLooped = true;
            musicWater.IsLooped = true;
        }

        protected override void UnloadContent()
        {
        }

        protected override void Update(GameTime gameTime)
        {

            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            inputHandler.Update();

            if(InputHandler.controls)
            {
                InputHandler.controls = false;
                InputHandler.releaseC = true;
                showControls = !showControls;
            }

            switch (state)
            {
                case STATE.Levelhub:
                    levelHub.Update(gameTime);
                    break;

                case STATE.Levelone:
                    levelOne.Update(gameTime);
                    break;

                case STATE.Levelwater:
                    levelWater.Update(gameTime);
                    break;

                case STATE.Levellava:
                    levelLava.Update(gameTime);
                    
                    break;

                case STATE.Levelforest:
                    levelForest.Update(gameTime);
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

            if(showControls)
            {
                hudBatch.Draw(resources.images.GetImage("controls"), new Vector2(WIDTH / 2 - 312/2, HEIGHT/2 - 346/2), null, Color.White, 0f, new Vector2(0, 0), 1, SpriteEffects.None, 0);
            }
            //else if(state == STATE.Menu)
            //{
            //    spriteBatch.Begin();
            //    mainMenu.Draw(spriteBatch);
            //}
            //spriteBatch.End();
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

