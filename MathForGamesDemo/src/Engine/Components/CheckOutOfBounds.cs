using Raylib_cs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathForGamesDemo
{
    internal class CheckOutOfBounds : Component
    {
        public CheckOutOfBounds(Actor owner) : base(owner)
        {

        }

        public override void Update(double deltaTime)
        {
            base.Update(deltaTime);



            if (Owner.Transform.GlobalPosition.x > Raylib.GetScreenWidth() || Owner.Transform.GlobalPosition.x < 0)
            {
                Console.WriteLine("Object Destroyed");
                Game.CurretScene.RemoveActor(Owner);

            }
            if (Owner.Transform.GlobalPosition.y > Raylib.GetScreenHeight() || Owner.Transform.GlobalPosition.y < 0)
            {

                Console.WriteLine("Object Destroyed");
                Game.CurretScene.RemoveActor(Owner);
            }
        }
    }
}
