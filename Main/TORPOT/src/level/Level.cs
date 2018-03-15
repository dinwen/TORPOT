using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Svennebanan;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TORPOT.src.level.entities;
using TORPOT.src.level.entities.living;

namespace TORPOT.level
{
    public class Level
    {

        public float gravity = 0.03f;

        public ResourceManager resourceManager;
        public InputHandler inputHandler;

        public LevelLoader levelLoader;

        
        public List<Tile> tiles = new List<Tile>();
        public List<Entity> entities = new List<Entity>();

        public Level(ResourceManager resources)
        {
            this.resourceManager = resources;
        }

        public void LoadLevel(string levelPath)
        {
            levelLoader = new LevelLoader(resourceManager, levelPath);
            tiles = levelLoader.GetLevelTiles();
        }

        public void Update(GameTime gameTime)
        {
            Game.camera.Position = new Vector2(GetPlayer().GetX() - 1920/2 + 32, GetPlayer().GetY() - 1080/2 + 32);

            for(int i = 0; i < entities.Count(); i++)
            {
                entities[i].Update();
            }
        }
        
        public void AddEntity(Entity e)
        {
            e.Init(this, resourceManager);
            entities.Add(e);
        }

        public EntityPlayer GetPlayer()
        {
            for(int i = 0; i < entities.Count; i++)
            {
                if (entities[i] is EntityPlayer) return (EntityPlayer)entities[i];
            }
            return null;
        }

        public void Draw(SpriteBatch batch)
        {
            foreach (Tile t in tiles)
            {
               
                batch.Draw(resourceManager.images.GetImage("Spritesheet"), t.position, t.texturePosition, Color.White, 0f, new Vector2(0, 0), 1, SpriteEffects.None, 0.1f);
            }

            for (int i = 0; i < entities.Count(); i++)
            {
                entities[i].Draw(batch);
            }

        }

    }
}
