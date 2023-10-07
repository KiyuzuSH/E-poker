using System.Collections.Generic;

namespace Game
{
	public class PlayerControl : CharacterBase
	{
		/// <summary> 角色UI控制 </summary>
		public CharacterUI characterUI;

		/// <summary> 加入牌 </summary>
		/// <param name="card"> 要加入的牌 </param>
		public override void AddCard(Card card, bool selected)
		{
			base.AddCard(card, selected);
			characterUI.SetRemain(CardCount);
		}

		/// <summary> 出牌 </summary>
		/// <param name="card"> 要出的牌 </param>
		public override Card DealCard()
		{
			Card card = base.DealCard();
			characterUI.SetRemain(CardCount);
			return card;
		}

		/// <summary> 排序 </summary>
		/// <param name="asc"> 升序asc 降序desc </param>
		public override void Sort(bool asc = false)
		{
			base.Sort(asc);
		}

		List<CardUI> tempUI = null;
		List<Card> tempCard = null;

		/// <summary> 寻找选中的牌 </summary>
		/// <returns> 选中的牌 in List </returns>
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

		/// <summary> 删去出掉的手牌 </summary>
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
