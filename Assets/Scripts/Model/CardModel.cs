using UnityEngine;
using System.Collections.Generic;

namespace Game
{
	/// <summary> 牌库 </summary>
	public class CardModel
	{
		private Queue<Card> cardLibrary=new Queue<Card>();
		/// <summary> 牌库的类型=归属者 </summary>
		private CharacterType cType=CharacterType.Library;
		/// <summary> 牌库剩余牌数 </summary>
		public int CardCount
		{
			get { return cardLibrary.Count; }
		}

		/// <summary> 初始化牌库 </summary>
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

		/// <summary> 发牌 </summary>
		/// <returns> 发出去的牌 </returns>
		public Card DealCard(CharacterType sendTo)
		{
			Card card=cardLibrary.Dequeue();
			card.BelongTo = sendTo;
			return card;
		}

		/// <summary> 回收牌 </summary>
		/// <param name="card"> 要回收的牌 </param>
		public void RecycleCard(Card card)
		{
			cardLibrary.Enqueue(card);
			card.BelongTo = cType;
		}

		/// <summary> 洗牌 </summary>
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
