using Raylib_cs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathLibrary;

namespace MathForGamesDemo
{
    internal class Tile : Actor
    {
        Texture2D tileTexture = new Texture2D();
        Rectangle tileSource;
        Rectangle tileDestination;
        public override void Start()
        {
            base.Start();
            tileTexture = TextureManager.Textures["Tile"];
            
            tileSource = new Rectangle(0,0,Raylib.GetScreenWidth(),Raylib.GetScreenHeight());
            

        }



        public override void Update(double deltaTime)
        {
            base.Update(deltaTime);
            tileDestination = new Rectangle(0,0,Raylib.GetScreenWidth(),Raylib.GetScreenHeight());

            
            Raylib.DrawTexturePro(tileTexture, tileSource, tileDestination,new Vector2(0,0),0,Color.White);
        }

    }
}
