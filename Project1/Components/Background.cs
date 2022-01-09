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
    public class Background : IGameObject
    {
        private Texture2D BackgroundTexture;
        public Vector2 BackgroundPositie;


        public Rectangle Rectangle
        {
            get { return new Rectangle((int)BackgroundPositie.X, (int)BackgroundPositie.Y, BackgroundTexture.Width, BackgroundTexture.Height); }
        }

        public Background(Texture2D texture)
        {
            BackgroundTexture = texture;

        }
        public void Update(GameTime gameTime)
        {
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(BackgroundTexture, BackgroundPositie, null, Color.White, 0, new Vector2(0, 0), 1f, SpriteEffects.None, 0.2f);
        }

    }
}
