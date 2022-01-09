using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project1.Components;
using System;
using System.Collections.Generic;
using System.Text;
using Project1;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;

namespace Project1.GameParts.GameStates
{
    public class MainMenu : GameState
    {
        Button buttonPlay;
        Button buttonQuit;
        Button buttonHow;
        MenuBackground menuBackground;

        public MainMenu(ContentManager _content, GraphicsDevice _graphics, Game _game) : base(_content, _graphics, _game)
        {
            graphics = _graphics;
            game = _game;

            Texture2D textureMenu = content.Load<Texture2D>("MainMenu");

            Texture2D texturePlay = content.Load<Texture2D>("button");
            Texture2D textureHow = content.Load<Texture2D>("buttonHow");
            Texture2D textureQuit = content.Load<Texture2D>("Quit");

            menuBackground = new MenuBackground(textureMenu);

            buttonPlay = new Button(texturePlay, graphics);
            buttonPlay.SetPosition(new Vector2(Game.screenWidth / 2 - 90, Game.screenHeight /2- 90));

            buttonHow = new Button(textureHow, graphics);
            buttonHow.SetPosition(new Vector2(Game.screenWidth / 2 - 90, Game.screenHeight / 2));

            buttonQuit = new Button(textureQuit, graphics);
            buttonQuit.SetPosition(new Vector2(Game.screenWidth / 2 - 90, Game.screenHeight / 2 +90));

        }
                
        public override void Update(GameTime gameTime)
        {
            game.IsMouseVisible = true;
            MouseState mouse = Mouse.GetState();

            if (buttonPlay.isClicked)
            {                
                game.ChangeState(new Level1Game(content, graphics, game));
            }
            buttonPlay.Update(mouse);

            if (buttonHow.isClicked)
            {
                game.ChangeState(new HowToPlay(content, graphics, game));
            }
            buttonHow.Update(mouse);

            if (buttonQuit.isClicked)
            {
                game.ChangeState(new End(content, graphics, game));
            }
            buttonQuit.Update(mouse);            
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            menuBackground.Draw(spriteBatch);
            buttonPlay.Draw(spriteBatch);
            buttonHow.Draw(spriteBatch);
            buttonQuit.Draw(spriteBatch);
        }

    }
}