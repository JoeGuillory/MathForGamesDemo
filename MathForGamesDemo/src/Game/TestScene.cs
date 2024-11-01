using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathLibrary;

namespace MathForGamesDemo
{
    internal class TestScene : Scene
    {
        public override void Start()
        {
            Actor tanktop;
            base.Start();

            Actor tankbottom = Actor.Instantiate(new TankBottom(), null,new Vector2(20,20),0, "tankTop");
            tanktop = Actor.Instantiate(new TankTop(),tankbottom.Transform, new Vector2(10,10), 0, "tankbottom");
           
        }

    }
}
