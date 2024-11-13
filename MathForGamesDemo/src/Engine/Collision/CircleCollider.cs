using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Raylib_cs;
using MathLibrary;

namespace MathForGamesDemo
{
    internal class CircleCollider : Collider
    {
        public float CollisionRadius { get; set; }
        private Vector2 _offset;
        public CircleCollider(Actor owner, float radius) : base(owner)
        {
            CollisionRadius = radius;
            
        }
        public CircleCollider(Actor owner, float radius,Vector2 offset) : base(owner)
        {
            CollisionRadius = radius;
            _offset = offset;
        }
        
        public override bool CheckCollisionCircle(CircleCollider collider)
        {
            
            float sumRadii = collider.CollisionRadius + CollisionRadius;
            float distance = Vector2.Distance(collider.Owner.Transform.GlobalPosition + _offset,Owner.Transform.GlobalPosition);
            return sumRadii >= distance;
        }
        
        public override void Draw()
        {
            base.Draw();
            Raylib.DrawCircleLinesV(Owner.Transform.GlobalPosition + _offset, CollisionRadius, Color.Red);
        }
    }
}
