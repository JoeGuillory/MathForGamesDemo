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
    internal class EnemyShoot : Component
    {
        Vector2 _offset;
        Stopwatch stopWatch = new Stopwatch();
        TimeSpan time;
        public EnemyShoot(Actor owner, Vector2 offset) : base(owner)
        {
            _offset = new Vector2();
            _offset = offset;
            
        }
        public override void Start()
        {
            base.Start();
            stopWatch.Start();


        }

        public override void Update(double deltaTime)
        {
            base.Update(deltaTime);
            time = stopWatch.Elapsed;
            
            if( time.Seconds == 5)
            {
                Actor.Instantiate(new Bullet(2), null, Owner.Transform.LocalPosition + _offset, Owner.Transform.LocalRotationAngle);
                stopWatch.Restart();
            }
        }

        public override void End()
        {
            base.End();

            stopWatch.Stop();
        }
    }
}
