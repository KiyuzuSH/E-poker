using strange.extensions.dispatcher.eventdispatcher.api;
using strange.extensions.mediation.impl;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

namespace Game
{
	public class CharacterMediator : EventMediator
	{
		[Inject] public CharacterView CharacterView { get; set; }

		public override void OnRegister()
		{
			dispatcher.AddListener(CommandEvent.DealCard, onDealCard);
			dispatcher.AddListener(ViewEvent.COMPLETE_DEAL, onCompleteDeal);
			dispatcher.AddListener(ViewEvent.REQUEST_PLAY, onPlayerPlayCard);
			dispatcher.AddListener(ViewEvent.SUCCESS_PLAY, onPlaySuccessPlay);

			RoundModel.OthersHandler += RoundModel_OthersHandler;
		}

		public override void OnRemove()
		{
			dispatcher.RemoveListener(CommandEvent.DealCard, onDealCard);
			dispatcher.RemoveListener(ViewEvent.COMPLETE_DEAL, onCompleteDeal);
			dispatcher.RemoveListener(ViewEvent.REQUEST_PLAY, onPlayerPlayCard);
			dispatcher.RemoveListener(ViewEvent.SUCCESS_PLAY, onPlaySuccessPlay);

			RoundModel.OthersHandler -= RoundModel_OthersHandler;
		}

		#region 回调函数

		/// <summary> 电脑自动出牌 </summary>
		/// <param name="e"> 数据 </param>
		private void RoundModel_OthersHandler(ComputerSmartArgs e)
		{
			StartCoroutine("DelayOneSecond", e);
		}

		/// <summary> 延迟出牌 </summary>
		/// <param name="e"> 数据 </param>
		/// <returns>  </returns>
		IEnumerator DelayOneSecond(ComputerSmartArgs e)
		{
			yield return new WaitForSeconds(1f);

			bool can = false;
			switch(e.CharacterType)
			{
				case CharacterType.PlayerL:
					can = CharacterView.PlayerL.ComputerSmartPlayCard(e.CardType, e.Weight, e.Length, e.Biggest == CharacterType.PlayerL);
					// detect if can play
					if(can)
					{
						List<Card> cardList = CharacterView.PlayerL.SelectCards;
						CardType cardType = CharacterView.PlayerL.CurrType;

						CharacterView.Desk.Clear();
						foreach(Card card in cardList)
							CharacterView.AddCard(CharacterType.Desk, card, false);

						PlayCardArgs f = new PlayCardArgs()
						{
							cardType = cardType,
							characterType = CharacterType.PlayerL,
							Length = cardList.Count,
							Weight = Utilities.GetWeight(cardList, cardType),
						};
						if(!CharacterView.PlayerL.HasCard)
						{
							GameOverArgs g = new GameOverArgs()
							{
								PlayerRWin = false,
								PlayerLWin = true,
								PlayerCWin = false,
							};
							dispatcher.Dispatch(CommandEvent.GameOver, g);
						}
						else
							dispatcher.Dispatch(CommandEvent.PlayCard, f);
					}
					else
					{
						dispatcher.Dispatch(CommandEvent.PassCard);
					}
					break;
				case CharacterType.PlayerR:
					can = CharacterView.PlayerR.ComputerSmartPlayCard(e.CardType, e.Weight, e.Length, e.Biggest == CharacterType.PlayerR);
					if(can)
					{
						List<Card> cardList = CharacterView.PlayerR.SelectCards;
						CardType cardType = CharacterView.PlayerR.CurrType;

						CharacterView.Desk.Clear();
						foreach(Card card in cardList)
							CharacterView.AddCard(CharacterType.Desk, card, false);

						PlayCardArgs f = new PlayCardArgs()
						{
							cardType = cardType,
							characterType = CharacterType.PlayerR,
							Length = cardList.Count,
							Weight = Utilities.GetWeight(cardList, cardType),
						};
						if(!CharacterView.PlayerR.HasCard)
						{
							GameOverArgs g = new GameOverArgs()
							{
								PlayerRWin = true,
								PlayerLWin = false,
								PlayerCWin = false,
							};
							dispatcher.Dispatch(CommandEvent.GameOver, g);
						}
						else
							dispatcher.Dispatch(CommandEvent.PlayCard, f);
					}
					else
					{
						dispatcher.Dispatch(CommandEvent.PassCard);
					}
					break;
				default:
					break;
			}
		}

		private void onDealCard(IEvent evt)
		{
			DealCardArgs e = evt.data as DealCardArgs;
			CharacterView.AddCard(e.cType, e.card, e.selected);
		}

		private void onCompleteDeal(IEvent payload)
		{
			CharacterView.PlayerC.Sort();
			CharacterView.PlayerL.Sort();
			CharacterView.PlayerR.Sort();
			CharacterView.Desk.Sort(true);
		}

		private void onPlayerPlayCard(IEvent evt)
		{
			List<Card> cardList = CharacterView.PlayerC.FindSelectedCard();
			CardType cardType;
			Rule.CanPop(cardList, out cardType);
			if(cardType != CardType.None)
			{
				PlayCardArgs e = new PlayCardArgs()
				{
					Length = cardList.Count,
					Weight = Utilities.GetWeight(cardList,cardType),
					characterType = CharacterType.PlayerC,
					cardType = cardType
				};
				dispatcher.Dispatch(CommandEvent.PlayCard, e);

			}
			else
			{
				UnityEngine.Debug.LogWarning("Choose Right Ones!");
			}
		}

		private void onPlaySuccessPlay()
		{
			List<Card> cardList = CharacterView.PlayerC.FindSelectedCard();

			CharacterView.Desk.Clear();
			foreach(Card card in cardList)
				CharacterView.AddCard(CharacterType.Desk, card, false);

			CharacterView.PlayerC.DeleteSelectedCard();

			if(!CharacterView.PlayerC.HasCard)
			{
				GameOverArgs g = new GameOverArgs()
				{
					PlayerRWin = false,
					PlayerLWin = false,
					PlayerCWin = true,
				};
				dispatcher.Dispatch(CommandEvent.GameOver, g);
			}
			else
				dispatcher.Dispatch(ViewEvent.COMPLETE_PLAY);
		}

		#endregion

	}
}
