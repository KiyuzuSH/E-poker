using System.Collections.Generic;

namespace Game
{
	public class PlayerControl : CharacterBase
	{
		/// <summary> ��ɫUI���� </summary>
		public CharacterUI characterUI;

		/// <summary> ������ </summary>
		/// <param name="card"> Ҫ������� </param>
		public override void AddCard(Card card, bool selected)
		{
			base.AddCard(card, selected);
			characterUI.SetRemain(CardCount);
		}

		/// <summary> ���� </summary>
		/// <param name="card"> Ҫ������ </param>
		public override Card DealCard()
		{
			Card card = base.DealCard();
			characterUI.SetRemain(CardCount);
			return card;
		}

		/// <summary> ���� </summary>
		/// <param name="asc"> ����asc ����desc </param>
		public override void Sort(bool asc = false)
		{
			base.Sort(asc);
		}

		List<CardUI> tempUI = null;
		List<Card> tempCard = null;

		/// <summary> Ѱ��ѡ�е��� </summary>
		/// <returns> ѡ�е��� in List </returns>
		public List<Card> FindSelectedCard()
		{
			CardUI[] cardUIs = characterUI.CreatePoint.GetComponentsInChildren<CardUI>();
			tempUI = new List<CardUI>();
			tempCard = new List<Card>();
			for(int i = 0; i < cardUIs.Length; i++)
			{
				if(cardUIs [i].Selected)
				{
					tempUI.Add(cardUIs [i]);
					tempCard.Add(cardUIs [i].Card);
				}
			}
			Utilities.Sort(tempCard, true);
			return tempCard;
		}

		/// <summary> ɾȥ���������� </summary>
		public void DeleteSelectedCard()
		{
			if(tempUI == null || tempCard == null)
				return;
			else
			{
				for(int i = 0; i < tempCard.Count; i++)
				{
					tempUI [i].Destroy();
					CardList.Remove(tempCard [i]);
				}
			}
		}
	}
}
