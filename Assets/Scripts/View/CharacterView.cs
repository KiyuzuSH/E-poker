using strange.extensions.mediation.impl;

namespace Game
{
	public class CharacterView : View
	{
		public PlayerControl PlayerC;
		public ComputerControl PlayerL;
		public ComputerControl PlayerR;
		public DeskControl Desk;

		/// <summary> ��ӿ��� </summary>
		/// <param name="cType"> Ϊ˭ </param>
		/// <param name="card"> ���� </param>
		/// <param name="selected"> ѡ�з�? </param>
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
