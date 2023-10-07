using strange.extensions.dispatcher.eventdispatcher.api;
using strange.extensions.mediation.impl;

namespace Game
{
	public class StartMediator : EventMediator
	{
		[Inject] public StartView StartView { get; set; }

		/// <summary> ע�� </summary>
		public override void OnRegister()
		{
			StartView.Init();
			StartView.dispatcher.AddListener(ViewEvent.START_GAME, onStartClick);
			StartView.dispatcher.AddListener(ViewEvent.QUIT_GAME, onQuitClick);
		}

		/// <summary> �Ƴ� </summary>
		public override void OnRemove()
		{
			StartView.dispatcher.RemoveListener(ViewEvent.START_GAME, onStartClick);
			StartView.dispatcher.RemoveListener(ViewEvent.QUIT_GAME, onQuitClick);
		}

		#region �ص�����

		public void onStartClick(IEvent evt)
		{
			dispatcher.Dispatch(CommandEvent.StartGame, evt.data);
		}

		public void onQuitClick(IEvent evt)
		{
			dispatcher.Dispatch(CommandEvent.QuitGame, evt.data);
		}

		#endregion

	}
}
