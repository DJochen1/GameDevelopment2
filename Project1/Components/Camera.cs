using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Project1.Components
{
    public class Camera
    {
        public Matrix Volg { get; private set; }

        public void Volgen(Fish vis)
        {
            var positie = Matrix.CreateTranslation(-vis.positie.X - (vis.Rectangle.Width * 3.1f)+50, -350, 0);

            var verandering = Matrix.CreateTranslation(/*Game.Hoogte*/ Game.screenHeight/ 2,/*Game.Breedte */ Game.screenWidth/ 2, 0);

            Volg = positie * verandering;
        }
    }
}
