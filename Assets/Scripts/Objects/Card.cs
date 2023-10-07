namespace Game
{
	/// <summary> 卡牌 </summary>
	public class Card
	{
		private string cardName;
		private Colours cardColour;
		private Weight cardWeight;
		private CharacterType belongTo;

		/// <summary> 卡牌名字 </summary>
		public string CardName
		{
			get { return cardName; }
		}

		/// <summary> 卡牌花色 </summary>
		public Colours CardColour
		{
			get { return cardColour; }
		}

		/// <summary> 卡牌权值 </summary>
		public Weight CardWeight
		{
			get { return cardWeight; }
		}

		/// <summary> 卡牌由谁持有 </summary>
		public CharacterType BelongTo
		{
			get { return belongTo; }
			set { belongTo = value; }
		}

		public Card(string name,Colours colour, Weight weight,CharacterType belongTo)
		{
			this.cardName = name;
			this.cardColour = colour;
			this.cardWeight = weight;
			this.belongTo = belongTo;
		}
	}
}
