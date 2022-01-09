using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project1.GameParts.GameStates
{
    public class VictoryLevel1 : GameState
    {
        Button buttonNext;
        Button buttonQuit;

        MenuBackground winnerLevel1;

        public VictoryLevel1(ContentManager _content, GraphicsDevice _graphics, Game _game) : base(_content, _graphics, _game)
        {
            graphics = _graphics;
            game = _game;

            Texture2D textureWinnerLevel1 = content.Load<Texture2D>("Level1Cleared");

            Texture2D textureNext = content.Load<Texture2D>("NextLevel");
            Texture2D textureQuit = content.Load<Texture2D>("Quit");

            winnerLevel1 = new MenuBackground(textureWinnerLevel1);

            buttonNext = new Button(textureNext, graphics);
            buttonNext.SetPosition(new Vector2(Game.screenWidth / 2 - 160, Game.screenHeight / 2-60));

            buttonQuit = new Button(textureQuit, graphics);
            buttonQuit.SetPosition(new Vector2(Game.screenWidth / 2 , Game.screenHeight / 2-60));
        }

        public override void Update(GameTime gameTime)
        {
            game.IsMouseVisible = true;
            MouseState mouse = Mouse.GetState();

            if (buttonNext.isClicked)
            {
                game.ChangeState(new Level2Game(content, graphics, game));
            }
            buttonNext.Update(mouse);

            if (buttonQuit.isClicked)
            {
                game.ChangeState(new End(content, graphics, game));
            }
            buttonQuit.Update(mouse);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            winnerLevel1.Draw(spriteBatch);
            buttonNext.Draw(spriteBatch);
            buttonQuit.Draw(spriteBatch);
        }
    }
}