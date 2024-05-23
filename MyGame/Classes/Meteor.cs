using GameEngine;
using Game.Scenes;
using SFML.Graphics;
using SFML.System;

namespace Game.Classes
{
    class Meteor : GameObject
    {
        private const float Speed = 0.5f;
        private readonly Sprite _sprite = new Sprite();
        public Meteor(Vector2f pos)
        {
            SetCollisionCheckEnabled(true);
            _sprite.Texture = GameEngine.Game.GetTexture("../../../Resources/Images/meteor.png");
            _sprite.Position = pos;
            AssignTag("meteor");
        }
        public override void Draw()
        {
            GameEngine.Game.RenderWindow.Draw(_sprite);
        }
        public override void Update(Time elapsed)
        {
            int msElapsed = elapsed.AsMilliseconds();
            Vector2f pos = _sprite.Position;
            if (pos.X < _sprite.GetGlobalBounds().Width * -1)
            {
                // GameScene scene = (GameScene)GameEngine.Game.CurrentScene;
                // scene.DecreaseLives();
                MakeDead();
            }
            else
            {
                _sprite.Position = new Vector2f(pos.X - Speed * msElapsed, pos.Y);
            }
        }
        public override FloatRect GetCollisionRect()
        {
            return _sprite.GetGlobalBounds();
        }
        public override void HandleCollision(GameObject otherGameObject)
        {
            if (otherGameObject.HasTag("laser"))
            {
                otherGameObject.MakeDead();

                GameScene scene = (GameScene)GameEngine.Game.CurrentScene;
				scene.IncreaseScore(1);
			}
            else if (otherGameObject.HasTag("ship"))
            {
				GameScene scene = (GameScene)GameEngine.Game.CurrentScene;
				scene.DecreaseLives();
			}
            Vector2f pos = _sprite.Position;
            pos.X = pos.X + _sprite.GetGlobalBounds().Width / 2.0f;
            pos.Y = pos.Y + _sprite.GetGlobalBounds().Height / 2.0f;
            Explosion explosion = new Explosion(pos);
            GameEngine.Game.CurrentScene.AddGameObject(explosion);
            MakeDead();

        }
    }
}