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
        public float RotateSpeed { get; set; } = 2;

        Texture2D tankBottom = new Texture2D();
        Rectangle tankDestination;
        Rectangle tankImage;
        public float TankScale = 50;
        Vector2 tankCenter;
        Vector2 position = new Vector2();
        

        public override void Start()
        {
            base.Start();
            Transform.LocalPosition = new Vector2(Raylib.GetScreenWidth() / 2,Raylib.GetScreenHeight() / 2);
            tankBottom = Raylib.LoadTexture(@"res\largepng\tankBody_blue.png");
            tankCenter = new Vector2(tankBottom.Width /2, tankBottom.Height/ 2);
            tankImage = new Rectangle(0,0, tankBottom.Width,tankBottom.Height);
           
            position = Transform.GlobalPosition;
        }

        public override void Update(double deltaTime)
        {
            base.Update(deltaTime);
            Vector2 offset = new Vector2((Transform.LocalScale.x * TankScale) / 2, (Transform.LocalScale.y * TankScale) / 2);

            Movement(deltaTime);
            tankDestination = new Rectangle(Transform.GlobalPosition, Transform.GlobalScale * TankScale);
            
            Raylib.DrawLine(Raylib.GetScreenWidth() / 2,0,Raylib.GetScreenWidth() / 2,Raylib.GetScreenHeight(),Color.Black);
            Raylib.DrawLine(0, Raylib.GetScreenHeight() / 2, Raylib.GetScreenWidth(),Raylib.GetScreenHeight() / 2,Color.Black);
            Raylib.DrawText(tankBottom.Width + " | " + tankBottom.Height, 50, 50, 20, Color.Black);
            Raylib.DrawText(position.ToString(), 50, 100, 20, Color.Black);
            Raylib.DrawTexturePro(tankBottom, tankImage, tankDestination,tankCenter, Transform.GlobalRotationAngle * (float)(180/Math.PI) + 90 * RotateSpeed, Color.White);
            Raylib.DrawLineV(Transform.GlobalPosition + offset, Transform.GlobalPosition + offset + (Transform.Forward * 100), Color.Black);
           
        }

        void Movement(double deltaTime)
        {
            float reverse = -1;
            if(Raylib.IsKeyDown(KeyboardKey.W))
                Transform.Translate(Transform.Forward * Speed * (float)deltaTime);
           
            if (Raylib.IsKeyDown(KeyboardKey.S))
                Transform.Translate(Transform.Forward * Speed * (float)deltaTime * reverse);

            if (Raylib.IsKeyDown(KeyboardKey.A))
                Transform.Translate(Transform.Right * (float)deltaTime);
           
            if (Raylib.IsKeyDown(KeyboardKey.D))
                Transform.Translate(Transform.Right * (float)deltaTime * reverse);

        }
    }
}
