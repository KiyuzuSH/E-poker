using strange.extensions.mediation.impl;
using UnityEngine.UI;

namespace Game
{
	public class StartView : EventView
	{
		private Button btn_Start;
		private Button btn_Quit;

		/// <summary> ע�����¼����� </summary>
		public void Init()
		{
			btn_Start = transform.Find("ButtonStart").GetComponent<Button>();
			btn_Start.onClick.AddListener(onStartClick);
			btn_Quit = transform.Find("ButtonQuit").GetComponent<Button>();
			btn_Quit.onClick.AddListener(onQuitClick);
		}

		/// <summary> �Ƴ�����¼����� </summary>
		public void ViewDestroy()
		{
			btn_Start.onClick.RemoveListener(onStartClick);
			btn_Quit.onClick.RemoveListener(onQuitClick);
		}

		/// <summary> ��ʼ��ť </summary>
		private void onStartClick()
		{
			dispatcher.Dispatch(ViewEvent.START_GAME, null);
			Destroy(gameObject);
		}

		/// <summary> �˳���ť </summary>
		private void onQuitClick()
		{
			dispatcher.Dispatch(ViewEvent.QUIT_GAME, null);
		}
	}
}
