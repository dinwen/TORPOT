using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Svennebanan;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TORPOT.src.level.entities;
using TORPOT.src.utils.gui;

namespace TORPOT.level
{
    public class Level
    {

        public ResourceManager resourceManager;
        public InputHandler inputHandler;
        public HUD hud;

        public LevelLoader levelLoader;

        
        public List<Tile> tiles = new List<Tile>();
        public List<Entity> entities = new List<Entity>();

        public Level(ResourceManager resources)
        {
            hud = new HUD(this);
            this.resourceManager = resources;
        }

        public void LoadLevel(string levelPath)
        {
            levelLoader = new LevelLoader(resourceManager, levelPath);
            tiles = levelLoader.GetLevelTiles();
        }

        public void Update(GameTime gameTime)
        {
            if (InputHandler.right) Game.camera.Position.X+=5;
            if (InputHandler.down) Game.camera.Position.Y+=5;
            if (InputHandler.left) Game.camera.Position.X-=5;
            if (InputHandler.up) Game.camera.Position.Y-=5;

            

            

        }
        
        public void Draw(SpriteBatch batch)
        {
            foreach (Tile t in tiles)
            {
                hud.Draw(batch);
                batch.Draw(resourceManager.images.GetImage("Spritesheet"), t.position, t.texturePosition, Color.White, 0f, new Vector2(0, 0), 1, SpriteEffects.None, 0.1f);
            }
        }

    }
}
