using GameEngine;
using Game.Scenes;
using Game.Classes;
using SFML.System;

namespace Game.Scenes
{
    class GameScene : Scene
	{
		private int _score;
		private int _lives = 3;
		public GameScene()
		{	
			Background background1 = new Background(new Vector2f(0.0f, 0.0f));
			Background background2 = new Background(new Vector2f(800.0f, 0.0f));
			AddGameObject(background1);
			AddGameObject(background2);

			Ship ship = new Ship();
			AddGameObject(ship);

			MeteorSpawner meteorSpawner = new MeteorSpawner();
			AddGameObject(meteorSpawner);

			Score score = new Score(new Vector2f(10.0f, 10.0f));
			AddGameObject(score);

			Lives lives = new Lives(new Vector2f(10.0f, 40.0f));
			AddGameObject(lives);


		}
		// Get the current score
		public int GetScore()
		{
			return _score;
		}
		// Increase the score
		public void IncreaseScore(int amount)
		{
			_score += amount;
		}
		// Decrease the score
		public void DecreaseScore(int amount)
		{
			_score -= amount;
		}
		// Get the number of lives
		public int GetLives()
		{
			return _lives;
		}
		// Decrease the number of lives
		public void DecreaseLives()
		{
			_lives -= 1;
			if (_lives == 0)
			{
				GameOverScene gameOverScene = new GameOverScene(_score);
				GameEngine.Game.SetScene(gameOverScene);
			}
		}

	}
}