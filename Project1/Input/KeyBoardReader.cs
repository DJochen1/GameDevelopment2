using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Project1.Input
{
    public class KeyBoardReader : IInputReader
    {
        public Vector2 ReadInput()
        {
            int a = 0;
            int b = 0;
            var direction = Vector2.Zero;
            direction = new Vector2(a, b);
            KeyboardState state = Keyboard.GetState();
            /*if (state.IsKeyDown(Keys.Left) || state.IsKeyDown(Keys.A))
                a = -1;*/
            // Zodat je niet achteruit kan gaan, is miscchien een beetje valsspelen
            if (state.IsKeyDown(Keys.Right) || state.IsKeyDown(Keys.D))
                a = 1;
            if (state.IsKeyDown(Keys.Down) || state.IsKeyDown(Keys.S))
                b = 1;
            if (state.IsKeyDown(Keys.Up) || state.IsKeyDown(Keys.W))
                b = -1;
            direction = new Vector2(a, b);
            

            return direction;
        }


        
    }
}
