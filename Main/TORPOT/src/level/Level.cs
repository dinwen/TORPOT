using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Svennebanan;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TORPOT.src.level.entities;
<<<<<<< HEAD
using TORPOT.src.utils.gui;
=======
using TORPOT.src.level.entities.living;
>>>>>>> master

namespace TORPOT.level
{
    public class Level
    {

        public float gravity = 0.1f;

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

        public virtual void Update(GameTime gameTime)
        {
<<<<<<< HEAD
            if (InputHandler.right) Game.camera.Position.X+=5;
            if (InputHandler.down) Game.camera.Position.Y+=5;
            if (InputHandler.left) Game.camera.Position.X-=5;
            if (InputHandler.up) Game.camera.Position.Y-=5;

            

            

=======

            for(int i = 0; i < entities.Count(); i++)
            {
                entities[i].Update();
            }
            Game.camera.Position += new Vector2((int)((GetPlayer().GetX() - Game.WIDTH/2 + 32) - Game.camera.Position.X) / 5, (int)((GetPlayer().GetY() - Game.HEIGHT/2 + 32) - Game.camera.Position.Y) / 5);
>>>>>>> master
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
                hud.Draw(batch);
                batch.Draw(resourceManager.images.GetImage("Spritesheet"), t.position, t.texturePosition, Color.White, 0f, new Vector2(0, 0), 1, SpriteEffects.None, 0.1f);
            }

            for (int i = 0; i < entities.Count(); i++)
            {
                entities[i].Draw(batch);
            }

        }

    }
}
