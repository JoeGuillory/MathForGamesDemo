using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Raylib_cs;
using MathLibrary;

namespace MathForGamesDemo
{
    internal class EnemyTank : Actor
    {
        public float Speed { get; set; } = 25;
        
        public float StartingRotation { get; set; } = -90;
        public float Scale { get; set; } = 25;
        Vector2 _offset;
        Vector2 _vectorScaler;
        Vector2 _bottomorigin;
        Vector2 _toporigin;

        
        public override void Start()
        {
            base.Start();

            
            _offset = new Vector2(Scale / 2, Scale / 2);
            _vectorScaler = new Vector2(10, 20);
            _bottomorigin = new Vector2(Scale / 2, Scale / 2);
            _toporigin = new Vector2(10 / 2, 0);
            Collider = new CircleCollider(this, Scale / 2, _offset);
            
            AddComponent<Sprite>(new Sprite(this, "redbottom", Scale, StartingRotation, _bottomorigin, _offset));
            AddComponent<Sprite>(new Sprite(this, "redbarrel", _vectorScaler, StartingRotation, _toporigin, _offset));
            AddComponent<EnemyShoot>(new EnemyShoot(this, _offset));
            
        }
        public override void Update(double deltaTime)
        {
            base.Update(deltaTime);
            Transform.Translate(Transform.Forward * Speed * (float)deltaTime);
        }
        public override void OnCollision(Actor other)
        {
            base.OnCollision(other);

            Game.CurretScene.RemoveActor(this);
                       
            Game.CurretScene.RemoveActor(other);

            

        }

    }
}
