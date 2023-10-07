using strange.extensions.context.impl;

namespace Game
{
	public class GameRoot : ContextView
	{
		void Awake()
		{
			context = new GameContext(this, true);
			context.Start();
		}
	}
}
