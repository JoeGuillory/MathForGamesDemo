using MathLibrary;
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
        private Component[] _componentsToRemove;

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
            _componentsToRemove = new Component[0];
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
            
            if (parent != null)
                parent.AddChild(actor.Transform);
            actor.Name = name;
            Game.CurretScene.AddActor(actor);

            return actor;

        }
        /// <summary>
        /// Removes any childern
        /// </summary>
        /// <param name="actor"></param>
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

            //Remove components that should be removed
            RemoveComponentsToBeRemoved();
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

        public T AddComponent<T>() where T : Component, new()
        {
            T component = new T();
            component.Owner = this;
            return AddComponent(component);
        }


        //Remove Component
        public bool RemoveComponent<T>(T component) where T : Component
        {
            //Edge case for empty component array
            if (_components.Length <= 0)
                return false;

            if (_components.Length == 1 && _components[0] == component)
            {
                // Add component to _componentsToRemove
                AddComponentToRemove(component);
                return true;
            }
            // Loop through _components
            foreach (Component comp in _components)
            {
                
                if(comp == component)
                {
                    AddComponentToRemove(comp);
                    return true;
                }
            }
            return false;

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

        private void AddComponentToRemove(Component comp)
        {
            //Make sure component is not in array
            foreach (Component component in _componentsToRemove)
            {
                if (component == comp)
                    return;
            }
            //Create temp array 
            Component[] temp = new Component[_componentsToRemove.Length + 1];
            //Deep copy the old array to the temp array
            for (int i = 0; i < _componentsToRemove.Length; i++)
            {
                temp[i] = _componentsToRemove[i];
            }

            // set the last index in temp to the component we wish to add
            temp[temp.Length - 1] = comp;

            // Store temp in _components
            _componentsToRemove = temp;
        }
        private void RemoveComponentsToBeRemoved()
        {
            if (_componentsToRemove.Length <= 0)
                return;

            Component[] tempComponents = new Component[_components.Length];

            //Deep copy
            int j = 0;
            for (int i = 0; i < _components.Length; i++)
            {
                bool removed = false;
                foreach (Component component in _componentsToRemove)
                {
                    if (_components[i] == component)
                    {
                        removed = true;
                        component.End();
                        break;
                    }

                }
                //If we did not find one to remove, copy the item and increment temp
                if (!removed)
                {
                    tempComponents[j] = _components[i];
                    j++;
                }
            }

            //Trim the array
            Component[] result = new Component[_components.Length - _componentsToRemove.Length];
            for (int i = 0; i < result.Length; i++)
            {
                result[i] = tempComponents[i];
            }

            // Set 
            _components = result;
        }
    }
}
