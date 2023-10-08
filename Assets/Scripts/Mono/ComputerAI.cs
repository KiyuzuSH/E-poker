using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Game
{
	/// <summary> ���Ƶ����Զ����� </summary>
	public class ComputerAI : MonoBehaviour
	{
		/// <summary> ��ǰ�ĳ������� </summary>
		public CardType currType = CardType.None;
		/// <summary> ��ǰ������ </summary>
		public List<Card> selectCards = new List<Card>();

		/// <summary> �Զ����� </summary>
		/// <param name="cards"> ���п��� </param>
		/// <param name="cardType"> ��һ�ֳ������� </param>
		/// <param name="weight"> ��һ�ֿ���Ȩֵ </param>
		/// <param name="length"> ��һ�ֿ��Ƴ��� </param>
		/// <param name="isBiggest"> �Ƿ����Ȩֵ </param>
		public void SmartSelectCards(List<Card> cards, CardType cardType, int weight, int length, bool isBiggest)
		{
			cardType = isBiggest ? CardType.None : cardType;
			currType = cardType;
			selectCards.Clear();
			switch(cardType)
			{
				case CardType.None:
					selectCards = FindSmallestCard(cards);
					// �Ѿ��޸��˵�ǰ�ĳ�������
					break;
				case CardType.Single:
					selectCards = FindSingle(cards, weight);
					break;
				case CardType.Double:
					selectCards = FindDouble(cards, weight);
					break;
				case CardType.Straight:
					selectCards = FindStraight(cards, weight, length);
					if(selectCards.Count == 0)
					{
						selectCards = FindBoom(cards, -1);
						currType = CardType.Bomb;
						if(selectCards.Count == 0)
						{
							selectCards = FindJokerBoom(cards);
							currType = CardType.JokerBomb;
						}
					}
					break;
				case CardType.DoubleStraight:
					selectCards = FindDoubleStraight(cards, weight, length);
					if(selectCards.Count == 0)
					{
						selectCards = FindBoom(cards, -1);
						currType = CardType.Bomb;
						if(selectCards.Count == 0)
						{
							selectCards = FindJokerBoom(cards);
							currType = CardType.JokerBomb;
						}
					}
					break;
				case CardType.TripleStraight:
					selectCards = FindBoom(cards, -1);
					currType = CardType.Bomb;
					if(selectCards.Count == 0)
					{
						selectCards = FindJokerBoom(cards);
						currType = CardType.JokerBomb;
					}
					break;
				case CardType.ThreeTwo:
					selectCards = FindThreeAndTwo(cards, weight);
					break;
				case CardType.ThreeOne:
					selectCards = FindThreeAndOne(cards, weight);
					break;
				case CardType.Three:
					selectCards = FindThree(cards, weight);
					break;
				case CardType.Bomb:
					selectCards = FindBoom(cards, weight);
					if(selectCards.Count == 0)
					{
						selectCards = FindJokerBoom(cards);
						currType = CardType.JokerBomb;
					}
					break;
				case CardType.JokerBomb:
					// ��ը�޵�
					break;
				default:
					break;
			}
		}

		#region ��������
		/// <summary> ����С���� </summary>
		/// <returns>  </returns>
		private List<Card> FindSmallestCard(List<Card> cards)
		{
			List<Card> select = new List<Card>();
			// �ȳ�˳��
			for(int i = 12; i >= 5; i--)
			{
				select = FindStraight(cards, -1, i);
				if(select.Count != 0)
				{
					currType = CardType.Straight;
					break;
				}
			}
			if(select.Count == 0)
			{
				// ����+��
				for(int i = 0; i < 36; i += 3)
				{
					select = FindThreeAndTwo(cards, i - 1);
					if(select.Count != 0)
					{
						currType = CardType.ThreeOne;
						break;
					}
				}
			}
			if(select.Count == 0)
			{
				// ����+һ
				for(int i = 0; i < 36; i += 3)
				{
					select = FindThreeAndOne(cards, i - 1);
					if(select.Count != 0)
					{
						currType = CardType.ThreeTwo;
						break;
					}
				}
			}
			if(select.Count == 0)
			{
				// ������
				for(int i = 0; i < 36; i += 3)
				{
					select = FindThree(cards, i - 1);
					if(select.Count != 0)
					{
						currType = CardType.Three;
						break;
					}
				}
			}
			if(select.Count == 0)
			{
				// �Զ�
				for(int i = 0; i < 24; i += 2)
				{
					select = FindDouble(cards, i - 1);
					if(select.Count != 0)
					{
						currType = CardType.Double;
						break;
					}
				}
			}
			if(select.Count == 0)
			{
				// ����
				select = FindSingle(cards, -1);
				currType = CardType.Single;
			}
			return select;
		}

		/// <summary> �ҵ��� </summary>
		private List<Card> FindSingle(List<Card> cards, int weight)
		{
			List<Card> select = new List<Card>();
			for(int i = 0; i < cards.Count; i++)
			{
				if((int)cards [i].CardWeight > weight)
				{
					select.Add(cards [i]);
					break;
				}
			}
			return select;
		}

		/// <summary> �ҶԶ� </summary>
		private List<Card> FindDouble(List<Card> cards, int weight)
		{
			List<Card> select = new List<Card>();
			for(int i = 0; i < cards.Count - 1; i++)
			{
				if(cards [i].CardWeight == cards [i + 1].CardWeight)
				{
					int totalWeight = (int)cards[i].CardWeight + (int)cards[i + 1].CardWeight;

					if(totalWeight > weight)
					{
						select.Add(cards [i]);
						select.Add(cards [i + 1]);
						break;
					}
				}
			}
			return select;
		}

		/// <summary> ��˳�� </summary>
		private List<Card> FindStraight(List<Card> cards, int minWeight, int length)
		{
			List<Card> select = new List<Card>();
			int counter = 0;
			List<int> indexList = new List<int>();
			for(int i = 0; i < cards.Count - 4; i++)
			{
				int weight = (int)cards[i].CardWeight;
				if(weight > minWeight)
				{
					counter = 1;
					indexList.Clear();

					for(int j = i + 1; j < cards.Count; j++)
					{
						if(cards [j].CardWeight > Weight.Ace)
							break;

						if((int)cards [j].CardWeight - weight == counter)
						{
							counter++;
							indexList.Add(j);
						}

						if(counter == length)
							break;
					}
				}
				if(counter == length)
				{
					indexList.Insert(0, i);
					break;
				}

			}

			if(counter == length)
			{
				for(int i = 0; i < indexList.Count; i++)
				{
					select.Add(cards [indexList [i]]);
				}
			}

			return select;
		}

		/// <summary> ��˫˳ </summary>
		private List<Card> FindDoubleStraight(List<Card> cards, int minWeight, int length)
		{
			List<Card> select = new List<Card>();
			int counter = 0;
			List<int> indexList = new List<int>();
			for(int i = 0; i < cards.Count - 4; i++)
			{
				int weight = (int)cards[i].CardWeight;
				if(weight > minWeight)
				{
					counter = 0;
					indexList.Clear();

					int temp = 0;
					for(int j = i + 1; j < cards.Count; j++)
					{
						if(cards [j].CardWeight > Weight.Ace)
							break;

						if((int)cards [j].CardWeight - weight == counter)
						{
							temp++;
							if(temp % 2 == 1)
							{
								counter++;
							}
							indexList.Add(j);
						}

						if(counter == length / 2)
							break;
					}
				}

				if(counter == length / 2)
				{
					indexList.Insert(0, i);
					break;
				}

			}

			if(counter == length / 2)
			{
				for(int i = 0; i < indexList.Count; i++)
				{
					select.Add(cards [indexList [i]]);
				}
			}

			return select;
		}

		/// <summary> �������� </summary>
		private List<Card> FindThree(List<Card> cards, int weight)
		{
			List<Card> select = new List<Card>();
			for(int i = 0; i < cards.Count - 3; i++)
			{
				if(cards [i].CardWeight == cards [i + 1].CardWeight &&
					cards [i].CardWeight == cards [i + 2].CardWeight)
				{
					int totalWeight = (int)cards[i].CardWeight +
					(int)cards[i + 1].CardWeight +
					(int)cards[i + 2].CardWeight;

					if(totalWeight > weight)
					{
						select.Add(cards [i]);
						select.Add(cards [i + 1]);
						select.Add(cards [i + 2]);
						break;
					}
				}
			}
			return select;
		}

		/// <summary> ����+�� </summary>
		private List<Card> FindThreeAndTwo(List<Card> cards, int weight)
		{
			List<Card> select = new List<Card>();
			List<Card> three = FindThree(cards, weight);

			if(three.Count != 0)
			{
				foreach(Card card in three)
					cards.Remove(card);

				List<Card> two = FindDouble(cards, -1);
				if(two.Count != 0)
				{
					select.AddRange(three);
					select.AddRange(two);
				}
			}

			return select;

		}

		/// <summary> ����+һ </summary>
		private List<Card> FindThreeAndOne(List<Card> cards, int weight)
		{
			List<Card> select = new List<Card>();
			List<Card> three = FindThree(cards, weight);
			if(three.Count != 0)
			{
				foreach(Card card in three)
					cards.Remove(card);

				List<Card> one = FindSingle(cards, -1);
				if(one.Count != 0)
				{
					select.AddRange(three);
					select.AddRange(one);
				}
			}

			return select;
		}

		/// <summary> ��ը�� </summary>
		/// <param name="weight">  </param>
		/// <returns>  </returns>
		private List<Card> FindBoom(List<Card> cards, int weight)
		{
			List<Card> select = new List<Card>();
			for(int i = 0; i < cards.Count - 4; i++)
			{
				//������ͨը��
				if(cards [i].CardWeight == cards [i + 1].CardWeight &&
					cards [i].CardWeight == cards [i + 2].CardWeight &&
					cards [i].CardWeight == cards [i + 3].CardWeight)
				{
					int totalWeight = (int)cards[i].CardWeight + (int)cards[i + 1].CardWeight + (int)cards[i + 2].CardWeight
					+ (int)cards[i + 4].CardWeight;
					if(totalWeight > weight)
					{
						select.Add(cards [i]);
						select.Add(cards [i + 1]);
						select.Add(cards [i + 2]);
						select.Add(cards [i + 3]);
						break;
					}
				}
			}
			return select;
		}

		/// <summary> ����ը </summary>
		/// <param name="cards">  </param>
		/// <returns>  </returns>
		private List<Card> FindJokerBoom(List<Card> cards)
		{
			List<Card> select = new List<Card>();
			for(int i = 0; i < cards.Count - 1; i++)
			{
				if(cards [i].CardWeight == Weight.BlackJoker &&
					cards [i + 1].CardWeight == Weight.RedJoker)
				{
					select.Add(cards [i]);
					select.Add(cards [i + 1]);
					break;
				}
			}
			return select;
		}

		#endregion
	}
}
