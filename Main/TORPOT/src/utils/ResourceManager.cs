using Microsoft.Xna.Framework;
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

            images.AddImage("player", content.Load<Texture2D>("player"));

            //Menu
            //images.AddImage("play", content.Load<Texture2D>("PLAY"));
            //images.AddImage("quit", content.Load<Texture2D>("QUIT"));
            //images.AddImage("help", content.Load<Texture2D>("HELP"));

            //particles
            //images.AddImage("star", content.Load<Texture2D>("particle 16x16"));


            //tiles
            //tiles.AddTile(new Tile(0, 0, new Rectangle(64, 0, 64, 64), true));
            tiles.AddTile(new Tile(9, 0, new Rectangle(0, 0, 32, 32), true));
            tiles.AddTile(new Tile(9, 1, new Rectangle(0, 0, 32, 32), true));
            tiles.AddTile(new Tile(10, 1, new Rectangle(0, 0, 32, 32), true));

            //sounds
            //audio.AddAudio(0, content.Load<SoundEffect>("fly"));

            //font = content.Load<SpriteFont>("Score");
        }

    }
}
