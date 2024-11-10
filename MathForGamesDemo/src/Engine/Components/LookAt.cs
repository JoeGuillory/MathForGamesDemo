using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Raylib_cs;
using MathLibrary;

namespace MathForGamesDemo
{ 
    internal class LookAt : Component
    {
        Vector2 _other;
        Actor _otherActor;

        
        public LookAt(Actor owner, Vector2 other) : base(owner)
        {
            _other = other;
            

        }
        public LookAt(Actor owner, Actor other) : base(owner)
        {
            _otherActor = other;
        }

        public override void Update(double deltaTime)
        {
            base.Update(deltaTime);

            if(_otherActor == null)
            {
                Vector2 result = Owner.Transform.GlobalPosition - _other;
                Owner.Transform.SetAngle((float)Math.Atan2(-1 * result.y, -1 * result.x));
            }
            else
            {
                Vector2 result = Owner.Transform.GlobalPosition - _otherActor.Transform.GlobalPosition;
                Owner.Transform.SetAngle((float)Math.Atan2(-1 * result.y, -1 * result.x));
            }

        }



    }
}
