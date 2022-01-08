/*using Microsoft.Xna.Framework;
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
        Button buttonPlay;
        Button buttonQuit;
        Button buttonBack;

        MenuBackground howtoBackground;


        public HowToPlay(ContentManager _content, GraphicsDevice _graphics, Game _game) : base(_content, _graphics, _game)
        {
            graphics = _graphics;
            game = _game;

            Texture2D texturePlay = content.Load<Texture2D>("button");
            Texture2D textureQuit = content.Load<Texture2D>("Quit");
            Texture2D textureBack = content.Load<Texture2D>("buttonBack");

            Texture2D textureHowTo = content.Load<Texture2D>("HowToPlay");


            buttonPlay = new Button(texturePlay, graphics);
            buttonPlay.SetPosition(new Vector2(Game.screenWidth / 2 - 60, Game.screenHeight / 2 - 100));

            buttonQuit = new Button(textureQuit, graphics);
            buttonQuit.SetPosition(new Vector2(Game.screenWidth / 2 - 60, Game.screenHeight / 2 + 66));

            buttonBack = new Button(textureBack, graphics);
            buttonBack.SetPosition(new Vector2(Game.screenWidth / 2 - 60, Game.screenHeight / 2));

            howtoBackground = new MenuBackground(textureHowTo);


        }

        public override void Update(Microsoft.Xna.Framework.GameTime gameTime)
        {
            game.IsMouseVisible = true;
            MouseState mouse = Mouse.GetState();

            if (buttonPlay.isClicked)
            {
                game.ChangeState(new Level1Game(content, graphics, game));
            }
            buttonPlay.Update(mouse);

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
            buttonPlay.Draw(spriteBatch);
            buttonQuit.Draw(spriteBatch);
            buttonBack.Draw(spriteBatch);
        }
    }
}

*/