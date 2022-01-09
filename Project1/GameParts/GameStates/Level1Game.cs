using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Project1.Collision;
using Project1.Components;
using Project1.Levels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project1.GameParts.GameStates
{
    public class Level1Game : GameState
    {
        Level1 level1;

        public Camera _camera;

        private Texture2D vis;

        private Texture2D krab;

        private Texture2D duiker;

        private Texture2D kwal;

        private Texture2D ancher;

        private Texture2D schat;

        private Texture2D levens;

        private Texture2D lijn;

        private Texture2D achtergrond;

        private SchatkistCollision SCollision;
        private EnemyCollision ECollision;

        private SpriteFont font;
      

        public Level1Game(ContentManager _content, GraphicsDevice _graphics, Game _game) : base(_content, _graphics, _game)
        {
            graphics = _graphics;
            game = _game;

            _camera = new Camera();

            vis = content.Load<Texture2D>("spritesheet_fish");

            krab = content.Load<Texture2D>("krab");

            duiker = content.Load<Texture2D>("diver3");

            kwal = content.Load<Texture2D>("kwal");

            schat = content.Load<Texture2D>("treasure2");

            levens = content.Load<Texture2D>("hart2");

            ancher = content.Load<Texture2D>("anker");

            lijn = content.Load<Texture2D>("finishline");

            achtergrond = content.Load<Texture2D>("oceaan");

            SCollision = new SchatkistCollision();
            ECollision = new EnemyCollision();

            font = content.Load<SpriteFont>("Font");
            
            InitializeGameObjects();            
        }

        private void InitializeGameObjects()
        {
            level1 = new Level1(_camera, vis, krab, duiker, kwal, ancher, schat, levens, lijn, achtergrond, SCollision, ECollision);
        }

        public override void Update(GameTime gameTime)
        {
                level1.Update(gameTime);
                if (level1.Loser == true)
                    game.ChangeState(new Loser(content, graphics, game));

                if (level1.LevelEnd == true)
                    game.ChangeState(new VictoryLevel1(content, graphics, game));
        }

        public override void Draw(SpriteBatch spriteBatch)
        {             

            level1.Draw(spriteBatch);
            spriteBatch.Begin();
            spriteBatch.DrawString(font, Convert.ToString(SCollision.punten), new Vector2(Game.screenWidth -100, Game.screenHeight / 2-210), Color.Black);
            spriteBatch.End();

        }
    }
}
