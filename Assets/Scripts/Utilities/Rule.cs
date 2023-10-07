using System.Collections.Generic;

namespace Game
{
	/// <summary> ��Ϸ���� </summary>
	public class Rule
	{
		/// <summary> ����? </summary>
		/// <param name="Cards"> ѡ������� </param>
		/// <returns> bool </returns>
		public static bool IsSingle(List<Card> cards)
		{
			return cards.Count == 1;
		}

		/// <summary> ����? </summary>
		/// <param name="cards"> ѡ������� </param>
		/// <returns> bool </returns>
		public static bool IsDouble(List<Card> cards)
		{
			if(cards.Count == 2)
				if(cards [0].CardWeight == cards [1].CardWeight)
					return true;
			return false;
		}

		/// <summary> ˳��? </summary>
		/// <param name="cards"> ѡ������� </param>
		/// <returns> bool </returns>
		public static bool IsStraight(List<Card> cards)
		{
			if(cards.Count < 5 || cards.Count > 12)
				return false;
			for(int i = 0; i < cards.Count - 1; i++)
			{
				Weight tempWeight = cards[i].CardWeight;
				if(cards [i + 1].CardWeight - tempWeight != 1) return false;
				if(tempWeight > Weight.Ace || cards [i + 1].CardWeight > Weight.Ace) return false;
			}
			return true;
		}

		/// <summary> ���û�? </summary>
		/// <param name="cards"> ѡ������� </param>
		/// <returns> bool </returns>
		public static bool IsDoubleStraight(List<Card> cards)
		{
			if(cards.Count < 6 || cards.Count % 2 != 0) return false;
			for(int i = 0; i < cards.Count - 2; i += 2)
			{
				if(cards [i].CardWeight != cards [i + 1].CardWeight) return false;
				if(cards [i + 2].CardWeight - cards [i].CardWeight != 1) return false;
				if(cards [i].CardWeight > Weight.Ace || cards [i + 2].CardWeight > Weight.Ace) return false;
			}
			return true;
		}

		/// <summary> ����˳��? </summary>
		/// <param name="cards"> ѡ������� </param>
		/// <returns> bool </returns>
		public static bool IsTripleStraight(List<Card> cards)
		{
			if(cards.Count < 6 || cards.Count % 3 != 0) return false;
			for(int i = 0; i < cards.Count; i += 3)
			{
				if(cards [i].CardWeight != cards [i + 1].CardWeight) return false;
				if(cards [i + 1].CardWeight != cards [i + 2].CardWeight) return false;
				if(cards [i + 2].CardWeight != cards [i + 1].CardWeight) return false;
				if(cards [i].CardWeight > Weight.Ace || cards [i + 3].CardWeight > Weight.Ace) return false;
			}
			return true;
		}

		/// <summary> ����(�ɻ�)? </summary>
		/// <param name="cards"> ѡ������� </param>
		/// <returns> bool </returns>
		public static bool IsThree(List<Card> cards)
		{
			if(cards.Count != 3) return false;
			if(cards [0].CardWeight != cards [1].CardWeight) return false;
			if(cards [1].CardWeight != cards [2].CardWeight) return false;
			if(cards [0].CardWeight != cards [2].CardWeight) return false;
			return true;
		}

		/// <summary> ����һ? </summary>
		/// <param name="cards"> ѡ������� </param>
		/// <returns> bool </returns>
		public static bool IsThreeOne(List<Card> cards)
		{
			if(cards.Count != 4) return false;
			if(cards [0].CardWeight == cards [1].CardWeight && cards [1].CardWeight == cards [2].CardWeight) return true;
			if(cards [1].CardWeight == cards [2].CardWeight && cards [2].CardWeight == cards [3].CardWeight) return true;
			return false;
		}

		/// <summary> ������? </summary>
		/// <param name="cards"> ѡ������� </param>
		/// <returns> bool </returns>
		public static bool IsThreeTwo(List<Card> cards)
		{
			if(cards.Count != 5) return false;
			if(cards [0].CardWeight == cards [1].CardWeight && cards [1].CardWeight == cards [2].CardWeight)
				if(cards [3].CardWeight == cards [4].CardWeight)
					return true;
			//if(cards [1].CardWeight == cards [2].CardWeight && cards [2].CardWeight == cards [3].CardWeight)
			//	if(cards [0].CardWeight == cards [4].CardWeight)
			//		return true;
			if(cards [2].CardWeight == cards [3].CardWeight && cards [3].CardWeight == cards [4].CardWeight)
				if(cards [0].CardWeight == cards [1].CardWeight)
					return true;
			return false;
		}

		/// <summary> ը��? </summary>
		/// <param name="cards"> ѡ������� </param>
		/// <returns> bool </returns>
		public static bool IsBomb(List<Card> cards)
		{
			if(cards.Count != 4) return false;
			if(cards [0].CardWeight != cards [1].CardWeight) return false;
			if(cards [1].CardWeight != cards [2].CardWeight) return false;
			if(cards [2].CardWeight != cards [3].CardWeight) return false;
			return true;
		}

		/// <summary> ��ը? </summary>
		/// <param name="cards"> ѡ������� </param>
		/// <returns> bool </returns>
		public static bool IsJokerBomb(List<Card> cards)
		{
			if(cards.Count != 2) return false;
			if(cards [0].CardWeight == Weight.BlackJoker && cards [1].CardWeight == Weight.RedJoker) return true;
			if(cards [0].CardWeight == Weight.RedJoker && cards [1].CardWeight == Weight.BlackJoker) return true;
			return false;
		}

		/// <summary> �ܷ����? </summary>
		/// <param name="cards"> ���� </param>
		/// <param name="type"> �������� </param>
		/// <returns> bool->�ܷ���� </returns>
		public static bool CanPop(List<Card> cards, out CardType type)
		{
			type = CardType.None;
			bool can = false;

			switch(cards.Count)
			{
				case 1:
					if(IsSingle(cards))
					{
						type = CardType.Single;
						can = true;
					}
					break;
				case 2:
					if(IsDouble(cards))
					{
						type = CardType.Double;
						can = true;
					}
					else if(IsJokerBomb(cards))
					{
						type = CardType.JokerBomb;
						can = true;
					}
					break;
				case 3:
					if(IsThree(cards))
					{
						type = CardType.Three;
						can = true;
					}
					break;
				case 4:
					if(IsBomb(cards))
					{
						type = CardType.Bomb;
						can = true;
					}
					else if(IsThreeOne(cards))
					{
						type = CardType.ThreeOne;
						can = true;
					}
					break;
				case 5:
					if(IsStraight(cards))
					{
						type = CardType.Straight;
						can = true;
					}
					else if(IsThreeTwo(cards))
					{
						type = CardType.ThreeTwo;
						can = true;
					}
					break;
				case 6:
					if(IsStraight(cards))
					{
						type = CardType.Straight;
						can = true;
					}
					else if(IsDoubleStraight(cards))
					{
						type = CardType.DoubleStraight;
						can = true;
					}
					else if(IsTripleStraight(cards))
					{
						type = CardType.TripleStraight;
						can = true;
					}
					break;
				case 7:
					if(IsStraight(cards))
					{
						type = CardType.Straight;
						can = true;
					}
					break;
				case 8:
					if(IsStraight(cards))
					{
						type = CardType.Straight;
						can = true;
					}
					else if(IsDoubleStraight(cards))
					{
						type = CardType.DoubleStraight;
						can = true;
					}
					break;
				case 9:
					if(IsStraight(cards))
					{
						type = CardType.Straight;
						can = true;
					}
					else if(IsTripleStraight(cards))
					{
						type = CardType.TripleStraight;
						can = true;
					}
					break;
				case 10:
					if(IsStraight(cards))
					{
						type = CardType.Straight;
						can = true;
					}
					else if(IsDoubleStraight(cards))
					{
						type = CardType.DoubleStraight;
						can = true;
					}
					break;
				case 11:
					if(IsStraight(cards))
					{
						type = CardType.Straight;
						can = true;
					}
					break;
				case 12:
					if(IsStraight(cards))
					{
						type = CardType.Straight;
						can = true;
					}
					else if(IsDoubleStraight(cards))
					{
						type = CardType.DoubleStraight;
						can = true;
					}
					else if(IsTripleStraight(cards))
					{
						type = CardType.TripleStraight;
						can = true;
					}
					break;
				case 13:
					break;
				case 14:
					if(IsDoubleStraight(cards))
					{
						type = CardType.DoubleStraight;
						can = true;
					}
					break;
				case 15:
					if(IsTripleStraight(cards))
					{
						type = CardType.TripleStraight;
						can = true;
					}
					break;
				case 16:
					if(IsDoubleStraight(cards))
					{
						type = CardType.DoubleStraight;
						can = true;
					}
					break;
				case 17:
					break;
				case 18:
					if(IsDoubleStraight(cards))
					{
						type = CardType.DoubleStraight;
						can = true;
					}
					else if(IsTripleStraight(cards))
					{
						type = CardType.TripleStraight;
						can = true;
					}
					break;
				case 19:
					break;
				case 20:
					if(IsDoubleStraight(cards))
					{
						type = CardType.DoubleStraight;
						can = true;
					}
					break;
				default:
					break;
			}
			return can;
		}
	}
}
