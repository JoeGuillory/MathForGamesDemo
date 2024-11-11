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
        
        float _scaler;
        float _startingRotation;
        Texture2D _texture;
        Rectangle _textureSource;
        Rectangle _textureDestination;
        Vector2 _textureOrigin;
        Vector2 _textureOffset;
        Vector2 _vectorScaler;
        int _constructor;

        //Constructor to scale by a float. Scales evenly
        public Sprite(Actor onwer, string key, float scaler,float startingRotation,Vector2 textureOrigin, Vector2 textureOffset) : base(onwer)
        {
            _texture = TextureManager.Textures[key];
            _scaler = scaler;
            _startingRotation = startingRotation;
            _textureOffset = textureOffset;
            _textureOrigin = textureOrigin;
            _constructor = 1;
        }
        //Constructor to scale x and y sepretly
        public Sprite(Actor onwer, string key, Vector2 scaler, float startingRotation,Vector2 textureOrigin, Vector2 textureOffset) : base(onwer)
        {
            _texture = TextureManager.Textures[key];
            _vectorScaler = scaler;
            _startingRotation = startingRotation;
            _textureOffset = textureOffset;
            _textureOrigin = textureOrigin;
            _constructor = 2;
        }

        public override void Start()
        {
            base.Start();
            _textureSource = new Rectangle(0,0, _texture.Width, _texture.Height);
            

        }

        public override void Update(double deltaTime)
        {
            base.Update(deltaTime);
            switch (_constructor)
            {
                case 1:
                    _textureDestination = new Rectangle(Owner.Transform.GlobalPosition + _textureOffset, Owner.Transform.GlobalScale * _scaler);
                    break;
                case 2:
                    _textureDestination = new Rectangle(Owner.Transform.GlobalPosition + _textureOffset, new Vector2(Owner.Transform.GlobalScale.x * _vectorScaler.x,Owner.Transform.GlobalScale.y * _vectorScaler.y));
                    break;
            }
                
            Raylib.DrawTexturePro(_texture, _textureSource, _textureDestination, _textureOrigin, -1 *(float)(Owner.Transform.GlobalRotationAngle * 180/Math.PI) + _startingRotation, Color.White);
        }



    }
}
