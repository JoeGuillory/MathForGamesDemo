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
        Texture2D bulletTexture = new Texture2D();
        Rectangle bulletImage;
        Rectangle bulletDestination;
        Vector2 bulletOrigin;
        

        public override void Start()
        {
            base.Start();
            bulletTexture = Raylib.LoadTexture(@"res\largepng\bulletBlue1.png");
            bulletImage = new Rectangle(0, 0, bulletTexture.Width, bulletTexture.Height);
            bulletOrigin = new Vector2(0, 0);
        }


        public override void Update(double deltaTime)
        {
            base.Update(deltaTime);
            Transform.LocalPosition = new Vector2(300, 300);
            bulletDestination = new Rectangle(Transform.GlobalPosition, Transform.GlobalScale * 5);
            Raylib.DrawTexturePro(bulletTexture, bulletImage, bulletDestination, bulletOrigin, (float)(Transform.GlobalRotationAngle * Math.PI) / 180, Color.White);
        }
    }
}
