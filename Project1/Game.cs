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
using Project1.Levels;
using System.Windows.Forms;
using Button = Project1.Components.Button;

namespace Project1
{
    enum GameState
    {
        MainMenu,
        Level1,
        Level2,
        HighScore,
        Loser,
        VictoryLevel1,
        VictoryLevel2,
        End,
    }  

    public class Game : Microsoft.Xna.Framework.Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        Level1 level1;

        Level2 level2;

        private Camera _camera;

        private Texture2D vis;

        private Texture2D krab;

        private Texture2D duiker;

        private Texture2D kwal;

        private Texture2D ancher;

        private Texture2D schat;

        private Texture2D levens;

        private Texture2D lijn;

        private Texture2D achtergrond;

        private Texture2D menuAchtergrond;
        public MenuBackground menuBackground;

        private Texture2D winnaarLevel1;
        public MenuBackground winnerLevel1;

        private Texture2D winnerAchtergrond;
        public MenuBackground winnerBackground;

        private Texture2D loserAchtergrond;
        public MenuBackground loserBackground;

        private SchatkistCollision SCollision;
        private EnemyCollision ECollision;


        public static int screenWidth = 670;
        public static int screenHeight = 507;

        GameState currentGameState = GameState.MainMenu;
        //zodat we beginnen in main menu

        private Button buttonPlay;
        private Button buttonQuit;
        private Button buttonNext;
        private Button pauseButton;      


        public Game()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            _graphics.IsFullScreen = true;

            _graphics.PreferredBackBufferWidth = screenWidth;
            _graphics.PreferredBackBufferHeight = screenHeight;
        }

        protected override void Initialize()
        {

            _graphics.ApplyChanges();

            SCollision = new SchatkistCollision();
            ECollision = new EnemyCollision();

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            buttonPlay = new Button(Content.Load<Texture2D>("button"), _graphics.GraphicsDevice);
            buttonPlay.SetPosition(new Vector2(screenWidth/2-60, screenHeight/2-100));

            buttonNext = new Button(Content.Load<Texture2D>("NextLevel"), _graphics.GraphicsDevice);
            buttonNext.SetPosition(new Vector2(150, 200));

            buttonQuit = new Button(Content.Load<Texture2D>("Quit"), _graphics.GraphicsDevice);
            buttonQuit.SetPosition(new Vector2(screenWidth / 2-60, screenHeight / 2 + 66));

            pauseButton = new Button(Content.Load<Texture2D>("Pause"), _graphics.GraphicsDevice);
            pauseButton.SetPosition(new Vector2(screenWidth-300 , screenHeight/2 -500));

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

            Texture2D _levens = Content.Load<Texture2D>("hart2");
            levens = _levens;

            Texture2D _ancher = Content.Load<Texture2D>("anker");
            ancher = _ancher;

            Texture2D _lijn = Content.Load<Texture2D>("finishline");
            lijn = _lijn;

            Texture2D _achtergrond = Content.Load<Texture2D>("oceaan");
            achtergrond = _achtergrond;

            Texture2D _menuAchtergrond = Content.Load<Texture2D>("MainMenu");
            menuAchtergrond = _menuAchtergrond;

            Texture2D _winnaarlevel1 = Content.Load<Texture2D>("Level1Cleared");
            winnaarLevel1 = _winnaarlevel1;

            Texture2D _winnerAchtergrond = Content.Load<Texture2D>("Level2Cleared");
            winnerAchtergrond = _winnerAchtergrond;

            Texture2D _loserAchtergrond = Content.Load<Texture2D>("loser");
            loserAchtergrond = _loserAchtergrond;  

            InitializeGameObjects();
        }

        private void InitializeGameObjects()
        {
            menuBackground = new MenuBackground(menuAchtergrond);

            winnerLevel1 = new MenuBackground(winnaarLevel1);

            winnerBackground = new MenuBackground(winnerAchtergrond);

            loserBackground = new MenuBackground(loserAchtergrond);

            level1 = new Level1(_camera, vis, krab, duiker, kwal, ancher, schat, levens, lijn, achtergrond, SCollision, ECollision);
            level2 = new Level2(_camera, vis, krab, duiker, kwal, ancher, schat, levens, lijn, achtergrond, SCollision, ECollision);

        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == Microsoft.Xna.Framework.Input.ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Microsoft.Xna.Framework.Input.Keys.Escape))
                Exit();

            MouseState mouse = Mouse.GetState();

            switch (currentGameState)
            {
                case GameState.MainMenu:
                    IsMouseVisible = true;
                    if (buttonPlay.isClicked)
                    {
                        currentGameState = GameState.Level1;
                    }
                    buttonPlay.Update(mouse);

                    if (buttonQuit.isClicked)
                    {
                        Exit();
                    }
                    buttonQuit.Update(mouse);
                    
                    break;
                case GameState.Level1:

                    IsMouseVisible = false;
                    level1.Update(gameTime);

                    if (level1.Loser == true)
                        currentGameState = GameState.Loser;

                    if (level1.LevelEnd == true)
                        currentGameState = GameState.VictoryLevel1;

                    break;
                case GameState.Level2:

                    IsMouseVisible = false;
                    level2.Update(gameTime);

                    if (level2.Loser == true)
                        currentGameState = GameState.Loser;

                    if (level2.LevelEnd == true)
                        currentGameState = GameState.VictoryLevel2;


                    break;
                case GameState.VictoryLevel1:
                    IsMouseVisible = true;
                    if (buttonNext.isClicked)
                    {
                        currentGameState = GameState.Level2;
                    }
                    buttonNext.Update(mouse);

                    if (buttonQuit.isClicked)
                    {
                        Exit();
                    }
                    buttonQuit.Update(mouse);

                    break;
                case GameState.VictoryLevel2:
                    if (Keyboard.GetState().IsKeyDown(Microsoft.Xna.Framework.Input.Keys.Enter))
                    {
                        currentGameState = GameState.End;
                    }
                    break;
                case GameState.Loser:
                    if (Keyboard.GetState().IsKeyDown(Microsoft.Xna.Framework.Input.Keys.Enter))
                    {
                        currentGameState = GameState.End;
                    }
                    break;
                case GameState.HighScore:
                    break;
                case GameState.End:
                    Exit();
                    break;
                default:
                    break;
            } 

            base.Update(gameTime);
        }
        
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Blue);

            switch (currentGameState)
            {
                case GameState.MainMenu:
                    menuBackground.Draw(_spriteBatch);
                    buttonPlay.Draw(_spriteBatch);                    
                    buttonQuit.Draw(_spriteBatch);                    
                    break;
                case GameState.Level1:
                    _spriteBatch.Begin(SpriteSortMode.FrontToBack, transformMatrix: _camera.Volg);

                    level1.Draw(_spriteBatch);

                    _spriteBatch.End();      

                    break;
                case GameState.Level2:
                    _spriteBatch.Begin(SpriteSortMode.FrontToBack, transformMatrix: _camera.Volg);

                    level2.Draw(_spriteBatch);

                    _spriteBatch.End();
                    break;
                case GameState.VictoryLevel1:
                    winnerLevel1.Draw(_spriteBatch);
                    buttonNext.Draw(_spriteBatch);
                    buttonQuit.Draw(_spriteBatch);
                    buttonQuit.SetPosition(new Vector2(400, 200));
                    break;
                case GameState.VictoryLevel2:
                    winnerBackground.Draw(_spriteBatch);
                    break;
                case GameState.Loser:
                    loserBackground.Draw(_spriteBatch);
                    break;
                case GameState.HighScore:
                    break;
            }            
            base.Draw(gameTime);
        }
    }
}
