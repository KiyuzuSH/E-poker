namespace Game
{
	/// <summary> ���� </summary>
	public class Card
	{
		private string cardName;
		private Colours cardColour;
		private Weight cardWeight;
		private CharacterType belongTo;

		/// <summary> �������� </summary>
		public string CardName
		{
			get { return cardName; }
		}

		/// <summary> ���ƻ�ɫ </summary>
		public Colours CardColour
		{
			get { return cardColour; }
		}

		/// <summary> ����Ȩֵ </summary>
		public Weight CardWeight
		{
			get { return cardWeight; }
		}

		/// <summary> ������˭���� </summary>
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
