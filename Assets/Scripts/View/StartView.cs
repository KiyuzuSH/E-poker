using strange.extensions.mediation.impl;
using UnityEngine.UI;

namespace Game
{
	public class StartView : EventView
	{
		private Button btn_Start;
		private Button btn_Quit;

		/// <summary> 注册点击事件侦听 </summary>
		public void Init()
		{
			btn_Start = transform.Find("ButtonStart").GetComponent<Button>();
			btn_Start.onClick.AddListener(onStartClick);
			btn_Quit = transform.Find("ButtonQuit").GetComponent<Button>();
			btn_Quit.onClick.AddListener(onQuitClick);
		}

		/// <summary> 移除点击事件侦听 </summary>
		public void ViewDestroy()
		{
			btn_Start.onClick.RemoveListener(onStartClick);
			btn_Quit.onClick.RemoveListener(onQuitClick);
		}

		/// <summary> 开始按钮 </summary>
		private void onStartClick()
		{
			dispatcher.Dispatch(ViewEvent.START_GAME, null);
			Destroy(gameObject);
		}

		/// <summary> 退出按钮 </summary>
		private void onQuitClick()
		{
			dispatcher.Dispatch(ViewEvent.QUIT_GAME, null);
		}
	}
}
