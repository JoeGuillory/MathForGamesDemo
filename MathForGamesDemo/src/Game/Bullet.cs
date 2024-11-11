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
        private float _bulletSpeed = 200;
        Vector2 _bulletOrigin;
        Vector2 _bulletOffset;
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
            
            BulletScale = 10;
            _bulletOrigin = new Vector2(BulletScale / 2, BulletScale / 2);
            _bulletOffset = new Vector2(0,0);
           

           

            AddComponent<Sprite>(new Sprite(this,"Bullet", BulletScale, +90, _bulletOrigin, _bulletOffset));
            Collider = new CircleCollider(this, 7);
        }


        public override void Update(double deltaTime)
        {
            base.Update(deltaTime);

            //Moves the bullet forward
            Transform.Translate(Transform.Forward * _bulletSpeed * (float)deltaTime);
            
        }
        public override void OnCollision(Actor other)
        {
            base.OnCollision(other);


        }

        public override void End()
        {
            

        }

        private void CheckOutofBound()
        {
            if (Transform.GlobalPosition.x > Raylib.GetScreenWidth() || Transform.GlobalPosition.x < 0)
            {
                Game.CurretScene.RemoveActor(this);

                Console.WriteLine("Object Destroyed");
            }
            if (Transform.GlobalPosition.y > Raylib.GetScreenHeight() || Transform.GlobalPosition.y < 0)
            {

                Game.CurretScene.RemoveActor(this);
                Console.WriteLine("Object Destroyed");
            }
        }
    }
}
