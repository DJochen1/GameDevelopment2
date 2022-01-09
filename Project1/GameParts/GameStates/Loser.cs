using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project1.GameParts.GameStates
{
    public class Loser : GameState
    {        
        MenuBackground loserBackground;
        Button buttonQuit;
        Button buttonMenu;

        public Loser(ContentManager _content, GraphicsDevice _graphics, Game _game) : base(_content, _graphics, _game)
        {
            Texture2D textureLoser = content.Load<Texture2D>("loser");

            Texture2D textureQuit = content.Load<Texture2D>("Quit");
            Texture2D textureMenu = content.Load<Texture2D>("buttonMenu");

            loserBackground = new MenuBackground(textureLoser);

            buttonQuit = new Button(textureQuit, graphics);
            buttonQuit.SetPosition(new Vector2(Game.screenWidth / 2 -160, Game.screenHeight / 2 + 66));

            buttonMenu = new Button(textureMenu, graphics);
            buttonMenu.SetPosition(new Vector2(Game.screenWidth / 2 , Game.screenHeight / 2 +66 ));
        }

        public override void Update(GameTime gameTime)
        {
            game.IsMouseVisible = true;
            MouseState mouse = Mouse.GetState();

            if (buttonMenu.isClicked)
            {
                game.ChangeState(new MainMenu(content, graphics, game));
            }
            buttonMenu.Update(mouse);

            if (buttonQuit.isClicked)
            {
                game.ChangeState(new End(content, graphics, game));
            }
            buttonQuit.Update(mouse);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            loserBackground.Draw(spriteBatch);
            buttonMenu.Draw(spriteBatch); 
            buttonQuit.Draw(spriteBatch);
        }
    }
}