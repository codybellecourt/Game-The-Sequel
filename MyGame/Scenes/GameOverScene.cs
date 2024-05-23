using GameEngine;
using Game.Scenes;
using Game.Classes;

namespace Game.Scenes
{
    class GameOverScene : Scene
	{
		public GameOverScene(int score)
		{
			GameOverMessage gameOverMessage = new GameOverMessage(score);
			AddGameObject(gameOverMessage);
		}
	}
}