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
        
        public float Speed { get; set; } = 75;
        public float RotateSpeed { get; set; } = 2;

        public static float TankScale { get; set; } = 25;
        
        Texture2D tankBottom = new Texture2D();
        Rectangle tankDestination;
        Rectangle tankImage;
        Vector2 tankCenter;
        //Center of the tank
        Vector2 offset;
        

        public override void Start()
        {
            base.Start();

            //tankBottom = TextureManager.Textures["Bottom"];
            //offset = new Vector2((Transform.LocalScale.x * TankScale) / 2, (Transform.LocalScale.y * TankScale) / 2);
            //tankCenter = new Vector2(Transform.GlobalScale.x * TankScale / 2, Transform.GlobalScale.y * TankScale / 2);
            //tankImage = new Rectangle(0, 0, tankBottom.Width, tankBottom.Height);

            AddComponent<Sprite>(new Sprite(this,"Bottom",TankScale,-90,new Vector2(TankScale /2, TankScale / 2)));
            AddComponent<PlayerMovement>(new PlayerMovement(this, Speed, RotateSpeed));
            
        }

        public override void Update(double deltaTime)
        {
            base.Update(deltaTime);

            //tankDestination = new Rectangle(Transform.GlobalPosition + offset, Transform.GlobalScale * TankScale);

            //Draw Tank
            //Raylib.DrawTexturePro(tankBottom, tankImage, tankDestination, tankCenter, -1 * (float)((Transform.GlobalRotationAngle * 180 / Math.PI)) - 90, Color.White);
        }
       
    }
}
