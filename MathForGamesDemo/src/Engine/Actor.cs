﻿using MathLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace MathForGamesDemo
{

    internal class Actor
    {
        
        private bool _started = false;
        private bool _enabled = true;

        private Component[] _components;

        public bool Started { get => _started; }

        public bool Enabled
        {
            get => _enabled;
            set
            {

                //If enabled would not change do nothing
                if (_enabled == value) return;

                _enabled = value;
                //If value is true call OnEnabled
                if (_enabled)
                    OnEnable();

                //If value is false call OnDisable
                else
                    OnDisable();
            }
        }

        public Collider Collider { get; set; }
        public Transform2D Transform { get; set; }

        public string Name { get; set; }

        public Actor()
        {
            
          Transform = new Transform2D(this);
            _components = new Component[0];

        }

        public static Actor Instantiate(
            Actor actor,
            Transform2D parent = null,
            Vector2 position = new Vector2(),
            float rotation = 0,
            string name = "Actor")
        {
            actor.Transform.LocalPosition = position;
            actor.Transform.Rotate(rotation);
            actor.Name = name;
            if (parent != null)
                parent.AddChild(actor.Transform);

            Game.CurretScene.AddActor(actor);

            return actor;

        }

        public static void Destroy(Actor actor)
        {
            // Remove all children
            foreach (Transform2D child in actor.Transform.Children)
            {
                actor.Transform.RemoveChild(child);
            }
            if(actor.Transform.Parent != null)
                actor.Transform.Parent.RemoveChild(actor.Transform);

        }

        public virtual void OnEnable() { }

        public virtual void OnDisable() { }
        public virtual void Start()
        {
            _started = true;
            
        }

        public virtual void Update(double deltaTime)
        {
            foreach(Component component in _components)
            {
                if (!component.Started)
                    component.Start();

                component.Update(deltaTime);
            }
        }
        public virtual void End()
        {
            foreach (Component component in _components)
            {
                component.End();
            }
        }
        public virtual void OnCollision(Actor other)
        {

        }

        //Add component
        public T AddComponent<T>(T component) where T : Component
        {
            //Create temp array
            Component[] temp = new Component[_components.Length + 1];
            //Deep copy the old array to the temp array
            for (int i = 0; i < _components.Length; i++)
            {
                temp[i] = _components[i];   
            }

            // set the last index in temp to the component we wish to add
            temp[temp.Length - 1] = component;

            // Store temp in _components
            _components = temp;

            return component;
        }

        public T AddComponent<T>() where T : Component
        {
            T component = (T)new Component(this);
            return AddComponent(component);
        }


        //Remove Component
        public bool RemoveComponent<T>(T component) where T : Component
        {
            //Edge case for empty component array
            if (_components.Length <= 0)
                return false;

            //Edge case for only one component
            if (_components.Length == 1 && _components[0] == component)
            {
                _components = new Component[0];
                return true;
            }
            //Create a temp array one smaller than _components
            Component[] temp = new Component[_components.Length - 1];
            bool componentRemoved = false;
            //Deep compy _components into temp minus the one component
            int j = 0;
            for (int i = 0; j< _components.Length - 1; i++)
            {
                if (_components[i] != component)
                {
                    temp[j] = _components[i];
                    j++;
                }
                else
                {
                    componentRemoved = true;
                }
            }
            //If a component was removed, assign temp over _components
            if (componentRemoved)
            {
                _components = temp;
            }

            return componentRemoved;
            
        }

        public bool RemoveComponent<T>() where T : Component
        {
            T component = GetComponent<T>();
            if (component != null)
                return RemoveComponent(component);
            return false;
        }
        //Get component
        public T GetComponent<T>() where T : Component
        {
            foreach (Component component in _components)
            {
                if (component is T)
                    return (T)component;
            }
            return null;
        }

        //Get components
        public T[] GetComponents<T>() where T : Component
        {
            // Create an array of the same size as _components
            T[] temp = new T[_components.Length];
            // Copy all elements that are of type T into temp
            int count = 0;
            for (int i = 0; i < _components.Length; i++)
            {
                if (_components[i] is T)
                {
                    temp[count] = (T)_components[i];
                    count++;
                }
            }
            //Trim the array
            T[] result = new T[count];
            for (int i = 0; i < count; i++)
            {
                result[i] = temp[i];
            }
            return result;
        }
    }
}
