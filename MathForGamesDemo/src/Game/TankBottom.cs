using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathLibrary;
using Raylib_cs;
namespace MathForGamesDemo
{
    internal class TankBottom : Actor
    {
        public float Speed { get; set; } = 50;
        public float RotateSpeed { get; set; } = 5;

        Texture2D tankBottom = new Texture2D();

        public override void Start()
        {
            base.Start();
            tankBottom = Raylib.LoadTexture(@"res\largepng\tankBody_blue.png");
            
        }

        public override void Update(double deltaTime)
        {
            base.Update(deltaTime);

            Movement(deltaTime);
            
           

            Raylib.DrawTextureEx(tankBottom, Transform.GlobalPosition + new Vector2(100,100), Transform.GlobalRotationAngle * (float)(180/Math.PI) + 90 , 1, Color.White);
            Raylib.DrawLineV(Transform.GlobalPosition,Transform.Forward * 100 ,Color.Blue);
        }

        void Movement(double deltaTime)
        {
            if(Raylib.IsKeyDown(KeyboardKey.W) || Raylib.IsKeyDown(KeyboardKey.S))
            {
                Transform.Translate(Transform.Right * Speed * (float)deltaTime);
            }
        }
    }
}
