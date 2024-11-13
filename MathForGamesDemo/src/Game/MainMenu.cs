using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Raylib_cs;
using MathLibrary;

namespace MathForGamesDemo
{ 
    internal class MainMenu : Scene
    {


        public override void Start()
        {
            base.Start();

        }
        public override void Update(double deltaTime)
        {
            base.Update(deltaTime);


            Raylib.DrawText("Tankage", (int)(Raylib.GetScreenWidth() / 2.7), Raylib.GetScreenHeight() / 7, 50, Color.Black);

        }

    }
}
