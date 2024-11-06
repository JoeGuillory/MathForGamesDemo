using Raylib_cs;
using MathLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathForGamesDemo
{
    internal class Bullet : Actor
    {
        private float _bulletSpeed = 150;
        Texture2D bulletTexture = new Texture2D();
        Rectangle bulletImage;
        Rectangle bulletDestination;
        Vector2 bulletOrigin;
        

        public override void Start()
        {
            base.Start();
            bulletTexture = Raylib.LoadTexture(@"res\largepng\bulletBlue1_outline.png");
            bulletImage = new Rectangle(0, 0, bulletTexture.Width, bulletTexture.Height);
            bulletOrigin = new Vector2(0, 0);
        }


        public override void Update(double deltaTime)
        {
            base.Update(deltaTime);
            
            Transform.Translate(Transform.Forward * _bulletSpeed * (float)deltaTime);
            bulletDestination = new Rectangle(Transform.GlobalPosition, Transform.GlobalScale * 7);
            Raylib.DrawTexturePro(bulletTexture, bulletImage, bulletDestination, bulletOrigin, (float)(Transform.GlobalRotationAngle * Math.PI) / 180 + 90, Color.White);
            //Raylib.DrawLineV(Transform.GlobalPosition , Transform.GlobalPosition + (Transform.Forward * 100), Color.Black);
        }
    }
}
