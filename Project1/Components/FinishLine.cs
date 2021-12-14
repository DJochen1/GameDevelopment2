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
    public class FinishLine : IGameObject
    {
        private Texture2D FinishTexture;
        private Vector2 FinishPositie;

        public FinishLine(Texture2D texture)
        {
            FinishTexture = texture;
            FinishPositie = new Vector2(5900, 0);
        }

        public Rectangle Rectangle
        {
            get { return new Rectangle((int)FinishPositie.X, (int)FinishPositie.Y, FinishTexture.Width, FinishTexture.Height); }
        }

        public void Update(GameTime gameTime)
        {
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(FinishTexture, FinishPositie, null, Color.White, 0, new Vector2(0, 0), 1f, SpriteEffects.None, 0.8f);
        }
    }
}
