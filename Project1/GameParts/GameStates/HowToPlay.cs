using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project1.GameParts.GameStates
{
    class HowToPlay : GameState
    {
        Button buttonQuit;
        Button buttonBack;

        MenuBackground howtoBackground;

        public HowToPlay(ContentManager _content, GraphicsDevice _graphics, Game _game) : base(_content, _graphics, _game)
        {
            graphics = _graphics;
            game = _game;

            //content inladen
            Texture2D textureHowTo = content.Load<Texture2D>("HowToPlay");

            Texture2D textureQuit = content.Load<Texture2D>("Quit");
            Texture2D textureBack = content.Load<Texture2D>("buttonBack");

            //ingeladen content toewijzen + het positioneren van de knoppen
            howtoBackground = new MenuBackground(textureHowTo);

            buttonBack = new Button(textureBack, graphics);
            buttonBack.SetPosition(new Vector2(Game.screenWidth / 2 - 160, Game.screenHeight / 2 - 270));

            buttonQuit = new Button(textureQuit, graphics);
            buttonQuit.SetPosition(new Vector2(Game.screenWidth / 2 , Game.screenHeight /2- 270));

        }

        public override void Update(GameTime gameTime)
        {
            game.IsMouseVisible = true;
            MouseState mouse = Mouse.GetState();

            if (buttonQuit.isClicked)
            {
                game.ChangeState(new End(content, graphics, game));
            }
            buttonQuit.Update(mouse);

            if (buttonBack.isClicked)
            {
                game.ChangeState(new MainMenu(content, graphics, game));
            }
            buttonBack.Update(mouse);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            howtoBackground.Draw(spriteBatch);
            buttonQuit.Draw(spriteBatch);
            buttonBack.Draw(spriteBatch);
        }
    }
}

