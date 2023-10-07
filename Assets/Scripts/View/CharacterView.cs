using strange.extensions.mediation.impl;

namespace Game
{
	public class CharacterView : View
	{
		public PlayerControl PlayerC;
		public ComputerControl PlayerL;
		public ComputerControl PlayerR;
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
					PlayerC.AddCard(card, selected);
					break;
				case CharacterType.PlayerL:
					PlayerL.AddCard(card, selected);
					break;
				case CharacterType.PlayerR:
					PlayerR.AddCard(card, selected);
					break;
				case CharacterType.Desk:
					Desk.AddCard(card, selected);
					break;
				default:
					break;
			}
		}
	}

}
