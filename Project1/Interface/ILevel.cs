using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Project1.Interface
{
    interface ILevel
    {
        public void Draw(SpriteBatch _spriteBatch);

        public void Update(GameTime gameTime);
    }
}
