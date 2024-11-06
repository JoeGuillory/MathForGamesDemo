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

        public static float TankScale = 25;
        
        Texture2D tankBottom = new Texture2D();
        Rectangle tankDestination;
        Rectangle tankImage;
        Vector2 tankCenter;
        //Center of the tank
        Vector2 offset;
        


        
        

        public override void Start()
        {
            base.Start();
            
            offset = new Vector2((Transform.LocalScale.x * TankScale) / 2, (Transform.LocalScale.y * TankScale) / 2);
            tankBottom = Raylib.LoadTexture(@"res\largepng\tankBody_blue.png");
            tankCenter = new Vector2(Transform.GlobalScale.x * TankScale / 2,Transform.GlobalScale.y * TankScale / 2);
            tankImage = new Rectangle(0,0, tankBottom.Width,tankBottom.Height);
            

        }

        public override void Update(double deltaTime)
        {
            base.Update(deltaTime);
            
            
            
            Movement(deltaTime);
            tankDestination = new Rectangle(Transform.GlobalPosition + offset, Transform.GlobalScale * TankScale);
            //Draw Tank
            
           
            Raylib.DrawTexturePro(tankBottom, tankImage, tankDestination,tankCenter, -1 * (float)((Transform.GlobalRotationAngle / Math.PI) * 180) + 135  * RotateSpeed, Color.White);
            //Raylib.DrawLineV(Transform.GlobalPosition + offset, Transform.GlobalPosition + offset + (Transform.Forward * 100), Color.Black);
           
        }
        /// <summary>
        /// Contains the movement functions
        /// </summary>
        /// <param name="deltaTime"></param>
        void Movement(double deltaTime)
        {
            float reverse = -1;
            if(Raylib.IsKeyDown(KeyboardKey.W) && !Raylib.IsKeyDown(KeyboardKey.S))
                Transform.Translate(Transform.Forward * Speed * (float)deltaTime);
           
            if (Raylib.IsKeyDown(KeyboardKey.S) && !Raylib.IsKeyDown(KeyboardKey.W))
                Transform.Translate(Transform.Forward * Speed * (float)deltaTime * reverse);

            if (Raylib.IsKeyDown(KeyboardKey.A) && !Raylib.IsKeyDown(KeyboardKey.D))
                Transform.Rotate(RotateSpeed * (float)deltaTime * reverse);
           
            if (Raylib.IsKeyDown(KeyboardKey.D) && !Raylib.IsKeyDown(KeyboardKey.A))
                Transform.Rotate(RotateSpeed * (float)deltaTime);

        }

        
    }
}
