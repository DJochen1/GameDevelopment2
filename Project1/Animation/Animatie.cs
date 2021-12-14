using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;

namespace Project1.Animation
{
    public class Animatie
    {
        public AnimationFrame CurrentFrame { get; set; }

        private List<AnimationFrame> frames;

        private int counter;
        private double frameMovement = 0;

        public Animatie()
        {
            frames = new List<AnimationFrame>();
        }

        public void AddFrame(AnimationFrame animationFrame)
        {
            frames.Add(animationFrame);
            CurrentFrame = frames[0];
        }

        public void Update(GameTime gameTime)
        {
            CurrentFrame = frames[counter];

            frameMovement += CurrentFrame.SourceRectangle.Width*gameTime.ElapsedGameTime.TotalSeconds;
            if (frameMovement >= CurrentFrame.SourceRectangle.Width/6)
	        {
            counter++;
            frameMovement =0;
	        }


            if (counter >= frames.Count)
            {
                counter = 0;
            }
        }
    }
}
