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
        int _constructor = 0;
        public PlayerShoot(Actor owner, Vector2 offset) : base(owner)
        {
            _offset = new Vector2();
            _offset = offset;
            _constructor = 1;
        }
        public PlayerShoot(Actor owner, Actor owner2, Vector2 offset) : base(owner)
        {
            _owner2 = owner2;
            _offset = offset;
            _constructor = 2;
        }

        
        public override void Update(double deltaTime)
        {
            base.Update(deltaTime);
            
           if (Raylib.IsMouseButtonPressed(MouseButton.Left))
           {
                switch (_constructor)
                {
                    case 1:
                        Actor.Instantiate(new Bullet(1), null, Owner.Transform.LocalPosition + _offset ,Owner.Transform.LocalRotationAngle);
                        break;
                    case 2:
                        // Get the second owners position and the first owners rotation
                        Actor.Instantiate(new Bullet(1), null, Owner.Transform.GlobalPosition + _offset, _owner2.Transform.LocalRotationAngle);
                        break;
                }
                
            }
            
        }


    }
}
