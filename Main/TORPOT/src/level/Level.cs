﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Media;
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
        public HUD hud;
        public Game game;

        public SoundEffectInstance musicHub;
        public SoundEffectInstance musicLava;
        public SoundEffectInstance musicForest;
        public SoundEffectInstance musicWater;
        public SoundEffectInstance musicCloud;




        public List<Tile> tiles = new List<Tile>();
        public List<Entity> entities = new List<Entity>();

        public Level(ResourceManager resources)
        {
           
            this.resourceManager = resources;
            this.hud = new HUD(this);
            this.game = new Game();
        }

        public virtual void Reset()
        {
            entities.Clear();
            tiles.Clear();
              
        }
        public void LoadLevel(string levelPath, string layerPath)
        {
            musicHub = resourceManager.audio.GetSound(0).CreateInstance();
            musicLava = resourceManager.audio.GetSound(5).CreateInstance();
            musicForest = resourceManager.audio.GetSound(2).CreateInstance();
            musicCloud = resourceManager.audio.GetSound(4).CreateInstance();
            musicWater = resourceManager.audio.GetSound(3).CreateInstance();


            musicHub.IsLooped = true;
            musicLava.IsLooped = true;
            musicForest.IsLooped = true;
            musicCloud.IsLooped = true;
            musicWater.IsLooped = true;
            

            levelLoader = new LevelLoader(resourceManager, levelPath, layerPath);
            tiles = levelLoader.GetLevelTiles();

            if (Game.state == Game.STATE.Levelhub)
            {

               musicHub.Play();
            }
            if (Game.state == Game.STATE.Levelone)
            {

                musicCloud.Play();

            }
            if (Game.state == Game.STATE.Levellava)
            {

                musicLava.Play();
            }
            if (Game.state == Game.STATE.Levelwater)
            {

                musicWater.Play();
            }
            if (Game.state == Game.STATE.Levelforest)
            {

                musicForest.Play();
            }
            if(Game.state == Game.STATE.Menu)
            {
                musicHub.Play();
            }
        }

        public virtual void Update(GameTime gameTime)
        {

            hud.Update();
            for(int i = 0; i < entities.Count(); i++)
            {
                entities[i].Update();
                if (entities[i].isRemoved()) entities.RemoveAt(i);
            }
            Game.camera.Position += new Vector2((int)((GetPlayer().GetX() - Game.WIDTH/2 + 32) - Game.camera.Position.X) / 5, (int)((GetPlayer().GetY() - Game.HEIGHT/2 + 32) - Game.camera.Position.Y) / 5);
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

        public void Draw(SpriteBatch batch, SpriteBatch hudBatch)
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
