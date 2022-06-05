using SFML.Audio;
using SFML.Graphics;
using SFML.System;
using SFML.Window;

namespace Valor
{
	//	TODO: multiplayer comms
	//	TODO: ECS, Commons.Components, Commons.Systems... or maybe not
	//	TODO: objects have mass -> newtonian physics
	//		- Force2d ✅

	//	TODO: Hitboxes larger than objects
	//	TODO: Collision resolution
	//	TODO: raycasting, what can i do with that again? shooting perhaps?

	//	TODO: sounds and animations

	//	TODO: XML comment everything
	//	TODO: Organize the library... lol

	public abstract class Game
	{
		private readonly System.Diagnostics.Stopwatch stopwatch = new();
		protected double DeltaTime { get { return stopwatch.Elapsed.TotalSeconds; } }
		protected double FPS { get { return 1 / DeltaTime; } }
		protected RenderWindow window;
		public void Run()
		{
			window.Closed += (_, __) => window.Close();

			//window.SetMouseCursorVisible(false);
			//Mouse.SetPosition(
			//	new Vector2i(
			//		  (int)VideoMode.FullscreenModes[0].Width / 2,
			//		  (int)VideoMode.FullscreenModes[0].Height / 2),
			//	  window);
			window.SetVerticalSyncEnabled(true);

			//window.SetFramerateLimit(60);

			Initialize();

			window.DispatchEvents();
			
			while (window.IsOpen)
			{
				window.DispatchEvents();
				
				stopwatch.Restart();

				// TODO: Figure out mouse relative movement https://en.sfml-dev.org/forums/index.php?topic=9370.0
				Update();

				window.Clear();
				Draw();
				window.Display();
			}
		}

		protected Game(string title)
		{
			window = new(VideoMode.FullscreenModes[0], title, Styles.Fullscreen);
		}

		protected abstract void Initialize();
		protected abstract void Update();
		protected abstract void Draw();
	}
}