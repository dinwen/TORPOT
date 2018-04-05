using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Svennebanan;
using TORPOT.level;
using TORPOT.level.Levels;

namespace TORPOT
{
    public class Game : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        ResourceManager resources;
        InputHandler inputHandler;

        public static Camera camera;
        
        public static Level levelHub;
        public static Level levelOne;


        public static int WIDTH = 1920 / 2, HEIGHT = 1080 / 2;

        public enum STATE
        {
            Game, Menu, Quit, LevelHub, LevelOne, LevelTwo,
        };

        //public static STATE state = STATE.Game;
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
            camera.Zoom = 1f;
            

            levelHub = new LevelOne(resources);
            levelOne = new LevelOne(resources);

            state = STATE.LevelHub;
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            resources.LoadContent(Content);
        }

        protected override void UnloadContent()
        {
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            inputHandler.Update();

            switch (state)
            {
                case STATE.LevelHub:
                    levelHub.Update(gameTime);
                    break;

                case STATE.LevelOne:
                    levelOne.Update(gameTime);
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

            switch (state)
            {
                case STATE.LevelHub:
                    spriteBatch.Begin(transformMatrix: camera.GetViewMatrix(), blendState: BlendState.NonPremultiplied, samplerState: SamplerState.PointClamp, depthStencilState: null, rasterizerState: null, effect: null, sortMode: SpriteSortMode.FrontToBack);
                    levelHub.Draw(spriteBatch);
                    spriteBatch.End();
                    break;

                case STATE.LevelOne:
                    spriteBatch.Begin(transformMatrix: camera.GetViewMatrix(), blendState: BlendState.NonPremultiplied, samplerState: SamplerState.PointClamp, depthStencilState: null, rasterizerState: null, effect: null, sortMode: SpriteSortMode.FrontToBack);
                    levelOne.Draw(spriteBatch);
                    spriteBatch.End();
                    break;
            }

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

