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

        public static Level level;

        public static int WIDTH = 1920 / 2, HEIGHT = 1080 / 2;

        public enum STATE
        {
            Game, Menu, Quit
        };

        public static STATE state = STATE.Game;

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

            level = new LevelOne(resources);
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

            if(state == STATE.Game)
            {
                level.Update(gameTime);
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.DarkCyan);

            if(state == STATE.Game)
            {
                spriteBatch.Begin(transformMatrix: camera.GetViewMatrix(), blendState: BlendState.NonPremultiplied, samplerState: SamplerState.PointClamp, depthStencilState: null, rasterizerState: null, effect: null, sortMode: SpriteSortMode.FrontToBack);
                level.Draw(spriteBatch);
            }

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}

