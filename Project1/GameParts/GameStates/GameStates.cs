using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project1.GameParts.GameStates
{
    public abstract class GameState
    {
        public ContentManager content;

        public GraphicsDevice graphics;

        public Game game;

        public GameState(ContentManager _content, GraphicsDevice _graphics, Game _game)
        {
            content = _content;
            graphics = _graphics;
            game = _game;
        }

        public abstract void Update(GameTime gameTime);

        public abstract void Draw(SpriteBatch spriteBatch);
    }
}
