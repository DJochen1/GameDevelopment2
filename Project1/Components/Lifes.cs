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
    class Lifes : IGameObject
    {
        private Texture2D hartTexture;
        public Vector2 hartPositie;

        public Lifes(Texture2D texture, Vector2 positie)
        {
            hartTexture = texture;
            hartPositie = positie;
        }

        public void Update(GameTime gameTime)
        {            
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(hartTexture, hartPositie, null, Color.White, 0, new Vector2(0, 0), 1f, SpriteEffects.None, 0.98f);
        }
    }
}
