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
            Texture2D bluebullet = Raylib.LoadTexture(@"res\largepng\bulletBlue1_outline.png");
            Texture2D redbullet = Raylib.LoadTexture(@"res\largepng\bulletRed1_outline.png");
            Texture2D bluetankbarrel = Raylib.LoadTexture(@"res\largepng\tankBlue_barrel2_outline.png");
            Texture2D bluetankbottom = Raylib.LoadTexture(@"res\largepng\tankBody_blue.png");
            Texture2D redtankbottom = Raylib.LoadTexture(@"res\largepng\tankBody_red.png");
            Texture2D redtankbarrel = Raylib.LoadTexture(@"res\largepng\tankRed_barrel2_outline.png");


            _textures.Add("Tile", tile);
            _textures.Add("bluebullet", bluebullet);
            _textures.Add("redbullet", redbullet);
            _textures.Add("bluebarrel",bluetankbarrel);
            _textures.Add("bluebottom", bluetankbottom);
            _textures.Add("redbarrel", redtankbarrel);
            _textures.Add("redbottom", redtankbottom);



        }
        
    }
}
