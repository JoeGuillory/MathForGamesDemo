using Raylib_cs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathForGamesDemo
{
    internal class DeathScene : Scene
    {
        public override void Start()
        {
            base.Start();

            Actor background = Actor.Instantiate(new Tile(), null);
        }
        public override void Update(double deltaTime)
        {
            base.Update(deltaTime);



            Raylib.DrawText("You Died", Raylib.GetScreenWidth() / 8, Raylib.GetScreenHeight() / 2, 80, Color.Black);
        }
    }
}
