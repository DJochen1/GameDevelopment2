using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;
using Project1.Input;
using Project1.Components;
using Project1.Interface;
using System.Diagnostics;
using Project1.Collision;
using Project1.Components.Enemys;
using System.Windows.Forms;

namespace Project1.Levels
{
    public class Level1 : ILevel
    {
        public bool LevelEnd = false;
        public bool Loser = false;

        private Camera camera;

        private Fish fish;

        Crab crab;

        Diver diver;

        private List<Jellyfish> jellyfish;

        Anker anker;

        private List<Treasure> treasure;

        private List<Lifes> lifes;

        FinishLine finish;

        private List<Background> background;

        SchatkistCollision SCollision;
        EnemyCollision ECollision;


        public Level1(Camera _camera, Texture2D _fish, Texture2D _crab, Texture2D _diver, Texture2D _jellyfish, Texture2D _anker, Texture2D _treasure, Texture2D _lifes, Texture2D _finish, Texture2D _background, SchatkistCollision _SCollision, EnemyCollision _ECollision)
        {
            camera = _camera;
            fish = new Fish( _fish, new KeyBoardReader());
            crab = new Crab(_crab);
            diver = new Diver(_diver);
            anker = new Anker(_anker);
            finish = new FinishLine(_finish);

            jellyfish = new List<Jellyfish>()
            {
                new Jellyfish(_jellyfish)
                {
                    kwalPositie = new Vector2 (2750, 0)
                },
                new Jellyfish(_jellyfish)
                {
                    kwalPositie = new Vector2 (3500, 0)
                },
                new Jellyfish(_jellyfish)
                {
                    kwalPositie = new Vector2 (4250, 0)
                },
                new Jellyfish(_jellyfish)
                {
                    kwalPositie = new Vector2 (5000, 0)
                },
                new Jellyfish(_jellyfish)
                {
                    kwalPositie = new Vector2 (5750, 0)
                }
            };

            treasure = new List<Treasure>();
            for (int i = 0; i < 15; i++)
            {
                treasure.Add(new Treasure(_treasure));
            }

            lifes = new List<Lifes>();
            for (int i = 0; i < fish.levens; i++)
            {
                lifes.Add(new Lifes(_lifes, new Vector2(80, (i * 50) + 50)));
            }


            background = new List<Background>();
            for (int i = 0; i < 10; i++)
            {
                background.Add(new Background(_background)
                {
                    BackgroundPositie = new Vector2(i * _background.Width, 0),
                });
            }

            SCollision = _SCollision;
            ECollision = _ECollision;

        }

        public void Draw(SpriteBatch _spriteBatch)
        {
            _spriteBatch.Begin(SpriteSortMode.FrontToBack, transformMatrix: camera.Volg);

            foreach (var a in background)
                a.Draw(_spriteBatch);

            foreach (var a in treasure)
                a.Draw(_spriteBatch);

            foreach (var a in jellyfish)
                a.Draw(_spriteBatch);

            foreach (var a in lifes)
                a.Draw(_spriteBatch);

            finish.Draw(_spriteBatch);

            fish.Draw(_spriteBatch);

            crab.Draw(_spriteBatch);

            diver.Draw(_spriteBatch);

            anker.Draw(_spriteBatch);

            _spriteBatch.End();            
        }

        public void Update(GameTime gameTime)
        {
            if (fish.positie.X > 6051)
            {
                fish.positie = new Vector2(151, 50);
                diver.diverPositie = new Vector2(5000, 200);
            }

            foreach (var a in background)
                a.Update(gameTime);

            foreach (var a in treasure)
                a.Update(gameTime);

            foreach (var a in jellyfish)
                a.Update(gameTime);

            foreach (var a in lifes)
            {
                a.Update(gameTime);
                a.hartPositie.X = fish.positie.X - 71;
            }

            fish.Update(gameTime);

            crab.Update(gameTime);

            diver.GetFishPositie(fish.positie);

            diver.Update(gameTime);

            finish.Update(gameTime);

            anker.Update(gameTime);

            camera.Volgen(fish);

            SCollision.Collision(treasure, fish);
            for (int i = 0; i < treasure.Count; i++)
            {
                if (treasure[i].remove)
                {
                    treasure.RemoveAt(i);                    
                }
            }

            ECollision.TouchAnkerCheck(anker, fish);
            ECollision.TouchCrabCheck(crab, fish);
            ECollision.TouchDiverCheck(diver, fish);
            ECollision.TouchJellyFishCheck(jellyfish, fish);
            if (fish.death)
            {
                fish.positie = new Vector2(151, 50);
                fish.levens += -1;
                diver.diverPositie = new Vector2(5000, 200);
                lifes.RemoveAt(fish.levens);
                if (fish.levens == 0)
                {
                    Loser = true;
                }
                fish.death = false;
            }

            if (SCollision.punten >= 10 && fish.positie.X > 6050)
            { 
                LevelEnd = true;
            }
        }
    }
}
