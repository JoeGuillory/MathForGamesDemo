﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathLibrary;

namespace MathForGamesDemo
{
    internal class TestScene : Scene
    {
        public override void Start()
        {
            base.Start();

            //Add our cool actor
            Actor actor = new TestActor();
            Actor tankbottom = new TankBottom();
            Actor tankTop = new TankTop();
            actor.Transform.LocalPosition = new Vector2(200, 200);
            AddActor(actor);
            AddActor(tankbottom);
            RemoveActor(actor);
            AddActor(tankTop);
        }

    }
}
