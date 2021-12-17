using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using Project1.Interface;
using Project1.Animation;
using Project1.Input;

namespace Project1.Components
{
    public class Treasure : IGameObject  
    {
        private Texture2D schatTexture;
        public Vector2 schatPositie;

        public bool remove = false;

        Random rnd = new Random();


        public Treasure(Texture2D texture)
        {
            schatTexture = texture;

            schatPositie = new Vector2(0, 0);

            schatPositie.X = rnd.Next(200, 5800);
            schatPositie.Y = rnd.Next(0, 400);
            schatPositie = JuistePositie(schatPositie);
        }

        public Rectangle Rectangle
        {
            get { return new Rectangle((int)schatPositie.X, (int)schatPositie.Y, 80, 80); }
        }

        public Vector2 JuistePositie(Vector2 positie)
        {
            if (positie.X < 900 && positie.X > 700)
                positie.X = rnd.Next(1000, 5800);
            return positie;
        }

        public void Update(GameTime gameTime)
        {
            
        }


        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(schatTexture, schatPositie, null, Color.White, 0, new Vector2(0, 0), 1f, SpriteEffects.None, 0.7f);
        }
    }
}
