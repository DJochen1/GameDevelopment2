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
        Button buttonPlay;
        Button buttonQuit;

        public Loser(ContentManager _content, GraphicsDevice _graphics, Game _game) : base(_content, _graphics, _game)
        {
            Texture2D texturePlay = content.Load<Texture2D>("button");
            Texture2D textureQuit = content.Load<Texture2D>("Quit");

            Texture2D textureLoser = content.Load<Texture2D>("loser");

            buttonPlay = new Button(texturePlay, graphics);
            buttonPlay.SetPosition(new Vector2(Game.screenWidth / 2 - 60, Game.screenHeight / 2 - 100));

            buttonQuit = new Button(textureQuit, graphics);
            buttonQuit.SetPosition(new Vector2(Game.screenWidth / 2 - 60, Game.screenHeight / 2 + 66));

            loserBackground = new MenuBackground(textureLoser);
        }

        public override void Update(GameTime gameTime)
        {
            game.IsMouseVisible = true;
            MouseState mouse = Mouse.GetState();

            // TODO 
            // MAINMENU NOT LEVEL1!!!!!

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
        }

        public override void Draw(SpriteBatch spriteBatch/*, GameTime gameTime*/)
        {
            loserBackground.Draw(spriteBatch);
            buttonPlay.Draw(spriteBatch);
            buttonQuit.Draw(spriteBatch);
        }
    }
}