using GameEngine;
using Game.Scenes;
using SFML.Graphics;
using SFML.System;

namespace Game.Classes
{
    class Score : GameObject
    {
        private readonly Text _text = new Text();
        public Score(Vector2f pos)
        {
            _text.Font = GameEngine.Game.GetFont("../../../Resources/Fonts/Courneuf-Regular.ttf");
            _text.Position = pos;
            _text.CharacterSize = 24;
            _text.FillColor = Color.White;
            AssignTag("score");
        }
        public override void Draw()
        {
            GameEngine.Game.RenderWindow.Draw(_text);
        }
        public override void Update(Time elapsed)
        {
            GameScene scene = (GameScene)GameEngine.Game.CurrentScene;
            _text.DisplayedString = "Score: " + scene.GetScore();
        }
    }
}
