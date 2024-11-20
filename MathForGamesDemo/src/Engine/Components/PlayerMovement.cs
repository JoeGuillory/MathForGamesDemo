using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Raylib_cs;
using MathLibrary;

namespace MathForGamesDemo
{
    internal class PlayerMovement : Component
    {
        private float _movementspeed;
        private float _rotationspeed;
        public PlayerMovement(Actor owner, float movementspeed,float rotationspeed) : base(owner)
        {
            _movementspeed = movementspeed;
            _rotationspeed = rotationspeed;
        }
        

        

        public override void Update(double deltaTime)
        {
            base.Update(deltaTime);
            // Movement
            float reverse = -1;
            if (Raylib.IsKeyDown(KeyboardKey.W) && !Raylib.IsKeyDown(KeyboardKey.S))
                Owner.Transform.Translate(Owner.Transform.Forward * _movementspeed *(float)deltaTime);

            if (Raylib.IsKeyDown(KeyboardKey.S) && !Raylib.IsKeyDown(KeyboardKey.W))
                Owner.Transform.Translate(Owner.Transform.Forward * _movementspeed * (float)deltaTime * reverse);

            if (Raylib.IsKeyDown(KeyboardKey.D) && !Raylib.IsKeyDown(KeyboardKey.A))
                Owner.Transform.Rotate(_rotationspeed * (float)deltaTime );

            if (Raylib.IsKeyDown(KeyboardKey.A) && !Raylib.IsKeyDown(KeyboardKey.D))
                Owner.Transform.Rotate(_rotationspeed *(float)deltaTime * reverse);

            if (Raylib.IsKeyDown(KeyboardKey.Q) && !Raylib.IsKeyDown(KeyboardKey.E))
                Owner.Transform.LocalScale -= new Vector2(1, 1) * (float)deltaTime;
            if (!Raylib.IsKeyDown(KeyboardKey.Q) && Raylib.IsKeyDown(KeyboardKey.E))
                Owner.Transform.LocalScale += new Vector2(1, 1) * (float)deltaTime;
        }


    }
}
