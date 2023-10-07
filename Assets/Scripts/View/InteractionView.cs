using strange.extensions.mediation.impl;
using UnityEngine.UI;

namespace Game
{
	public class InteractionView : View
	{
		public Button btn_Deal;
		public Button btn_Play;
		public Button btn_Pass;

		/// <summary> ȫ������ </summary>
		public void DeactiveAll()
		{
			btn_Deal.gameObject.SetActive(false);
			btn_Play.gameObject.SetActive(false);
			btn_Pass.gameObject.SetActive(false);
		}

		/// <summary> ���� </summary>
		public void ActiveDeal()
		{
			btn_Deal.gameObject.SetActive(true);
			btn_Play.gameObject.SetActive(false);
			btn_Pass.gameObject.SetActive(false);
		}

		/// <summary> ���� </summary>
		public void ActivePlay(bool canPass = true)
		{
			btn_Deal.gameObject.SetActive(false);
			btn_Play.gameObject.SetActive(true);
			btn_Pass.gameObject.SetActive(true);
			btn_Pass.interactable = canPass;
		}
	}
}
