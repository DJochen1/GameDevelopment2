using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Project1.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project1.GameParts
{
    public class Button
    {
        Texture2D texture;
        Vector2 position;
        Rectangle rectangle;

        Color colour = new Color(255, 255, 255, 255);
        //heb deze nodig maar weet nog niet waarom (voor de Draw methode, maar opnieuw weet nog niet waarom)

        public Vector2 size;

        public Button(Texture2D newTexture, GraphicsDevice graphics)
        {
            texture = newTexture;

            size = new Vector2(120, 120);
        }

        public bool isClicked;

        public void Update(MouseState mouse)
        {
            rectangle = new Rectangle((int)position.X, (int)position.Y,
                (int)size.X, (int)size.Y);

            Rectangle mouseRectangle = new Rectangle(mouse.X, mouse.Y, 1, 1);

            if (mouseRectangle.Intersects(rectangle))
            {
                if (mouse.LeftButton == ButtonState.Pressed) isClicked = true;
            }
            else 
            {
                isClicked = false;
            }
        }

        public void SetPosition(Vector2 newPosition)
        {
            position = newPosition;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(texture, rectangle, colour);
            spriteBatch.End();
        }


    }
}


