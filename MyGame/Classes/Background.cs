using GameEngine;
using Game.Scenes;
using SFML.Graphics;
using SFML.System;
using System;

namespace Game.Classes
{
	class Background : GameObject
	{
		private const float Speed = 0.1f;
		private readonly Sprite _sprite = new Sprite();
		private Random rand = new Random();
		public Background(Vector2f pos)
		{
			_sprite.Texture = GameEngine.Game.GetTexture("../../../Resources/Images/background.png");
			_sprite.Position = pos;
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
				_sprite.Position = new Vector2f(800.0f, 0.0f);
			}
			else
			{
				_sprite.Position = new Vector2f(pos.X - Speed * msElapsed, pos.Y);
			}
		}
	}
}