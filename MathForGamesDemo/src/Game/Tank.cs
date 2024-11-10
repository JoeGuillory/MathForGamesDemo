using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathLibrary;
using Raylib_cs;

namespace MathForGamesDemo
{
    internal class Tank : Actor
    {

        public override void Start()
        {
            base.Start();

            AddComponent<PlayerMovement>(new PlayerMovement(this, 75, 5));
            AddComponent<Sprite>(new Sprite(this,"Bottom",25,-90,new Vector2(25/2,25/2)));
            AddComponent<Sprite>(new Sprite(this, "Barrel", new Vector2(10,20), -90, new Vector2(25 / 2, 25 / 2)));

        }
        public override void Update(double deltaTime)
        {
            base.Update(deltaTime);

            Raylib.DrawLineV(Transform.GlobalPosition + new Vector2(25 / 2, 25 / 2),Transform.GlobalPosition + new Vector2(25 / 2, 25 / 2) + (Transform.Forward * 50), Color.Black);
        }
    }
}
