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
    public class Anker : IGameObject
    {
        private Texture2D AnkerTexture;
        public Vector2 AnkerPositie;

        public Anker(Texture2D texture)
        {
            AnkerTexture = texture;

            AnkerPositie = new Vector2(750, 0);

        }

        public Rectangle Rectangle
        {
            get { return new Rectangle((int)AnkerPositie.X, (int)AnkerPositie.Y, 45, 350); }
        }

        public void Update(GameTime gameTime)
        {
            
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(AnkerTexture, AnkerPositie, null, Color.White, 0, new Vector2(0, 0), 1f, SpriteEffects.None, 0.8f);
        }
    }
}
