using GameEngine;
using Game.Scenes;
using SFML.Graphics;
using SFML.System;
using SFML.Window;

namespace Game.Classes
{
    class Ship : GameObject
    {
        private const float ySpeed = 0.7f;
        private const float xSpeed = 0.3f;
        private const int FireDelay = 200;
        private int _fireTimer;

        private readonly Sprite _sprite = new Sprite();
        // Creates our ship.
        public Ship()
        {
            _sprite.Texture = GameEngine.Game.GetTexture("../../../Resources/Images/ship.png");
            _sprite.Position = new Vector2f(100, 100);
			AssignTag("ship");
		}
        // functions overridden from GameObject:
        public override void Draw()
        {
            GameEngine.Game.RenderWindow.Draw(_sprite);
        }
        public override void Update(Time elapsed)
        {
            Vector2f pos = _sprite.Position;

            float x = pos.X;
            float y = pos.Y;

            int msElapsed = elapsed.AsMilliseconds();

            if (Keyboard.IsKeyPressed(Keyboard.Key.Up) || Keyboard.IsKeyPressed(Keyboard.Key.W)) { y -= ySpeed * msElapsed; }
            if (Keyboard.IsKeyPressed(Keyboard.Key.Down) || Keyboard.IsKeyPressed(Keyboard.Key.S)) { y += ySpeed * msElapsed; }
            if (Keyboard.IsKeyPressed(Keyboard.Key.Left) || Keyboard.IsKeyPressed(Keyboard.Key.A)) { x -= xSpeed * msElapsed; }
            if (Keyboard.IsKeyPressed(Keyboard.Key.Right) || Keyboard.IsKeyPressed(Keyboard.Key.D)) { x += xSpeed * msElapsed; }
            _sprite.Position = new Vector2f(x, y);

            if (_fireTimer > 0) { _fireTimer -= msElapsed; }
            if (Keyboard.IsKeyPressed(Keyboard.Key.Space) && _fireTimer <= 0)
            {
                _fireTimer = FireDelay;
                FloatRect bounds = _sprite.GetGlobalBounds();
                float laserX = x + 84;
                float laserY = y + bounds.Height / 2.0f;
                Laser laser = new Laser(new Vector2f(laserX, laserY));
                GameEngine.Game.CurrentScene.AddGameObject(laser);
            }
        }
		public override FloatRect GetCollisionRect()
		{
			return _sprite.GetGlobalBounds();
		}
	}
}
