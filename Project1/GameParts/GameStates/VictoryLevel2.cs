using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project1.GameParts.GameStates
{
    public class VictoryLevel2 : GameState
    {
        Button buttonMainMenu;
        Button buttonQuit;

        MenuBackground winnerLevel2;
        
        public VictoryLevel2(ContentManager _content, GraphicsDevice _graphics, Game _game) : base(_content, _graphics, _game)
        {
            graphics = _graphics;
            game = _game;

            Texture2D textureWinnerLevel2 = content.Load<Texture2D>("Level2Cleared");

            Texture2D textureMainMenu = content.Load<Texture2D>("buttonMenu");
            Texture2D textureQuit = content.Load<Texture2D>("Quit");

            winnerLevel2 = new MenuBackground(textureWinnerLevel2);

            buttonMainMenu = new Button(textureMainMenu, graphics);
            buttonMainMenu.SetPosition(new Vector2(Game.screenWidth / 2 - 160, Game.screenHeight / 2 - 60));

            buttonQuit = new Button(textureQuit, graphics);
            buttonQuit.SetPosition(new Vector2(Game.screenWidth / 2, Game.screenHeight / 2 - 60));
        }


        public override void Update(GameTime gameTime)
        {
            game.IsMouseVisible = true;
            MouseState mouse = Mouse.GetState();

            if (buttonMainMenu.isClicked)
            {
                game.ChangeState(new MainMenu(content, graphics, game));
            }
            buttonMainMenu.Update(mouse);

            if (buttonQuit.isClicked)
            {
                game.ChangeState(new End(content, graphics, game));
            }
            buttonQuit.Update(mouse);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            winnerLevel2.Draw(spriteBatch);
            buttonMainMenu.Draw(spriteBatch);
            buttonQuit.Draw(spriteBatch);
        }
    }
}

