﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Svennebanan.utils;

namespace Svennebanan
{
    public class ResourceManager
    {
        public static SpriteFont font;
        public ImageHandler images;
        public TileHandler tiles;
        public AudioHandler audio;

        public ResourceManager()
        {
            images = new ImageHandler();
            tiles = new TileHandler();
            audio = new AudioHandler();
        }

        public void LoadContent(ContentManager content)
        {
            images.AddImage("Spritesheet", content.Load<Texture2D>("Tile sheet v.3 32x32"));

            images.AddImage("player", content.Load<Texture2D>("playerSheet"));
            images.AddImage("walker", content.Load<Texture2D>("walker sprite sheet"));

            images.AddImage("testParticle", content.Load<Texture2D>("testParticle"));


            images.AddImage("projectile", content.Load<Texture2D>("projectile"));

            images.AddImage("HealthbarBackground", content.Load<Texture2D>("Lifebar black"));
            images.AddImage("HealthbarHealth", content.Load<Texture2D>("Lifebar color"));
            images.AddImage("HealthbarFrame", content.Load<Texture2D>("Lifebar frame"));
            images.AddImage("ItemHUD", content.Load<Texture2D>("itemhud"));



            //menu
            images.AddImage("Play", content.Load<Texture2D>("itemhud"));
            images.AddImage("Quit", content.Load<Texture2D>("itemhud"));



            //Menu
            //images.AddImage("play", content.Load<Texture2D>("PLAY"));
            //images.AddImage("quit", content.Load<Texture2D>("QUIT"));
            //images.AddImage("help", content.Load<Texture2D>("HELP"));

            //particles
            //images.AddImage("star", content.Load<Texture2D>("particle 16x16"));


            //tiles
            //tiles.AddTile(new Tile(0, 0, new Rectangle(64, 0, 64, 64), true));

            tiles.AddTile(new Tile(0, 0, new Rectangle(0, 0, 32, 32), true));
            tiles.AddTile(new Tile(1, 0, new Rectangle(0, 0, 32, 32), true));
            tiles.AddTile(new Tile(2, 0, new Rectangle(0, 0, 32, 32), true));
            tiles.AddTile(new Tile(3, 0, new Rectangle(0, 0, 32, 32), true));
            tiles.AddTile(new Tile(4, 0, new Rectangle(0, 0, 32, 32), true));
            tiles.AddTile(new Tile(5, 0, new Rectangle(0, 0, 32, 32), true));
            tiles.AddTile(new Tile(6, 0, new Rectangle(0, 0, 32, 32), true));
            tiles.AddTile(new Tile(7, 0, new Rectangle(0, 0, 32, 32), true));
            tiles.AddTile(new Tile(8, 0, new Rectangle(0, 0, 32, 32), true));
            tiles.AddTile(new Tile(9, 0, new Rectangle(0, 0, 32, 32), true));
            tiles.AddTile(new Tile(10, 0, new Rectangle(0, 0, 32, 32), true));
            tiles.AddTile(new Tile(11, 0, new Rectangle(0, 0, 32, 32), true));
            tiles.AddTile(new Tile(12, 0, new Rectangle(0, 0, 32, 32), true));
            tiles.AddTile(new Tile(13, 0, new Rectangle(0, 0, 32, 32), true));

            tiles.AddTile(new Tile(0, 1, new Rectangle(0, 0, 32, 32), true));
            tiles.AddTile(new Tile(1, 1, new Rectangle(0, 0, 32, 32), true));
            tiles.AddTile(new Tile(9, 1, new Rectangle(0, 0, 32, 32), true));
            tiles.AddTile(new Tile(10, 1, new Rectangle(0, 0, 32, 32), true));
            tiles.AddTile(new Tile(11, 1, new Rectangle(0, 0, 32, 32), true));
            tiles.AddTile(new Tile(12, 1, new Rectangle(0, 0, 32, 32), true));
            tiles.AddTile(new Tile(13, 1, new Rectangle(0, 0, 32, 32), true));

            tiles.AddTile(new Tile(0, 2, new Rectangle(0, 0, 32, 32), true));
            tiles.AddTile(new Tile(1, 2, new Rectangle(0, 0, 32, 32), true));
            tiles.AddTile(new Tile(2, 2, new Rectangle(0, 0, 32, 32), true));
            tiles.AddTile(new Tile(3, 2, new Rectangle(0, 0, 32, 32), true));
            tiles.AddTile(new Tile(9, 2, new Rectangle(0, 0, 32, 32), true));
            tiles.AddTile(new Tile(11, 2, new Rectangle(0, 0, 32, 32), true));

            tiles.AddTile(new Tile(0, 3, new Rectangle(0, 0, 32, 32), true));
            tiles.AddTile(new Tile(1, 3, new Rectangle(0, 0, 32, 32), true));
            tiles.AddTile(new Tile(2, 3, new Rectangle(0, 0, 32, 32), true));
            tiles.AddTile(new Tile(3, 3, new Rectangle(0, 0, 32, 32), true));
            tiles.AddTile(new Tile(4, 3, new Rectangle(0, 0, 32, 32), true));
            tiles.AddTile(new Tile(9, 3, new Rectangle(0, 0, 32, 32), true));
            tiles.AddTile(new Tile(10, 3, new Rectangle(0, 0, 32, 32), true));
            tiles.AddTile(new Tile(11, 3, new Rectangle(0, 0, 32, 32), true));

            tiles.AddTile(new Tile(0, 4, new Rectangle(0, 0, 32, 32), true));
            tiles.AddTile(new Tile(1, 4, new Rectangle(0, 0, 32, 32), true));
            tiles.AddTile(new Tile(2, 4, new Rectangle(0, 0, 32, 32), true));
            tiles.AddTile(new Tile(3, 4, new Rectangle(0, 0, 32, 32), true));
            tiles.AddTile(new Tile(4, 4, new Rectangle(0, 0, 32, 32), true));
            tiles.AddTile(new Tile(5, 4, new Rectangle(0, 0, 32, 32), true));
            tiles.AddTile(new Tile(6, 4, new Rectangle(0, 0, 32, 32), true));
            tiles.AddTile(new Tile(7, 4, new Rectangle(0, 0, 32, 32), true));
            tiles.AddTile(new Tile(8, 4, new Rectangle(0, 0, 32, 32), true));
            tiles.AddTile(new Tile(9, 4, new Rectangle(0, 0, 32, 32), true));
            tiles.AddTile(new Tile(10, 4, new Rectangle(0, 0, 32, 32), true));
            tiles.AddTile(new Tile(11, 4, new Rectangle(0, 0, 32, 32), true));

            tiles.AddTile(new Tile(0, 5, new Rectangle(0, 0, 32, 32), true));
            tiles.AddTile(new Tile(1, 5, new Rectangle(0, 0, 32, 32), true));
            tiles.AddTile(new Tile(2, 5, new Rectangle(0, 0, 32, 32), true));
            tiles.AddTile(new Tile(3, 5, new Rectangle(0, 0, 32, 32), true));
            tiles.AddTile(new Tile(4, 5, new Rectangle(0, 0, 32, 32), true));
            tiles.AddTile(new Tile(5, 5, new Rectangle(0, 0, 32, 32), true));
            tiles.AddTile(new Tile(6, 5, new Rectangle(0, 0, 32, 32), true));
            tiles.AddTile(new Tile(7, 5, new Rectangle(0, 0, 32, 32), true));
            tiles.AddTile(new Tile(8, 5, new Rectangle(0, 0, 32, 32), true));
            tiles.AddTile(new Tile(9, 5, new Rectangle(0, 0, 32, 32), true));
            tiles.AddTile(new Tile(10, 5, new Rectangle(0, 0, 32, 32), true));
            tiles.AddTile(new Tile(11, 5, new Rectangle(0, 0, 32, 32), true));

            tiles.AddTile(new Tile(0, 6, new Rectangle(0, 0, 32, 32), true));
            tiles.AddTile(new Tile(1, 6, new Rectangle(0, 0, 32, 32), true));
            tiles.AddTile(new Tile(2, 6, new Rectangle(0, 0, 32, 32), true));
            tiles.AddTile(new Tile(3, 6, new Rectangle(0, 0, 32, 32), true));
            tiles.AddTile(new Tile(4, 6, new Rectangle(0, 0, 32, 32), true));
            tiles.AddTile(new Tile(5, 6, new Rectangle(0, 0, 32, 32), true));
            tiles.AddTile(new Tile(6, 6, new Rectangle(0, 0, 32, 32), true));
            tiles.AddTile(new Tile(7, 6, new Rectangle(0, 0, 32, 32), true));
            tiles.AddTile(new Tile(8, 6, new Rectangle(0, 0, 32, 32), true));




            //sounds
            //audio.AddAudio(0, content.Load<SoundEffect>("fly"));

            //font = content.Load<SpriteFont>("Score");
        }

    }
}
