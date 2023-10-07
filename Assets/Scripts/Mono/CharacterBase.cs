using ObjPool;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
	public class CharacterBase : MonoBehaviour
	{
		/// <summary> 当前角色类型 </summary>
		public CharacterType characterType;

		private List<Card> cardList = new List<Card>();

		private Transform createPoint;
		public Transform CreatePoint
		{
			get
			{
				if(createPoint == null)
					createPoint = transform.Find("CardCreatePoint");
				return createPoint;
			}
		}

		/// <summary> 我就剩 cardList.count 张牌了 </summary>
		public bool HasCard
		{
			get { return cardList.Count != 0; }
		}

		/// <summary> 根据索引获得卡牌 </summary>
		/// <param name="index"> 索引 </param>
		/// <returns> 卡牌 </returns>
		public Card this [int index] { get { return cardList [index]; } }

		/// <summary> 根据卡牌获得索引 </summary>
		/// <param name="card"> 卡牌 </param>
		/// <returns> 索引 </returns>
		public int this [Card card] { get { return cardList.IndexOf(card); } }

		/// <summary> 卡牌集合 </summary>
		public List<Card> CardList { get { return cardList; } }

		/// <summary> 卡牌数量 </summary>
		public int CardCount { get { return cardList.Count; } }

		/// <summary> 添加牌 </summary>
		public virtual void AddCard(Card card, bool selected)
		{
			cardList.Add(card);
			card.BelongTo = characterType;
			CreateCardUI(card, CardCount - 1, selected);
		}

		/// <summary> 出牌 </summary>
		public virtual Card DealCard()
		{
			Card card = cardList[CardCount - 1];
			cardList.Remove(card);
			return card;
		}

		/// <summary> 创建卡牌预设 </summary>
		/// <param name="card"> 卡片信息 </param>
		/// <param name="index"> 索引 </param>
		public void CreateCardUI(Card card, int index, bool selected)
		{
			GameObject go = PoolManager.Instance.GetObject("Card");
			go.name = characterType.ToString() + "_" + index.ToString();
			CardUI cardUI = go.GetComponent<CardUI>();
			cardUI.Card = card;
			cardUI.Selected = selected;
			cardUI.SetPosition(CreatePoint, index);
		}

		/// <summary> 排序 </summary>
		/// <param name="asc"> 升序asc 降序desc </param>
		public virtual void Sort(bool asc = false)
		{
			Utilities.Sort(CardList, asc);
			this.SortCardUI(cardList);
		}

		/// <summary> 排序卡牌的UI </summary>
		/// <param name="cards"> 有序序列 </param>
		private void SortCardUI(List<Card> cards)
		{
			CardUI[] cardUIs = CreatePoint.GetComponentsInChildren<CardUI>();

			for(int i = 0; i < cards.Count; i++)
			{
				for(int j = 0; j < cardUIs.Length; j++)
				{
					if(cards [i] == cardUIs [j].Card)
					{
						cardUIs [j].SetPosition(CreatePoint, i);
					}
				}
			}
		}




	}
}
