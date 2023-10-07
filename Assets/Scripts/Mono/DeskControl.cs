namespace Game
{
	/// <summary> �������� </summary>
	public class DeskControl : CharacterBase
	{
		/// <summary> ���� </summary>
		/// <returns> �� </returns>
		public override Card DealCard()
		{
			return base.DealCard();
		}


		/// <summary> ����� </summary>
		/// <param name="card"> �� </param>
		/// <param name="selected"> ѡ���? </param>
		public override void AddCard(Card card, bool selected)
		{
			base.AddCard(card, selected);

		}

		/// <summary> ���� </summary>
		/// <param name="asc"> �����? </param>
		public override void Sort(bool asc = false)
		{
			base.Sort(asc);
		}

		/// <summary> ������� </summary>
		public void Clear()
		{
			CardList.Clear();

			CardUI[] cards = transform.Find("CreatePoint").GetComponentsInChildren<CardUI>();
			for(int i = 0; i < cards.Length; i++)
				cards [i].Destroy();
		}
	}
}
