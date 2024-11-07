using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Raylib_cs;
using MathLibrary;

namespace MathForGamesDemo
{
    internal class Shoot : Component
    {
        private Vector2 _offest;
        public Shoot(Actor owner) : base(owner)
        {

        }

        public override void Start()
        {


        }

        public override void Update(double deltaTime)
        {
            base.Update(deltaTime);
            
           if (Raylib.IsMouseButtonPressed(MouseButton.Left))
           {
                Actor.Instantiate(new Bullet(), null, Owner.Transform.LocalPosition,Owner.Transform.LocalRotationAngle);
                
           }
            
        }


    }
}
