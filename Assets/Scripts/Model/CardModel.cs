using UnityEngine;
using System.Collections.Generic;

namespace Game
{
	/// <summary> �ƿ� </summary>
	public class CardModel
	{
		private Queue<Card> cardLibrary=new Queue<Card>();
		/// <summary> �ƿ������=������ </summary>
		private CharacterType cType=CharacterType.Library;
		/// <summary> �ƿ�ʣ������ </summary>
		public int CardCount
		{
			get { return cardLibrary.Count; }
		}

		/// <summary> ��ʼ���ƿ� </summary>
		public void InitCardLibrary()
		{
			for(int colour = 0; colour < 4; colour++)
			{
				for(int weight = 0; weight < 13; weight++)
				{
					Weight w=(Weight)weight;
					Colours c=(Colours)colour;
					string name=c.ToString()+w.ToString();
					Card card=new Card(name,c,w,cType);
					cardLibrary.Enqueue(card);
				}
			}
			Card bJoker=new Card("blackJoker",Colours.None,Weight.BlackJoker,cType);
			Card rJoker=new Card("redJoker",Colours.None,Weight.RedJoker,cType);
			cardLibrary.Enqueue(bJoker);
			cardLibrary.Enqueue(rJoker);
		}

		/// <summary> ���� </summary>
		/// <returns> ����ȥ���� </returns>
		public Card DealCard(CharacterType sendTo)
		{
			Card card=cardLibrary.Dequeue();
			card.BelongTo = sendTo;
			return card;
		}

		/// <summary> ������ </summary>
		/// <param name="card"> Ҫ���յ��� </param>
		public void RecycleCard(Card card)
		{
			cardLibrary.Enqueue(card);
			card.BelongTo = cType;
		}

		/// <summary> ϴ�� </summary>
		public void Shuffle()
		{
			List<Card> newList=new List<Card>();
			foreach(Card card in newList)
			{
				int index=Random.Range(0,newList.Count+1);
				newList.Insert(index, card);
			}
			cardLibrary.Clear();
			foreach(Card card in newList)
			{
				cardLibrary.Enqueue(card);
			}
			newList.Clear();
		}
	}
}
