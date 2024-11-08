using Raylib_cs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using MathLibrary;

namespace MathForGamesDemo
{
    internal class Sprite : Component
    {
        private string _path;
        private Texture2D _texture;
       

        public Texture2D Texture { get => _texture; }
        public Sprite(Actor onwer, string path) : base(onwer)
        {
            _path = path;
        }

        public override void Start()
        {
            base.Start();
            
            if (!Raylib.IsTextureReady(_texture))
                _texture = Raylib.LoadTexture(_path);

        }

        public Texture2D GetTexture() 
        {
            
            return Texture;
        }

       
       
    }
}
