using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using Project1.Interface;
using Project1.Animation;
using Project1.Input;
using Project1.Components;

namespace Project1.Collision
{
    public class SchatkistCollision : CollisionManager
    {

        public int punten;


        public void Collision(List<Treasure> schatten, Fish fish)
        {
            foreach (var kist in schatten)
                if (CheckCollision(kist.Rectangle, fish.Rectangle))
                {
                    punten++;
                    kist.remove = true;
                }

        }
    }
}
