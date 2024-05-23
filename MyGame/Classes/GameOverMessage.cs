﻿using GameEngine;
using Game.Scenes;
using SFML.Graphics;
using SFML.System;
using SFML.Window;

namespace Game.Classes
{
    class GameOverMessage : GameObject
    {
        private readonly Text _text = new Text();
        public GameOverMessage(int score)
        {
            _text.Font = GameEngine.Game.GetFont("../../../Resources/Fonts/Courneuf-Regular.ttf");
            _text.Position = new Vector2f(50.0f, 50.0f);
            _text.CharacterSize = 48;
            _text.FillColor = Color.Red;
            _text.DisplayedString = "GAME OVER\n\nYOUR SCORE: " + score +
            "\n\nPRESS ENTER TO CONTINUE";
        }
        public override void Draw()
        {
            GameEngine.Game.RenderWindow.Draw(_text);
        }
        public override void Update(Time elapsed)
        {
            if (Keyboard.IsKeyPressed(Keyboard.Key.Enter))
            {
                GameScene scene = new GameScene();
                GameEngine.Game.SetScene(scene);
            }
        }
    }
}