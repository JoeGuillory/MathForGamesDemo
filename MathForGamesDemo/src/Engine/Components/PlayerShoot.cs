using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Raylib_cs;
using MathLibrary;

namespace MathForGamesDemo
{
    internal class PlayerShoot : Component
    {
        Vector2 _offset;
        Actor _owner2;
        public PlayerShoot(Actor owner, Vector2 offset) : base(owner)
        {
            _offset = new Vector2();
            _offset = offset;
        }
        public PlayerShoot(Actor owner, Actor owner2, Vector2 offset) : base(owner)
        {
            _owner2 = owner2;
            _offset = offset;
        }

        
        public override void Update(double deltaTime)
        {
            base.Update(deltaTime);
            
           if (Raylib.IsMouseButtonPressed(MouseButton.Left))
           {
                if(_owner2 == null)
                  Actor.Instantiate(new Bullet(), null, Owner.Transform.LocalPosition + _offset ,Owner.Transform.LocalRotationAngle);
                else
                    // Get the second owners position and the first owners rotation
                    Actor.Instantiate(new Bullet(), null, _owner2.Transform.GlobalPosition + _offset, Owner.Transform.LocalRotationAngle);
            }
            
        }


    }
}
