using GameEngine;
using Game.Scenes;
using Game.Classes;

namespace Game
{
    static class MainGame
    {
        private const int WindowWidth = 800;
        private const int WindowHeight = 600;
        private const string WindowTitle = "Game";

        private static void Main(string[] args)
        {
            // Initialize the game.
            GameEngine.Game.Initialize(WindowWidth, WindowHeight, WindowTitle);

            // Create our scene.
            GameScene scene = new GameScene();
            GameEngine.Game.SetScene(scene);

            // Run the game loop.
            GameEngine.Game.Run();
        }
    }
}