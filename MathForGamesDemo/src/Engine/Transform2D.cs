﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathLibrary;

namespace MathForGamesDemo
{
    internal class Transform2D
    {
        private Matrix3 _localMatrix = Matrix3.Identity;
        private Matrix3 _globalMatrix = Matrix3.Identity;

        private Matrix3 _localTranslation = Matrix3.Identity;
        private Matrix3 _localRotation = Matrix3.Identity;
        private Matrix3 _localScale = Matrix3.Identity;


        private Actor _owner;

        private Transform2D _parent;
        private Transform2D[] _children;

        private float _localRotationAngle;


        public Matrix3 LocalRotation
        {
            get { return _localRotation; }
            set
            {
                _localRotation = value;

                _localRotationAngle = -(float)Math.Atan2(_localRotation.m01, _localRotation.m00);
                UpdateTransforms();
            }

        }

        public Vector2 LocalPosition
        {
            get { return new Vector2(_localTranslation.m02, _localTranslation.m12); }
            set
            {
                _localTranslation.m02 = value.x;
                _localTranslation.m12 = value.y;
                UpdateTransforms();
            }
        }

        public Vector2 GlobalPosition
        {
            get { return new Vector2(_globalMatrix.m02, _globalMatrix.m12); }
        }

        public Vector2 LocalScale
        {
            get { return new Vector2(_localScale.m00, _localScale.m11); }
            set
            {

                _localScale.m00 = value.x;
                _localScale.m11 = value.y;
                UpdateTransforms();
            }

        }

        public Vector2 GlobalScale
        {
            get
            {
                Vector2 xAxis = new Vector2(_globalMatrix.m00, _globalMatrix.m10);
                Vector2 yAxis = new Vector2(_globalMatrix.m01, _globalMatrix.m11);

                return new Vector2(xAxis.Magnitude, yAxis.Magnitude);
            }
        }

        public Actor Owner
        {
            get { return _owner; }
        }

        public Vector2 Forward
        {
            get { return new Vector2(_globalMatrix.m00, _globalMatrix.m10).Normalized; }
        }

        public Vector2 Right
        {
            get { return new Vector2(_globalMatrix.m01, _globalMatrix.m11).Normalized; }
        }

        public float LocalRotationAngle
        {
            get 
            {
                return _localRotationAngle; 
            }
           
        }

        public float GlobalRotationAngle
        {
            get { return (float)Math.Atan2(_globalMatrix.m01, _globalMatrix.m00); }
        }

        public Transform2D(Actor owner)
        {

            _owner = owner;
            _children = new Transform2D[0];
        }

        public void Translate(Vector2 direction)
        {
            LocalPosition += direction;
        }

        public void Translate(float x, float y)
        {
            LocalPosition += new Vector2(x, y);
        }

        public void Rotate(float radians)
        {
            LocalRotation = Matrix3.CreateRotation(_localRotationAngle + radians);
        }
        public void SetAngle(float radians)
        {
            LocalRotation = Matrix3.CreateRotation(radians);
        }

        public void AddChild(Transform2D child)
        {
            // Do not add the child if it is this transforms's parent
            if (child == _parent)
            {
                return;
            }

            Transform2D[] temp = new Transform2D[_children.Length + 1];

            for (int i = 0; i < _children.Length; i++)
            {

                temp[i] = _children[i];

            }

            temp[_children.Length] = child;

            child._parent = this;

            _children = temp;

        }

        public bool RemoveChild(Transform2D child)
        {

            bool childRemoved = false;
            // If no children
            if (_children.Length <= 0)
            {
                return false;
            }
            Transform2D[] temp = new Transform2D[_children.Length - 1];
            // IF only one child and that child is the correct one
            if (_children.Length == 1 && _children[0] == child)
            {
                childRemoved = true;

            }


            int j = 0;
            for (int i = 0; j < _children.Length - 1; i++)
            {
                if (_children[i] != child)
                {
                    temp[j] = _children[i];
                    j++;
                }
                else
                {
                    childRemoved = true;
                }

            }
            if (childRemoved)
            {
                _children = temp;
                child._parent = null;
            }
            return childRemoved;
        }

        public void UpdateTransforms()
        {
            _localMatrix = _localTranslation * _localRotation * _localScale;

            if (_parent != null)
            {
                _globalMatrix = _parent._globalMatrix * _localMatrix;
            }
            else
            {
                _globalMatrix = _localMatrix;
            }

            foreach (Transform2D child in _children)
            {
                child.UpdateTransforms();
            }
        }
    }
}
