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

        Actor tankbottom;
        Actor tanktop;
        public override void Start()
        {
            base.Start();
            Actor background = Actor.Instantiate(new Tile(), null);
            Actor tankbottom = Actor.Instantiate(new TankBottom(), null, new Vector2(200,200), 0);
            Actor tanktop = Actor.Instantiate(new TankTop(), tankbottom.Transform, new Vector2(0, 0), 0);
            tanktop.AddComponent<PlayerShoot>(new PlayerShoot(tanktop, tankbottom, new Vector2(TankBottom.TankScale / 2, TankBottom.TankScale / 2)));
          
            
            




        }




    }
}
