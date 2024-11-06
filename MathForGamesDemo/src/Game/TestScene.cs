using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using MathLibrary;
using Raylib_cs;

namespace MathForGamesDemo
{
    internal class TestScene : Scene
    {
       

        public override void Start()
        {
            base.Start();
           

            Actor tankbottom = Actor.Instantiate(new TankBottom(), null, new Vector2(25/2, 25/2), 0, "Tank");
            Actor tanktop = Actor.Instantiate(new TankTop(), tankbottom.Transform, new Vector2(0,0),0, "Tank");
            

        }



    }
}
