using System;
using System.Collections.Generic;
using System.Text;
using System.CodeDom;
using Microsoft.Xna.Framework;

namespace Project1.Animation
{
    public class AnimationFrame
    {
        public Rectangle SourceRectangle { get; set; }

        public AnimationFrame(Rectangle rectangle)
        {
            SourceRectangle = rectangle;
        }
    }    
}
