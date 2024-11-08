using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Raylib_cs;
namespace MathForGamesDemo
{
    internal class TextureManager
    {
        private static Dictionary<string, Texture2D> _textures = new Dictionary<string, Texture2D>();
        public static Dictionary<string, Texture2D> Textures { get => _textures; }
        public void Run()
        {
            



        
        }

        public void LoadTextures()
        {
            Texture2D tile = Raylib.LoadTexture(@"res\largepng\tileGrass1.png");
            Texture2D bullet = Raylib.LoadTexture(@"res\largepng\bulletBlue1_outline.png");
            Texture2D tankbarrel = Raylib.LoadTexture(@"res\largepng\tankBlue_barrel2_outline.png");
            Texture2D tankbottom = Raylib.LoadTexture(@"res\largepng\tankBody_blue.png");



            _textures.Add("Tile", tile);
            _textures.Add("Bullet", bullet);
            _textures.Add("Barrel",tankbarrel);
            _textures.Add("Bottom", tankbottom);



        }
        
    }
}
