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
using Button = Project1.Components.Button;

namespace Project1
{
    enum GameState
    {
        MainMenu,
        Level1,
        HighScore,
        PauseMenu,
        Loser,
        Victory,
        End,
    }  

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

        private Texture2D menuAchtergrond;
        public MenuBackground menuBackground;

        private Texture2D winnerAchtergrond;
        public MenuBackground winnerBackground;

        private Texture2D loserAchtergrond;
        public MenuBackground loserBackground;

        private SchatkistCollision SCollision;
        private EnemyCollision ECollision;

        //public static int Hoogte;
        //public static int Breedte;

        //public static int screenWidth = SystemInformation.VirtualScreen.Width;
        //public static int screenHeight = SystemInformation.VirtualScreen.Height;

        //public static int screenWidth = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width;
        //public static int screenHeight = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height;

        public static int screenWidth = 670;
        public static int screenHeight = 507;

        GameState currentGameState = GameState.MainMenu;
        //zodat we beginnen in main menu

        private Button buttonPlay;
        private Button buttonQuit;
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
            // TODO: Add your initialization logic here

            //Hoogte = _graphics.PreferredBackBufferWidth;
            //Breedte = _graphics.PreferredBackBufferWidth;

            _graphics.ApplyChanges();

            SCollision = new SchatkistCollision();
            ECollision = new EnemyCollision();

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            buttonPlay = new Button(Content.Load<Texture2D>("button"), _graphics.GraphicsDevice);
            buttonPlay.SetPosition(new Vector2(screenWidth/2-50, screenHeight/2-100));

            buttonQuit = new Button(Content.Load<Texture2D>("Quit"), _graphics.GraphicsDevice);
            buttonQuit.SetPosition(new Vector2(screenWidth / 2-50, screenHeight / 2 + 66));
            // -150 omdat ik de button op  300x300 heb gezet en om die in het midden te krijgen moet je daar de helft van af nemen
            //om een of andere reden als je (bij height) +200 doet gaat ie naar beneden, maar als je -200 doet gaat ie naar boven
            // bij width werkt + en - wel zoals je zou verwachten

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

            Texture2D _ancher = Content.Load<Texture2D>("anker");
            ancher = _ancher;

            Texture2D _lijn = Content.Load<Texture2D>("finishline");
            lijn = _lijn;

            Texture2D _achtergrond = Content.Load<Texture2D>("oceaan");
            achtergrond = _achtergrond;

            Texture2D _menuAchtergrond = Content.Load<Texture2D>("MainMenu");
            menuAchtergrond = _menuAchtergrond;

            Texture2D _winnerAchtergrond = Content.Load<Texture2D>("LevelCleared");
            winnerAchtergrond = _winnerAchtergrond;

            Texture2D _loserAchtergrond = Content.Load<Texture2D>("loser");
            loserAchtergrond = _loserAchtergrond;  

            InitializeGameObjects();
        }

        //moet deze niet protected zijn zoals de rest?
        private void InitializeGameObjects()
        {
            menuBackground = new MenuBackground(menuAchtergrond);

            winnerBackground = new MenuBackground(winnerAchtergrond);

            loserBackground = new MenuBackground(loserAchtergrond);

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
                    BackgroundPositie = new Vector2(i * achtergrond.Width, 0),
                });
            }
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

                    //TODO ACTUALLY PAUSE THE GAME
                    //dus je moet shift in blijven houden ook om in het pauze menu te komen
                    if (Keyboard.GetState().IsKeyDown(Microsoft.Xna.Framework.Input.Keys.LeftShift) || Keyboard.GetState().IsKeyDown(Microsoft.Xna.Framework.Input.Keys.RightShift))
                    {
                        IsMouseVisible = true;
                        //Zodat de muis niet visible is tijdens het spelen, alleen wanneer de shift key wordt ingedrukt

                        if (pauseButton.isClicked && (Keyboard.GetState().IsKeyDown(Microsoft.Xna.Framework.Input.Keys.LeftShift) 
                            || Keyboard.GetState().IsKeyDown(Microsoft.Xna.Framework.Input.Keys.RightShift)))
                        {
                            currentGameState = GameState.PauseMenu;
                        }
                        pauseButton.Update(mouse);
                    }
                    else IsMouseVisible = false;   
                    
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
                    break;
                case GameState.PauseMenu:
                    if (buttonQuit.isClicked)
                    {
                        //currentGameState = GameState.End;
                        currentGameState = GameState.Loser; //for testing purposes
                    }
                    buttonQuit.Update(mouse);
                    break;
                case GameState.Victory:
                    if (Keyboard.GetState().IsKeyDown(Microsoft.Xna.Framework.Input.Keys.Enter))
                    {
                        currentGameState = GameState.End;
                    }
                    break;
                case GameState.Loser:
                    //again, for testing purposes, maar om eruit te komen moet je op enter drukken (of esc)
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
                    
                    pauseButton.Draw(_spriteBatch);
                    break;
                case GameState.PauseMenu:
                    menuBackground.Draw(_spriteBatch);
                    buttonQuit.SetPosition(new Vector2(screenWidth / 2 -150, screenHeight / 2-150 ));
                    buttonQuit.Draw(_spriteBatch);
                    break;
                case GameState.Victory:
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
