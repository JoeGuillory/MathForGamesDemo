﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Raylib_cs;


namespace MathForGamesDemo
{
    internal class Game
    {
        private static List<Scene> _scenes;
        private static Scene _currentScene;

        public static Scene CurretScene 
        { get => _currentScene; 
          set 
            { 
                if(_currentScene != null)
                   _currentScene.End();
              _currentScene = value;
              _currentScene.Start();
            } 
        }

        public Game()
        {
            _scenes = new List<Scene>();
            
           
        }
        public static void AddScene(Scene scene)
        {
            if (!_scenes.Contains(scene))
                _scenes.Add(scene);

            if (_currentScene == null)
                CurretScene = scene;

        }
        public static bool RemoveScene(Scene scene)
        {
            bool removed  = _scenes.Remove(scene);
            
            if(_currentScene == scene)
               CurretScene = GetScene(0);
            
            return removed;
        }
        public static Scene GetScene(int index)
        {
            if (_scenes.Count <=0 || _scenes.Count <= index || index < 0)
                return null;
            return _scenes[index];
        }
        public void Run()
        {
            Raylib.InitWindow(800, 480, "Hello World");

            //Timing
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            long currentTime = 0;
            double deltaTime = 1;
            long lastTime = 0;
            
                //Scene
                Scene testScene = new TestScene();
            AddScene(testScene);
            while (!Raylib.WindowShouldClose())
            {

                currentTime = stopwatch.ElapsedMilliseconds;
               
                Raylib.BeginDrawing();
                Raylib.ClearBackground(Color.White);

                testScene.Update(deltaTime);

                Raylib.EndDrawing();


                deltaTime = (currentTime - lastTime) / 1000.0;
                lastTime = currentTime;


            }

            CurretScene.End();

            Raylib.CloseWindow();
        }
    }
}
