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
            Actor playerTank = Actor.Instantiate(new PlayerTank(),null,new Vector2(50,50));
            Actor followTank = Actor.Instantiate(new FollowTank(), playerTank.Transform);
            //Actor enemyTank = Actor.Instantiate(new EnemyTank());
            //enemyTank.AddComponent<LookAt>(new LookAt(enemyTank, playerTank));
            
            






        }




    }
}
