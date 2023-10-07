namespace Game
{
	/// <summary> ÅÆ×À¿ØÖÆ </summary>
	public class DeskControl : CharacterBase
	{
		/// <summary> ³öÅÆ </summary>
		/// <returns> ÅÆ </returns>
		public override Card DealCard()
		{
			return base.DealCard();
		}


		/// <summary> Ìí¼ÓÅÆ </summary>
		/// <param name="card"> ÅÆ </param>
		/// <param name="selected"> Ñ¡Ôñ·ñ? </param>
		public override void AddCard(Card card, bool selected)
		{
			base.AddCard(card, selected);

		}

		/// <summary> ÅÅĞò </summary>
		/// <param name="asc"> ÕıĞò·ñ? </param>
		public override void Sort(bool asc = false)
		{
			base.Sort(asc);
		}

		/// <summary> Çå¿Õ×ÀÃæ </summary>
		public void Clear()
		{
			CardList.Clear();

			CardUI[] cards = transform.Find("CreatePoint").GetComponentsInChildren<CardUI>();
			for(int i = 0; i < cards.Length; i++)
				cards [i].Destroy();
		}
	}
}
