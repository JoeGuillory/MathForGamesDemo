using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Raylib_cs;
using MathLibrary;
namespace MathForGamesDemo
{
    internal class EndScene : Scene
    {

        public override void Start()
        {
            base.Start();


            Actor background = Actor.Instantiate(new Tile(), null);




        }

        public override void Update(double deltaTime)
        {
            base.Update(deltaTime);



            Raylib.DrawText("Congratulations", Raylib.GetScreenWidth() / 8, Raylib.GetScreenHeight() / 2, 80, Color.Black);




        }
    }
}
