using ObjPool;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
	public class CharacterBase : MonoBehaviour
	{
		/// <summary> ��ǰ��ɫ���� </summary>
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

		/// <summary> �Ҿ�ʣ cardList.count ������ </summary>
		public bool HasCard
		{
			get { return cardList.Count != 0; }
		}

		/// <summary> ����������ÿ��� </summary>
		/// <param name="index"> ���� </param>
		/// <returns> ���� </returns>
		public Card this [int index] { get { return cardList [index]; } }

		/// <summary> ���ݿ��ƻ������ </summary>
		/// <param name="card"> ���� </param>
		/// <returns> ���� </returns>
		public int this [Card card] { get { return cardList.IndexOf(card); } }

		/// <summary> ���Ƽ��� </summary>
		public List<Card> CardList { get { return cardList; } }

		/// <summary> �������� </summary>
		public int CardCount { get { return cardList.Count; } }

		/// <summary> ����� </summary>
		public virtual void AddCard(Card card, bool selected)
		{
			cardList.Add(card);
			card.BelongTo = characterType;
			CreateCardUI(card, CardCount - 1, selected);
		}

		/// <summary> ���� </summary>
		public virtual Card DealCard()
		{
			Card card = cardList[CardCount - 1];
			cardList.Remove(card);
			return card;
		}

		/// <summary> ��������Ԥ�� </summary>
		/// <param name="card"> ��Ƭ��Ϣ </param>
		/// <param name="index"> ���� </param>
		public void CreateCardUI(Card card, int index, bool selected)
		{
			GameObject go = PoolManager.Instance.GetObject("Card");
			go.name = characterType.ToString() + "_" + index.ToString();
			CardUI cardUI = go.GetComponent<CardUI>();
			cardUI.Card = card;
			cardUI.Selected = selected;
			cardUI.SetPosition(CreatePoint, index);
		}

		/// <summary> ���� </summary>
		/// <param name="asc"> ����asc ����desc </param>
		public virtual void Sort(bool asc = false)
		{
			Utilities.Sort(CardList, asc);
			this.SortCardUI(cardList);
		}

		/// <summary> �����Ƶ�UI </summary>
		/// <param name="cards"> �������� </param>
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
