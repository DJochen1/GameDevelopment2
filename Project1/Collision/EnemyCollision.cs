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
using Project1.Components.Enemys;

namespace Project1.Collision
{
    public class EnemyCollision : CollisionManager
    {

        public void TouchCrabCheck(crab krab, Fish fish)
        {
            if (CheckCollision(krab.Rectangle, fish.Rectangle))
            {
                fish.death = true;
            }
        }

        public void TouchDiverCheck(Diver diver, Fish fish)
        {
            if (CheckCollision(diver.Rectangle, fish.Rectangle))
            {
                fish.death = true;
            }
        }

        public void TouchJellyFishCheck(List<Jellyfish> jellyfish, Fish fish)
        {
            foreach (var a in jellyfish)
                if (CheckCollision(a.Rectangle, fish.Rectangle))
                {
                    fish.death = true;
                }

        }

        public void TouchAnkerCheck(Anker anker, Fish fish)
        {
            if (CheckCollision(anker.Rectangle, fish.Rectangle))
            {
                fish.death = true;
            }
        }
    }
}
