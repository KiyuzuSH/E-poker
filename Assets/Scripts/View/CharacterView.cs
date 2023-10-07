using strange.extensions.mediation.impl;

namespace Game
{
	public class CharacterView : View
	{
		public PlayerControl Player1;
		public PlayerControl Player2;
		public PlayerControl Player3;
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

		// ������Ҫ������� ��һ���������ڲ�дDesk.Clear();

	}

}
