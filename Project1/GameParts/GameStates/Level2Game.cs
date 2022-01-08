using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Project1.Collision;
using Project1.Components;
using Project1.Levels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project1.GameParts.GameStates
{
    public class Level2Game : GameState
    {
        Level2 level2;

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

        public Level2Game(ContentManager _content, GraphicsDevice _graphics, Game _game) : base(_content, _graphics, _game)
        {
            graphics = _graphics;
            game = _game;

            _camera = new Camera();

            Texture2D _vis = content.Load<Texture2D>("spritesheet_fish");
            vis = _vis;

            Texture2D _krab = content.Load<Texture2D>("krab");
            krab = _krab;

            Texture2D _duiker = content.Load<Texture2D>("diver3");
            duiker = _duiker;

            Texture2D _kwal = content.Load<Texture2D>("kwal");
            kwal = _kwal;

            Texture2D _schat = content.Load<Texture2D>("treasure2");
            schat = _schat;

            Texture2D _levens = content.Load<Texture2D>("hart2");
            levens = _levens;

            Texture2D _ancher = content.Load<Texture2D>("anker");
            ancher = _ancher;

            Texture2D _lijn = content.Load<Texture2D>("finishline");
            lijn = _lijn;

            Texture2D _achtergrond = content.Load<Texture2D>("oceaan");
            achtergrond = _achtergrond;

            SCollision = new SchatkistCollision();
            ECollision = new EnemyCollision();


            InitializeGameObjects();
        }

        private void InitializeGameObjects()
        {
            
            level2 = new Level2(_camera, vis, krab, duiker, kwal, ancher, schat, levens, lijn, achtergrond, SCollision, ECollision);
        }

        public override void Update(GameTime gameTime)
        {
            level2.Update(gameTime);
            if (level2.Loser == true)
                game.ChangeState(new Loser(content, graphics, game));

            if (level2.LevelEnd == true)
                game.ChangeState(new VictoryLevel2(content, graphics, game));
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin(SpriteSortMode.FrontToBack, transformMatrix: _camera.Volg);

            level2.Draw(spriteBatch);

            spriteBatch.End();
        }
    }
}
