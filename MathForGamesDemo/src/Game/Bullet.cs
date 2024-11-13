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
        private int _selectedbullet;
       
        public float BulletScale
        {
            get => _bulletScale;
            set
            {
                _bulletScale = value;
            }
        }
        public Bullet(int selectedbullet)
        {
            _selectedbullet = selectedbullet;
        }
        

        

        public override void Start()
        {
            base.Start();
            
            BulletScale = 10;
            _bulletOrigin = new Vector2(BulletScale / 2, BulletScale / 2);
            _bulletOffset = new Vector2(0,0);

            AddComponent<Sprite>(new Sprite(this,_selectedbullet,"redbullet","bluebullet",BulletScale , +90, _bulletOrigin, _bulletOffset));
            AddComponent<CheckOutOfBounds>(new CheckOutOfBounds(this));
            Collider = new CircleCollider(this, 5);
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


    }
}
