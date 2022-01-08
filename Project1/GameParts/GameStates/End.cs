using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Project1.Levels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project1.GameParts.GameStates
{
    public class End : GameState
    {
        public End(ContentManager _content, GraphicsDevice _graphics, Game _game) : base(_content, _graphics, _game)
        {

        }        

        public override void Update(GameTime gameTime)
        {
            game.Exit();
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
        }
    }
}
