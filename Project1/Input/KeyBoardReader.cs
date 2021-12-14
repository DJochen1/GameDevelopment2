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
            if (state.IsKeyDown(Keys.Left))
                a = -1;
            if (state.IsKeyDown(Keys.Right))
                a = 1;
            if (state.IsKeyDown(Keys.Down))
                b = 1;
            if (state.IsKeyDown(Keys.Up))
                b = -1;
            direction = new Vector2(a, b);
            

            return direction;
        }

        
    }
}
