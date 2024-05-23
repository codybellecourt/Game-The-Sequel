﻿using GameEngine;
using Game.Scenes;
using SFML.Graphics;
using SFML.System;

namespace Game.Classes
{
    class MeteorSpawner : GameObject
    {
        // the number of milliseconds between meteor spans.
        private const int SpawnDelay = 1000;
        private int _timer;
        public override void Update(Time elapsed)
        {
            // Determine how much time has passed and adjust our timer.
            int msElapsed = elapsed.AsMilliseconds();
            _timer -= msElapsed;
            // If our timer has elapsed, reset it and spawn a meteor.
            if (_timer <= 0)
            {
                _timer = SpawnDelay;
                Vector2u size = GameEngine.Game.RenderWindow.Size;
                // Spawn the meteor off the right side of the screen.
                // We're assuming the meteor isn't more than 100 pixels wide.
                float meteorX = size.X + 100;
                // Spawn the meteor somewhere along the height of the window, randomly.
                float meteorY = GameEngine.Game.Random.Next() % size.Y;
                // Create a meteor and add it to the scene
                Meteor meteor = new Meteor(new Vector2f(meteorX, meteorY));
                GameEngine.Game.CurrentScene.AddGameObject(meteor);
            }
        }
    }
}
