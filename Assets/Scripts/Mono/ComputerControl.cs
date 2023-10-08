using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Game
{
	/// <summary>
	/// ����
	/// </summary>
	public class ComputerControl : CharacterBase
	{
		/// <summary>
		/// ��ɫUI����
		/// </summary>
		public CharacterUI characterUI;

		/// <summary>
		/// Pass
		/// </summary>
		public CanvasGroup cg_Pass;

		/// <summary>
		/// ���Ƶ����Զ�����
		/// </summary>
		public ComputerAI ComputerAI;

		/// <summary>
		/// ��ӿ���
		/// </summary>
		/// <param name="card"></param>
		public override void AddCard(Card card, bool selected)
		{
			base.AddCard(card, selected);

			characterUI.SetRemain(CardCount);
		}

		/// <summary>
		/// ����
		/// </summary>
		/// <param name="card"></param>
		public override Card DealCard()
		{
			Card card = base.DealCard();
			characterUI.SetRemain(CardCount);
			return card;
		}


		/// <summary>
		/// ����
		/// </summary>
		/// <param name="asc"></param>
		public override void Sort(bool asc = true)
		{
			base.Sort(asc);
		}

		/// <summary> CPU ��ǰ�������� </summary>
		public CardType CurrType { get { return ComputerAI.currType; } }
		/// <summary> CPU ��ǰҪ������ </summary>
		public List<Card> SelectCards { get { return ComputerAI.selectCards; } }
		/// <summary>
		/// �����Զ�����
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
		/// ���� Pass �ܲ���
		/// </summary>
		public void ComputerPass()
		{
			cg_Pass.alpha = 1f;
			StartCoroutine(PassAnim());
		}

		/// <summary>
		/// PASS�Ľ�������
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
