using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project1.Components;
using Project1.Collision;
using Project1.Levels;
using Project1.GameParts.GameStates;
using Microsoft.Xna.Framework.Input;

namespace Project1
{    
    public class Game : Microsoft.Xna.Framework.Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        //kijken of deze twee ook weg kunnen
        public static int screenWidth = 670;
        public static int screenHeight = 507;

        private GameState currentState;
        private GameState nextState;

        public void ChangeState(GameState state)
        {
            nextState = state;
        }

        public Game()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            _graphics.IsFullScreen = true;

            _graphics.PreferredBackBufferWidth = screenWidth;
            _graphics.PreferredBackBufferHeight = screenHeight;
        }

        //Het kan zonder deze
        /*protected override void Initialize()
        {
            base.Initialize();
        }*/

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            currentState = new MainMenu(Content, _graphics.GraphicsDevice, this);
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == Microsoft.Xna.Framework.Input.ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Microsoft.Xna.Framework.Input.Keys.Escape))
                Exit();

            if (nextState != null)
            {
                currentState = nextState;

                nextState = null;
            }

            currentState.Update(gameTime);           

            base.Update(gameTime);
        }
        
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Blue);

            currentState.Draw(_spriteBatch);
            
            base.Draw(gameTime);
        }
    }
}
