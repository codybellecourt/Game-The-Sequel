using GameEngine;
using Game.Scenes;
using SFML.Audio;
using SFML.Graphics;
using SFML.System;
using SFML.Window;

namespace Game.Classes
{
    class Laser : GameObject
    {
        private const float Speed = 1.2f;
        private readonly Sprite _sprite = new Sprite();
        private readonly Sound _blast = new Sound();
        public Laser(Vector2f pos)
        {
            _sprite.Texture = GameEngine.Game.GetTexture("../../../Resources/Images/laser.png");
            _sprite.Position = pos;
            AssignTag("laser");

            _blast.SoundBuffer = GameEngine.Game.GetSoundBuffer("../../../Resources/Sounds/blast.wav");
            _blast.Play();

        }
        public override void Draw()
        {
            GameEngine.Game.RenderWindow.Draw(_sprite);
        }
        public override void Update(Time elapsed)
        {
            int msElapsed = elapsed.AsMilliseconds();
            Vector2f pos = _sprite.Position;
            if (pos.X > GameEngine.Game.RenderWindow.Size.X)
            {
                MakeDead();
            }
            else
            {
                _sprite.Position = new Vector2f(pos.X + Speed * msElapsed, pos.Y);
            }
        }
        public override FloatRect GetCollisionRect()
        {
            return _sprite.GetGlobalBounds();
        }
    }
}