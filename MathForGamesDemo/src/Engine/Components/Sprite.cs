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
        public Sprite(Actor onwer, string key, float scaler,float startingRotation, Vector2 textureOffset) : base(onwer)
        {
            _texture = TextureManager.Textures[key];
            _scaler = scaler;
            _startingRotation = startingRotation;
            _textureOffset = textureOffset;
            _constructor = 1;
        }
        public Sprite(Actor onwer, string key, Vector2 scaler, float startingRotation, Vector2 textureOffset) : base(onwer)
        {
            _texture = TextureManager.Textures[key];
            _vectorScaler = scaler;
            _startingRotation = startingRotation;
            _textureOffset = textureOffset;
            
        }

        public override void Start()
        {
            base.Start();
            _textureSource = new Rectangle(0,0, _texture.Width, _texture.Height);
            _textureOrigin = Owner.Transform.GlobalScale * _scaler / 2;

        }

        public override void Update(double deltaTime)
        {
            base.Update(deltaTime);
            if(_constructor == 1)
            _textureDestination = new Rectangle(Owner.Transform.GlobalPosition + _textureOffset, Owner.Transform.GlobalScale * _scaler);
            else
            _textureDestination = new Rectangle(Owner.Transform.GlobalPosition + _textureOffset, new Vector2(Owner.Transform.GlobalScale.x * _vectorScaler.x,Owner.Transform.GlobalScale.y * _vectorScaler.y));
            
            

            Raylib.DrawTexturePro(_texture, _textureSource, _textureDestination, _textureOrigin, -1 *(float)(Owner.Transform.GlobalRotationAngle * 180/Math.PI) + _startingRotation, Color.White);
        }



    }
}
