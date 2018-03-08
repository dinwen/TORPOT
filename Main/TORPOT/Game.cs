using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Svennebanan;
using TORPOT.level;

namespace TORPOT
{
    public class Game : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        ResourceManager resources;

        public static Camera camera;

        public static Level level;

        public enum STATE
        {
            Game, Menu, Quit
        };

        public static STATE state = STATE.Game;

        public Game()
        {
            resources = new ResourceManager();
            graphics = new GraphicsDeviceManager(this);
            graphics.PreferredBackBufferWidth = 1920;
            graphics.PreferredBackBufferHeight = 1080;
            IsMouseVisible = true;
            Content.RootDirectory = "Content";
            graphics.IsFullScreen = false;
        }

        protected override void Initialize()
        {
            base.Initialize();

            camera = new Svennebanan.Camera(GraphicsDevice.Viewport);
            camera.Zoom = 1f;

            level = new Level(resources);
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


            if(state == STATE.Game)
            {
                level.Update(gameTime);
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

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

