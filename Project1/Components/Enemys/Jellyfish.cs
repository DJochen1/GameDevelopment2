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
    public class Jellyfish : IGameObject
    {
        private Texture2D kwalTexture;
        private Animatie kwalAnimatie;
        public Vector2 kwalPositie { get; set; }
        private Vector2 crabSnelheid;

        public Jellyfish(Texture2D texture)
        {
            kwalTexture = texture;

            kwalAnimatie = new Animatie();
            kwalAnimatie.AddFrame(new AnimationFrame(new Rectangle(0, 0, 100, 139)));
            kwalAnimatie.AddFrame(new AnimationFrame(new Rectangle(100, 0, 100, 139)));
            kwalAnimatie.AddFrame(new AnimationFrame(new Rectangle(200, 0, 100, 139)));
            kwalAnimatie.AddFrame(new AnimationFrame(new Rectangle(300, 0, 100, 139)));
            kwalAnimatie.AddFrame(new AnimationFrame(new Rectangle(400, 0, 100, 139))); 
            kwalAnimatie.AddFrame(new AnimationFrame(new Rectangle(500, 0, 100, 139)));
            kwalAnimatie.AddFrame(new AnimationFrame(new Rectangle(600, 0, 100, 139)));
            kwalAnimatie.AddFrame(new AnimationFrame(new Rectangle(500, 0, 100, 139)));
            kwalAnimatie.AddFrame(new AnimationFrame(new Rectangle(400, 0, 100, 139)));
            kwalAnimatie.AddFrame(new AnimationFrame(new Rectangle(300, 0, 100, 139)));
            kwalAnimatie.AddFrame(new AnimationFrame(new Rectangle(200, 0, 100, 139)));
            kwalAnimatie.AddFrame(new AnimationFrame(new Rectangle(100, 0, 100, 139)));
            kwalAnimatie.AddFrame(new AnimationFrame(new Rectangle(0, 0, 100, 139)));

            kwalPositie = new Vector2(3000, 0);


        }

        public Rectangle Rectangle
        {
            get { return new Rectangle((int)kwalPositie.X, (int)kwalPositie.Y, 80, 100); }
        }

        private void Move()
        {
            crabSnelheid.X = 0;
            if (kwalPositie.Y < 1)
                crabSnelheid.Y = 1.5f;
            if (kwalPositie.Y > 300)
                crabSnelheid.Y = -1.5f;
            kwalPositie += crabSnelheid;
        }


        public void Update(GameTime gameTime)
        {

            Move();

            kwalAnimatie.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(kwalTexture, kwalPositie, kwalAnimatie.CurrentFrame.SourceRectangle, Color.White, 0, new Vector2(0, 0), 1f, SpriteEffects.None, 0.9f);
        }
    }
}
