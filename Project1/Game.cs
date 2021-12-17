﻿using Microsoft.Xna.Framework;
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

namespace Project1
{
    public class Game : Microsoft.Xna.Framework.Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        private Camera _camera;

        private Texture2D vis;

        private Fish fish;

        private Texture2D krab;

        crab Crab;

        private Texture2D duiker;

        Diver diver;

        private Texture2D kwal;

        private List<Jellyfish> jellyfish;

        private Texture2D ancher;

        Anker anker;

        private Texture2D schat;

        private List<Treasure> treasure;

        private Texture2D lijn;

        FinishLine Finish;

        private Texture2D achtergrond;

        private List<Background> background;

        private SchatkistCollision SCollision;
        private EnemyCollision ECollision;

        public static int Hoogte;

        public static int Breedte;

        


        public Game()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            _graphics.IsFullScreen = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            Hoogte = _graphics.PreferredBackBufferWidth;
            Breedte = _graphics.PreferredBackBufferWidth;

            SCollision = new SchatkistCollision();
            ECollision = new EnemyCollision();

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            _camera = new Camera();

            Texture2D _vis = Content.Load<Texture2D>("spritesheet_fish");
            vis = _vis;

            Texture2D _krab = Content.Load<Texture2D>("krab");
            krab = _krab;

            Texture2D _duiker = Content.Load<Texture2D>("diver3");
            duiker = _duiker;

            Texture2D _kwal = Content.Load<Texture2D>("kwal");
            kwal = _kwal;

            Texture2D _schat = Content.Load<Texture2D>("treasure2");
            schat = _schat;

            Texture2D _ancher = Content.Load<Texture2D>("anker");
            ancher = _ancher;

            Texture2D _lijn = Content.Load<Texture2D>("finishline");
            lijn = _lijn;

            Texture2D _achtergrond = Content.Load<Texture2D>("oceaan");
            achtergrond = _achtergrond;

            


            InitializeGameObjects();
        }

        private void InitializeGameObjects()
        {
            Finish = new FinishLine(lijn);

            fish = new Fish(vis, new KeyBoardReader());

            Crab = new crab(krab);

            diver = new Diver(duiker);

            jellyfish = new List<Jellyfish>()
            {
                new Jellyfish(kwal)
                {
                    kwalPositie = new Vector2 (2750, 0)
                },
                new Jellyfish(kwal)
                {
                    kwalPositie = new Vector2 (3500, 0)
                },
                new Jellyfish(kwal)
                {
                    kwalPositie = new Vector2 (4250, 0)
                },
                new Jellyfish(kwal)
                {
                    kwalPositie = new Vector2 (5000, 0)
                },
                new Jellyfish(kwal)
                {
                    kwalPositie = new Vector2 (5750, 0)
                }

            };
            
            

            anker = new Anker(ancher);

            treasure = new List<Treasure>();
            for (int i = 0; i < 12; i++)
            {
                treasure.Add(new Treasure(schat));             
            }

            background = new List<Background>();

            for (int i = 0; i < 10; i++)
            {
                background.Add(new Background(achtergrond)
                {
                    BackgroundPositie = new Vector2(i * achtergrond.Width - Math.Min(i, i + 1), 0),
                });
            }
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            foreach (var a in background)
                a.Update(gameTime);

            foreach (var a in treasure)
                a.Update(gameTime);

            foreach (var a in jellyfish)
                a.Update(gameTime);

            fish.Update(gameTime);

            Crab.Update(gameTime);

            diver.GetFishPositie(fish.positie);

            diver.Update(gameTime);

            Finish.Update(gameTime);

            anker.Update(gameTime);

            _camera.Volgen(fish);

            SCollision.Collision(treasure, fish);
            for (int i = 0; i < treasure.Count; i++)
            {
                if (treasure[i].remove)
                {
                    treasure.RemoveAt(i);
                    i--;
                }
            }

            ECollision.TouchAnkerCheck(anker, fish);
            ECollision.TouchCrabCheck(Crab, fish);
            ECollision.TouchDiverCheck(diver, fish);
            ECollision.TouchJellyFishCheck(jellyfish, fish);
            if (fish.death)
                fish.positie = new Vector2(151, 50); //als de vis dood is gaat hij terug naar de startpositie. Dit kan nog aangepast worden
                fish.death = false;

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Blue);


            _spriteBatch.Begin(SpriteSortMode.FrontToBack, transformMatrix: _camera.Volg);

            foreach (var a in background)
                a.Draw(_spriteBatch);

            foreach (var a in treasure)
                a.Draw(_spriteBatch);

            foreach (var a in jellyfish)
                a.Draw(_spriteBatch);

            Finish.Draw(_spriteBatch);

            fish.Draw(_spriteBatch);

            Crab.Draw(_spriteBatch);

            diver.Draw(_spriteBatch);

            anker.Draw(_spriteBatch);

            Finish.Draw(_spriteBatch);

            _spriteBatch.End();
            
            base.Draw(gameTime);
        }
    }
}
