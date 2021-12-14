using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using Project1.Interface;
using Project1.Animation;
using Project1.Input;


namespace Project1.Components.Enemys
{
    class crab : IGameObject
    {
        private Texture2D crabTexture;
        private Animatie crabAnimatie;
        public Vector2 crabPositie;
        private Vector2 crabSnelheid;

        public crab(Texture2D texture)
        {
            crabTexture = texture;

            crabAnimatie = new Animatie();
            crabAnimatie.AddFrame(new AnimationFrame(new Rectangle(0, 0, 133, 128)));
            crabAnimatie.AddFrame(new AnimationFrame(new Rectangle(133, 0, 133, 128)));
            crabAnimatie.AddFrame(new AnimationFrame(new Rectangle(266, 0, 133, 128)));
            crabAnimatie.AddFrame(new AnimationFrame(new Rectangle(399, 0, 133, 128)));
            crabAnimatie.AddFrame(new AnimationFrame(new Rectangle(532, 0, 133, 128)));
            crabAnimatie.AddFrame(new AnimationFrame(new Rectangle(665, 0, 133, 128)));
            crabAnimatie.AddFrame(new AnimationFrame(new Rectangle(0, 260, 133, 128)));
            crabAnimatie.AddFrame(new AnimationFrame(new Rectangle(133, 260, 133, 128)));
            crabAnimatie.AddFrame(new AnimationFrame(new Rectangle(266, 260, 133, 128)));
            crabAnimatie.AddFrame(new AnimationFrame(new Rectangle(399, 260, 133, 128)));
            crabAnimatie.AddFrame(new AnimationFrame(new Rectangle(532, 260, 133, 128)));
            crabAnimatie.AddFrame(new AnimationFrame(new Rectangle(665, 260, 133, 128)));

            crabPositie = new Vector2(699, 350);


        }

        public Rectangle Rectangle
        {
            get { return new Rectangle((int)crabPositie.X, (int)crabPositie.Y, crabTexture.Width, crabTexture.Height); }
        }

        private void Move()
        {
            crabSnelheid.Y = 0;
            if (crabPositie.X < 700)
                crabSnelheid.X = 1;
            if (crabPositie.X > 1100)
                crabSnelheid.X = -1;
            crabPositie += crabSnelheid;
        }
        

        public void Update(GameTime gameTime)
        {

            Move();

            crabAnimatie.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(crabTexture, crabPositie, crabAnimatie.CurrentFrame.SourceRectangle, Color.White, 0, new Vector2(0, 0), 1f, SpriteEffects.None, 0.9f);
        }
    }
}
