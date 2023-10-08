using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Game
{
	/// <summary>
	/// 电脑
	/// </summary>
	public class ComputerControl : CharacterBase
	{
		/// <summary>
		/// 角色UI控制
		/// </summary>
		public CharacterUI characterUI;

		/// <summary>
		/// Pass
		/// </summary>
		public CanvasGroup cg_Pass;

		/// <summary>
		/// 控制电脑自动出牌
		/// </summary>
		public ComputerAI ComputerAI;

		/// <summary>
		/// 添加卡牌
		/// </summary>
		/// <param name="card"></param>
		public override void AddCard(Card card, bool selected)
		{
			base.AddCard(card, selected);

			characterUI.SetRemain(CardCount);
		}

		/// <summary>
		/// 出牌
		/// </summary>
		/// <param name="card"></param>
		public override Card DealCard()
		{
			Card card = base.DealCard();
			characterUI.SetRemain(CardCount);
			return card;
		}


		/// <summary>
		/// 排序
		/// </summary>
		/// <param name="asc"></param>
		public override void Sort(bool asc = true)
		{
			base.Sort(asc);
		}

		/// <summary> CPU 当前出牌类型 </summary>
		public CardType CurrType { get { return ComputerAI.currType; } }
		/// <summary> CPU 当前要出的牌 </summary>
		public List<Card> SelectCards { get { return ComputerAI.selectCards; } }
		/// <summary>
		/// 电脑自动出牌
		/// </summary>
		public bool ComputerSmartPlayCard(CardType cardType, int weight, int length, bool isBiggest)
		{
			ComputerAI.SmartSelectCards(CardList,cardType, weight, length, isBiggest);
			if(SelectCards.Count != 0)
			{

				DestroyCards();
				return true;
			}
			else
			{
				ComputerPass();
				return false;
			}
		}

		private void DestroyCards()
		{
			CardUI[] cardUIs=transform.Find("CardCreatePoint").GetComponentsInChildren<CardUI>();
			for(int i=0;i<cardUIs.Length;i++)
			{
				for(int j = 0; j < SelectCards.Count; j++)
				{
					if(SelectCards [j] == cardUIs [i].Card)
					{
						cardUIs[i].Destroy();
						CardList.Remove(SelectCards [j]);
					}
				}
			}
			SortCardUI(CardList);
			characterUI.SetRemain(CardCount);
		}

		/// <summary>
		/// 电脑 Pass 管不上
		/// </summary>
		public void ComputerPass()
		{
			cg_Pass.alpha = 1f;
			StartCoroutine(PassAnim());
		}

		/// <summary>
		/// PASS的渐隐动画
		/// </summary>
		/// <returns></returns>
		IEnumerator PassAnim()
		{
			float time = 1f;

			while(time >= 0f)
			{
				yield return new WaitForSeconds(0.2f);
				time -= 0.2f;
				cg_Pass.alpha -= 0.2f;
			}
		}
	}
}
