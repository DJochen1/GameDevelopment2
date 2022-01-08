using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project1.Interface;

namespace Project1.GameParts
{
    public class MenuBackground : IGameObject
    {
        private Texture2D menuBackgroundTexture;
        Rectangle rectangle = new Rectangle(0, 0, Game.screenWidth, Game.screenHeight);
        Color colour = new Color(255, 255, 255, 255);

        public MenuBackground(Texture2D texture)
        {
            menuBackgroundTexture = texture;
        }

        public void Update(GameTime gameTime)
        {
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(menuBackgroundTexture, rectangle, colour);
            spriteBatch.End();
        }
    }
}