using strange.extensions.mediation.impl;

namespace Game
{
	public class CharacterView : View
	{
		public PlayerControl Player1;
		public PlayerControl Player2;
		public PlayerControl Player3;
		public DeskControl Desk;

		/// <summary> 添加卡牌 </summary>
		/// <param name="cType"> 为谁 </param>
		/// <param name="card"> 何牌 </param>
		/// <param name="selected"> 选中否? </param>
		public void AddCard(CharacterType cType, Card card,bool selected)
		{
			switch (cType)
			{
				case CharacterType.PlayerC:
					Player1.AddCard(card, selected);
					break;
				case CharacterType.PlayerL:
					Player2.AddCard(card, selected);
					break;
				case CharacterType.PlayerR:
					Player3.AddCard(card, selected);
					break;
				case CharacterType.Desk:
					Desk.AddCard(card, selected);
					break;
				default:
					break;
			}
		}

		// 如有需要清空桌面 造一个方法，内部写Desk.Clear();

	}

}
