using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;


namespace Project1.Interface
{
    interface IGameObject
    {
        void Update(GameTime gameTime);

        void Draw(SpriteBatch spriteBatch);
    }
}
