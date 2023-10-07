using strange.extensions.command.impl;
using strange.extensions.context.api;
using System.Collections;
using UnityEngine;

namespace Game
{
	public class RequestDealCommand : EventCommand
	{
		[Inject] public CardModel CardModel { get; set; }

		[Inject(ContextKeys.CONTEXT_VIEW)] public GameObject GameRoot { get; set; }

		public override void Execute()
		{
			CardModel.Shuffle();
			//����
			GameRoot.GetComponent<GameRoot>().StartCoroutine(DealCard());
		}

		/// <summary> ���� </summary>
		/// <param name="cType">��˭</param>
		private void DealTo(CharacterType cType)
		{
			Card card = CardModel.DealCard(cType);
			DealCardArgs e = new DealCardArgs(cType, card, false);
			dispatcher.Dispatch(CommandEvent.DealCard, e);
		}

		IEnumerator DealCard()
		{
			CharacterType curr = CharacterType.PlayerC;

			for(int i = 0; i < 54; i++)
			{
				if(curr == CharacterType.Desk || curr == CharacterType.Library)
					curr = CharacterType.PlayerC;
				DealTo(curr);
				// ����
				curr++;
				// ��0.1��
				yield return new WaitForEndOfFrame();
			}


			// ���ƽ���֪ͨ
			dispatcher.Dispatch(ViewEvent.COMPLETE_DEAL);
		}


	}

}
