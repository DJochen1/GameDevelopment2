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
    class Diver : IGameObject
    {
        private Texture2D diverTexture;
        private Animatie diverAnimatie;
        public Vector2 diverPositie;
        private Vector2 diverSnelheid;
        private Vector2 fishPositie;

        public Diver(Texture2D texture)
        {
            diverTexture = texture;

            diverAnimatie = new Animatie();
            diverAnimatie.AddFrame(new AnimationFrame(new Rectangle(600, 0, 200, 100)));
            diverAnimatie.AddFrame(new AnimationFrame(new Rectangle(400, 0, 200, 100)));
            diverAnimatie.AddFrame(new AnimationFrame(new Rectangle(200, 0, 200, 100)));
            diverAnimatie.AddFrame(new AnimationFrame(new Rectangle(0, 0, 200, 100)));
            diverAnimatie.AddFrame(new AnimationFrame(new Rectangle(600, 100, 200, 100)));
            diverAnimatie.AddFrame(new AnimationFrame(new Rectangle(400, 100, 200, 100)));
            diverAnimatie.AddFrame(new AnimationFrame(new Rectangle(200, 100, 200, 100)));
            diverAnimatie.AddFrame(new AnimationFrame(new Rectangle(0, 100, 200, 100)));
            diverAnimatie.AddFrame(new AnimationFrame(new Rectangle(600, 200, 200, 100)));
            diverAnimatie.AddFrame(new AnimationFrame(new Rectangle(400, 200, 200, 100)));

            diverPositie = new Vector2(6000, 200);


        }

        public Rectangle Rectangle
        {
            get { return new Rectangle((int)diverPositie.X, (int)diverPositie.Y, diverTexture.Width, diverTexture.Height); }
        }

        private void Move(Vector2 richting)
        {
            var direction = Vector2.Add(richting, -diverPositie);
            direction = Vector2.Multiply(direction, 0.1f);

            diverSnelheid += direction;
            diverSnelheid = LimitSnelheid(diverSnelheid, 2);
            diverSnelheid = LimitPositie(diverSnelheid, diverPositie, fishPositie, new Vector2 (1000,0));
            diverPositie += diverSnelheid;
        }

        private Vector2 LimitSnelheid(Vector2 v, float max)
        {
            if (v.Length() > max)
            {
                var ratio = max / v.Length();
                v.X *= ratio;
                v.Y *= ratio;
            }
            return v;
        }

        private Vector2 LimitPositie(Vector2 snelheid, Vector2 positie, Vector2 vis, Vector2 Anker)
        {
            if (positie.X > vis.X && positie.X > Anker.X)
            {
                return snelheid;
            }
            else if (positie.X > vis.X)
            {
                snelheid.X = 0;
                return snelheid;
            }
            else if (positie.X > Anker.X)
            {
                snelheid.X = -1;
                return snelheid;
            }
            else
            {
                snelheid.X = 0;
                snelheid.Y = 0;
                return snelheid;
            }

        }

        public void GetFishPositie(Vector2 positie)
        {
            fishPositie = positie;
        }


        public void Update(GameTime gameTime)
        {

            Move(fishPositie);

            diverAnimatie.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(diverTexture, diverPositie, diverAnimatie.CurrentFrame.SourceRectangle, Color.White, 0, new Vector2(0, 0), 1f, SpriteEffects.None, 0.95f);
        }
    }
}
