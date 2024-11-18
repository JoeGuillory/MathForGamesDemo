using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathLibrary;
using Raylib_cs;

namespace MathForGamesDemo
{
    internal class Spawner : Component
    {
        
        private float _startingTimer;
        private float _levelTimer;
        private bool _ended;
        public  float StartingTimer { get => _startingTimer; }
        public float LevelTimer { get => _levelTimer; }
        public bool Ended { get => _ended; }
        int enemycount;
        Actor _lookat;
        float _timer;
        public Spawner(Actor onwer) : base(onwer)
        {

        }
        public Spawner(Actor onwer, Actor lookat) : base(onwer)
        {
            _lookat = lookat;
        }
        public override void Start()
        {
            base.Start();
            _startingTimer = 10;
            _levelTimer = 10;
            enemycount = 30;
            _timer = _levelTimer - 20;
            
            
          
        }
        public override void Update(double deltaTime)
        {
            base.Update(deltaTime);
          
            if ( Math.Truncate(_startingTimer) != 0)
            {
                _startingTimer -= 1 * (float)deltaTime;
                Raylib.DrawText(Math.Truncate(_startingTimer).ToString(), (int)(Raylib.GetScreenWidth() / 2.5f), (int)(Raylib.GetScreenHeight() * .1f), 50, Color.Black);
            }
            if( Math.Truncate(_startingTimer) == 0)
            {
                if(Math.Truncate(_levelTimer) != 0)
                    _levelTimer -= 1 * (float)deltaTime;

                if( enemycount != 0)
                {
                    Actor enemy = Actor.Instantiate(new EnemyTank(), null, RandomSpawn());
                    enemy.AddComponent<LookAt>(new LookAt(enemy, _lookat));
                    enemycount--;
                }
                if (Math.Truncate(_levelTimer) == _timer)
                {
                    if(_timer != 0)
                    {
                        _timer -= 20;
                        enemycount = 20;
                    }

                    
                }
                
                
                  Raylib.DrawText(Math.Truncate(_levelTimer).ToString(), (int)(Raylib.GetScreenWidth() / 2.5f), (int)(Raylib.GetScreenHeight() * .1f), 50, Color.Black);

            }


        }
        //Gets a radom position
        private Vector2 RandomSpawn()
        {
            //top or bottom of the screen
            // left or right side of the screen
            int randpos = Raylib.GetRandomValue(1, 4);
            Vector2 randomPosition = new Vector2();
            switch (randpos)
            {
                case 1:
                   randomPosition = new Vector2(Raylib.GetRandomValue(0, Raylib.GetScreenWidth()), Raylib.GetRandomValue(-30,-40));
                    break;
                case 2: 
                   randomPosition = new Vector2(Raylib.GetRandomValue(0, Raylib.GetScreenWidth()), Raylib.GetRandomValue(Raylib.GetScreenHeight(), Raylib.GetScreenHeight() + 30));
                    break;
                case 3: 
                   randomPosition = new Vector2(Raylib.GetRandomValue(-30, -40), Raylib.GetRandomValue(0, Raylib.GetScreenHeight()));
                    break;
                case 4:
                   randomPosition = new Vector2(Raylib.GetRandomValue(Raylib.GetScreenWidth(), Raylib.GetScreenWidth() + 30), Raylib.GetRandomValue(0, Raylib.GetScreenHeight()));
                    break;
            }
            return randomPosition;
        }


    }
}
