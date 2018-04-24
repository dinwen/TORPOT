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
using TORPOT.src.utils.gui;

namespace TORPOT.level
{
    public class Level
    {

        public float gravity = 0.4f;

        public ResourceManager resourceManager;
        public InputHandler inputHandler;
        public LevelLoader levelLoader;
        public static HUD hud;
        public Vector2 size;

        
        public List<Tile> tiles = new List<Tile>();
        public List<Entity> entities = new List<Entity>();

        public Level(ResourceManager resources)
        {
            
            this.resourceManager = resources;
            hud = new HUD(this);
        }

        public virtual void Reset()
        {
            entities.Clear();
            tiles.Clear();
              
        }
        public void LoadLevel(string levelPath, string layerPath)
        {
            levelLoader = new LevelLoader(resourceManager, levelPath, layerPath);
            tiles = levelLoader.GetLevelTiles();
            size = levelLoader.size;
            Console.WriteLine(size.X + ", " + size.Y);
        }

        public virtual void Update(GameTime gameTime)
        {

            hud.Update();
            for(int i = 0; i < entities.Count(); i++)
            {
                entities[i].Update();
                if (entities[i].isRemoved()) entities.RemoveAt(i);
            }

            Camera c = Game.camera;
            c.Position += new Vector2((int)((GetPlayer().GetX() - Game.WIDTH/2 + 32) - Game.camera.Position.X) / 5, 0); // (int)((GetPlayer().GetY() - Game.HEIGHT/2 + 32) - Game.camera.Position.Y) / 5

            //Console.WriteLine(c.Position.X + ", " + c.Position.Y);
            if (c.Position.X < -Game.WIDTH / 4) c.Position = new Vector2(-Game.WIDTH / 4, c.Position.Y);
            else if (c.Position.X > (size.X) * 32 - (Game.WIDTH * 0.75f)) c.Position = new Vector2((size.X) * 32 - (Game.WIDTH * 0.75f), c.Position.Y);
            if (c.Position.Y > size.Y * 32 - Game.HEIGHT *0.75f) c.Position = new Vector2(c.Position.X, size.Y * 32 - Game.HEIGHT *0.75f);
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

        public virtual void Draw(SpriteBatch batch, SpriteBatch hudBatch)
        {
            foreach (Tile t in tiles)
            {
               
                batch.Draw(resourceManager.images.GetImage("Spritesheet"), t.position, t.texturePosition, Color.White, 0f, new Vector2(0, 0), 1, SpriteEffects.None, 0.4f);
            }

            for (int i = 0; i < entities.Count(); i++)
            {
                entities[i].Draw(batch);
            }

            hud.Draw(hudBatch);

        }

    }
}
