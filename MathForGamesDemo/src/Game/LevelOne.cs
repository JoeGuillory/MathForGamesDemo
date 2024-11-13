using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Raylib_cs;
using MathLibrary;
namespace MathForGamesDemo
{
    internal class LevelOne : Scene
    {


        public override void Start()
        {
            base.Start();

            Actor background = Actor.Instantiate(new Tile(), null);
            Actor playerTank = Actor.Instantiate(new PlayerTank(), null, new Vector2(Raylib.GetScreenWidth()/2,Raylib.GetScreenHeight()/2));
            Actor followTank = Actor.Instantiate(new FollowTank(), playerTank.Transform);

            Actor enemyTank = Actor.Instantiate(new EnemyTank());
            enemyTank.AddComponent<LookAt>(new LookAt(enemyTank, playerTank));


        }
    }
}
