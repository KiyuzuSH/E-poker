using strange.extensions.context.api;
using strange.extensions.dispatcher.eventdispatcher.api;
using strange.extensions.mediation.impl;
using UnityEngine.UI;

namespace Game
{
	public class GameOverView : EventView
	{
		[Inject(ContextKeys.CONTEXT_DISPATCHER)] public IEventDispatcher dispatcher { get; set; }

		private Button btn_Restart;
		private Button btn_Quit;

		public void Init()
		{
			btn_Restart=transform.Find("ButtonRestart").GetComponent<Button>();
			btn_Restart.onClick.AddListener(OnRestartClick);
			btn_Quit = transform.Find("ButtonQuit").GetComponent<Button>();
			btn_Quit.onClick.AddListener(onQuitClick);
		}

		public void ViewDestroy()
		{
			btn_Restart.onClick.RemoveListener(OnRestartClick);
			btn_Quit.onClick.RemoveListener(onQuitClick);
		}

		public void OnRestartClick()
		{
			dispatcher.Dispatch(ViewEvent.RESTART_GAME);
			Destroy(gameObject);
		}

		public void onQuitClick()
		{
			dispatcher.Dispatch(ViewEvent.QUIT_GAME, null);
		}
	}
}
