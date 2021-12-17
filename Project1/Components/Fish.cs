using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using Project1.Interface;
using Project1.Animation;
using Project1.Input;

namespace Project1.Components
{
    public class Fish : IGameObject
    {
        private Texture2D fishTexture;
        private Animatie animatie;
        public Vector2 positie;
        public bool death = false;
        //private Vector2 snelheid;
        //private Vector2 versnelling;
        //private Vector2 mouseVector;
        IInputReader inputReader;
        public Fish(Texture2D texture, IInputReader reader)
        {
            fishTexture = texture;
            animatie = new Animatie();
            animatie.AddFrame(new AnimationFrame(new Rectangle(0, 0, 125, 82)));
            animatie.AddFrame(new AnimationFrame(new Rectangle(125, 0, 125, 82)));
            animatie.AddFrame(new AnimationFrame(new Rectangle(249, 0, 125, 82)));
            animatie.AddFrame(new AnimationFrame(new Rectangle(375, 0, 125, 82)));
            

            positie = new Vector2(151, 50);
            //snelheid = new Vector2(1, 1);
            //versnelling = new Vector2(0.1f, 0.1f);
            
            //input inlezen
            this.inputReader = reader;


        }

        public Rectangle Rectangle
        {
            get { return new Rectangle((int)positie.X, (int)positie.Y, 80, 60); }
        }

        public void Update(GameTime gameTime)
        {
            var direction = inputReader.ReadInput();
            direction *= 4;
            //positie += direction;
            positie = MaxPositie(positie, 150, 6060, 0, 380, direction);
            
            
            //Move(GetMouseState());
            animatie.Update(gameTime);   
        }

        /* deze code dient ervoor om de vis met de muis te laten bewegen. deze gebruik ik niet
        private Vector2 GetMouseState()
        {
            MouseState state = Mouse.GetState();
            mouseVector = new Vector2(state.X, state.Y);
            return mouseVector;
        }
        
        private void Move(Vector2 mouse)
        {
            var direction = Vector2.Add(mouse, -positie);
            direction.Normalize();
            direction = Vector2.Multiply(direction, 0.5f);

            snelheid += direction;
            snelheid = Limit(snelheid, 5);
            positie += snelheid;

            if (positie.X > 600 || positie.X < 0)
            {
                snelheid.X *= -1;
                versnelling.X *= -1;
            }
            if (positie.Y > 400 || positie.X < 0)
            {
                snelheid.Y *= -1;
                versnelling.Y *= -1;
                
            }
        }

        private Vector2 Limit(Vector2 v, float max)
        {
            if (v.Length() > max)
            {
                var ratio = max / v.Length();
                v.X *= ratio;
                v.Y *= ratio;
            }
            return v;
        }
        */


        // onderstaande methode zorgt ervoor dat de vis niet verder gaat dan maximaal opgegeven
        // de vis kan wel nog naar de juiste richting bewegen
        // de vis moet in een virtuele box blijven
        private Vector2 MaxPositie(Vector2 v, int minX, int maxX, int minY, int maxY, Vector2 richting)
        {
            if (v.X > minX && v.X < maxX && v.Y > minY && v.Y < maxY)
                return v + richting;
            else if (v.X < maxX && v.Y > minY && v.Y < maxY && richting.X < -1)
                richting.X = 0;
            else if (v.X > minX && v.Y > minY && v.Y < maxY && richting.X > 1)
                richting.X = 0;
            else if (v.X > minX && v.X < maxX && v.Y > minY && richting.Y > 1)
                richting.Y = 0;
            else if (v.X > minX && v.X < maxX && v.Y < maxY && richting.Y < -1)
                richting.Y = 0;
            return v + richting;
        }


        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(fishTexture, positie, animatie.CurrentFrame.SourceRectangle, Color.White , 0, new Vector2(0, 0), 1f, SpriteEffects.None, 1f);
            
        }
    }
}
