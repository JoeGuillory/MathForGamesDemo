using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathLibrary;
using Raylib_cs;

namespace MathForGamesDemo
{
    internal class TankTop : Actor
    {
        public float TankTopScale { get; set; } = 15;
        Texture2D tankTop;
        Rectangle tankTopDestination;
        Rectangle tankTopImage;
        Vector2 tankTopOrigin;
        Vector2 offset;
        Vector2 tankBottomOffset;
        
        public override void Start()
        {
            base.Start();
           
            
            tankTop = Raylib.LoadTexture(@"res\largepng\tankBlue_barrel2_outline.png");
            tankTopImage = new Rectangle(0,0, tankTop.Width, tankTop.Height);
            tankTopOrigin = new Vector2(Transform.GlobalScale.x * 10 / 2 , 0);
            tankBottomOffset = new Vector2(TankBottom.TankScale / 2, TankBottom.TankScale / 2);



           
        }

        public override void Update(double deltaTime)
        {
            base.Update(deltaTime);
           
            tankTopDestination = new Rectangle(Transform.GlobalPosition + tankBottomOffset, Transform.GlobalScale.x * 10 , Transform.GlobalScale.y * 20);


            Movement(deltaTime);


            Raylib.DrawTexturePro(tankTop, tankTopImage, tankTopDestination , tankTopOrigin,(float)(Transform.LocalRotationAngle /Math.PI) * 180 - 90, Color.White);
            //Raylib.DrawLineV(Transform.GlobalPosition + offset + tankBottomOffset, Transform.GlobalPosition + (Transform.Forward * 100), Color.Black);

        }

        private void Movement(double deltaTime)
        {
          Vector2 mouse = Transform.GlobalPosition - new Vector2(Raylib.GetMouseX(),Raylib.GetMouseY());

            Transform.SetAngle((float)Math.Atan2(-1 * mouse.y, -1 * mouse.x));
           

        }


        


    }
}
