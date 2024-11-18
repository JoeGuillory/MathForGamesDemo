using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Raylib_cs;
using MathLibrary;


namespace MathForGamesDemo
{
    
    internal class MainMenu : Scene
    {
        Rectangle button;
        Rectangle mouse;
        Vector2 buttonpos;
        
        public override void Start()
        {
            base.Start();
            buttonpos = new Vector2(Raylib.GetScreenWidth() *.5f, Raylib.GetScreenHeight() * 1.2f);
           
            button = new Rectangle(buttonpos, 400, 100);
            
            
        }
        public override void Update(double deltaTime)
        {
            base.Update(deltaTime);
            
            
            mouse = new Rectangle(Raylib.GetMousePosition(), 10, 10);
            Actor background = Actor.Instantiate(new Tile(), null);
            Raylib.DrawText("Tankage", (int)(Raylib.GetScreenWidth() / 2.7), Raylib.GetScreenHeight() / 7, 50, Color.Black);

           
            if (!Raylib.IsMouseButtonDown(MouseButton.Left))
            {
                Raylib.DrawRectanglePro(button, buttonpos / 2, 0, Color.Green);
                Raylib.DrawText("Click to Play", (int)(buttonpos.x * .6f), (int)(buttonpos.y / 1.8f), 50, Color.Black);
            }


            if (Raylib.IsMouseButtonDown(MouseButton.Left))
            {
                Raylib.DrawRectanglePro(button, buttonpos / 2, 0, Color.DarkGreen);
                Raylib.DrawText("Play", (int)(buttonpos.x * .85f), (int)(buttonpos.y / 1.8f), 50, Color.Black);

                Game.CurretScene = Game.GetScene(1);
            }

        }
        public override void End()
        {
            base.End();

        }
    }
}
