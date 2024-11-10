using Raylib_cs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathLibrary;

namespace MathForGamesDemo
{
    internal class LookAtMouse : Component
    {

        public LookAtMouse(Actor owner)  : base(owner)
        {

        }



        public override void Update(double deltaTime)
        {
            base.Update(deltaTime);

            Vector2 mouse = Owner.Transform.GlobalPosition - (Vector2)Raylib.GetMousePosition();

            Owner.Transform.SetAngle((float)Math.Atan2(-1 * mouse.y, -1 * mouse.x));



        }
    }
}
