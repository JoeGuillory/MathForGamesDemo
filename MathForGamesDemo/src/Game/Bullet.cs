using Raylib_cs;
using MathLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace MathForGamesDemo
{
    internal class Bullet : Actor
    {
        private float _bulletSpeed = 150;
        Texture2D bulletTexture = new Texture2D();
        Rectangle bulletImage;
        Rectangle bulletDestination;
        Vector2 bulletOrigin;
        Vector2 bulletOffset;
        Vector2 tankBottomOffset; 
        private float _bulletScale;
        
       
        public float BulletScale
        { 
            get => _bulletScale; 
            set 
            {
                _bulletScale = value;
            } 
        }
        

        public override void Start()
        {
            base.Start();
            bulletTexture = Raylib.LoadTexture(@"res\largepng\bulletBlue1_outline.png");
            BulletScale = 10;
           

            bulletImage = new Rectangle(0, 0, bulletTexture.Width, bulletTexture.Height);
            bulletOrigin = new Vector2(0,0);
            bulletOffset = new Vector2(BulletScale/2,-1 * BulletScale / 2);
            tankBottomOffset = new Vector2(TankBottom.TankScale, TankBottom.TankScale / 2);
        }


        public override void Update(double deltaTime)
        {
            base.Update(deltaTime);
            //Moves the bullet forward
            //Transform.Translate(Transform.Forward * _bulletSpeed * (float)deltaTime);
            
            
            bulletDestination = new Rectangle(Transform.GlobalPosition, Transform.GlobalScale * BulletScale);
           

            //Draws it
            Raylib.DrawTexturePro(bulletTexture, bulletImage, bulletDestination, bulletOrigin, Transform.LocalRotationAngle *180 /(float)Math.PI + 90, Color.White);
            Raylib.DrawCircleLinesV(bulletOrigin + Transform.GlobalPosition - bulletOffset, 5, Color.Black);
            Raylib.DrawLineV(Transform.GlobalPosition - bulletOffset ,Transform.GlobalPosition -bulletOffset + (Transform.Forward * 100), Color.Black);
        }
        public override void OnCollision(Actor other)
        {
            base.OnCollision(other);


        }

        public override void End()
        {
            

        }
    }
}
