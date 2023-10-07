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
			//发牌
			GameRoot.GetComponent<GameRoot>().StartCoroutine(DealCard());
		}

		/// <summary> 发牌 </summary>
		/// <param name="cType">给谁</param>
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
				// 换人
				curr++;
				// 等0.1秒
				yield return new WaitForEndOfFrame();
			}


			// 发牌结束通知
			dispatcher.Dispatch(ViewEvent.COMPLETE_DEAL);
		}


	}

}
