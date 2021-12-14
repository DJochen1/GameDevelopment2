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
            var positie = Matrix.CreateTranslation(-vis.positie.X - (vis.Rectangle.Width / 2), -400, 0);

            var verandering = Matrix.CreateTranslation(Game.Hoogte / 2,Game.Breedte / 2, 0);

            Volg = positie * verandering;
        }
    }
}
