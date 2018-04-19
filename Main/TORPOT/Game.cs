using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Svennebanan;
using TORPOT.level;
using TORPOT.level.Levels;
using TORPOT.src.gui;
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


        public static int WIDTH = 1920, HEIGHT = 1080;

        public enum STATE
        {
            Game, Menu, Quit, Levelhub, Levelone, Leveltwo,
        };

        public static STATE state = STATE.Menu;

        public Game()
        {
            resources = new ResourceManager();
            graphics = new GraphicsDeviceManager(this);
            graphics.PreferredBackBufferWidth = WIDTH;
            graphics.PreferredBackBufferHeight = HEIGHT;
            IsMouseVisible = true;
            Content.RootDirectory = "Content";
            graphics.IsFullScreen = true;
        }

        protected override void Initialize()
        {
            base.Initialize();

            inputHandler = new InputHandler();
            camera = new Svennebanan.Camera(GraphicsDevice.Viewport);

            camera.Zoom = 2f;

            levelHub = new LevelHub(resources);
            levelOne = new LevelOne(resources);
            state = STATE.Levelhub;
            level = new LevelOne(resources);
            mainMenu = new MainMenu(resources, new Vector2(), level);
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

            inputHandler.Update();

            switch (state)
            {
                case STATE.Levelhub:
                    levelHub.Update(gameTime);
                    break;

                case STATE.Levelone:
                    levelOne.Update(gameTime);
                    break;
            }
            //else if(state == STATE.Menu)
            //{
            //    mainMenu.Update();
            //}

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
                    levelHub.Draw(spriteBatch);
                    spriteBatch.End();
                    break;

                case STATE.Levelone:
                    spriteBatch.Begin(transformMatrix: camera.GetViewMatrix(), blendState: BlendState.NonPremultiplied, samplerState: SamplerState.PointClamp, depthStencilState: null, rasterizerState: null, effect: null, sortMode: SpriteSortMode.FrontToBack);
                    levelOne.Draw(spriteBatch);
                    spriteBatch.End();
                    break;
                    
                case STATE.Menu:
                    spritebBatch.Begin();
                    mainMenu.Draw(spritebatch);
                    spriteBatch.End();
                    break;
            }
            //else if(state == STATE.Menu)
            //{
            //    spriteBatch.Begin();
            //    mainMenu.Draw(spriteBatch);
            //}
            //spriteBatch.End();
            //hudBatch.End();

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

