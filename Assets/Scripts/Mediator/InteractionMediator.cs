using strange.extensions.mediation.impl;
using UnityEngine;

namespace Game
{
	public class InteractionMediator : EventMediator
	{
		[Inject] public InteractionView InteractionView { get; set; }
		

		[Inject] public RoundModel RoundModel { get; set; }

		public override void OnRegister()
		{
			InteractionView.btn_Deal.onClick.AddListener(onDealClick);
			InteractionView.btn_Play.onClick.AddListener(onPlayClick);
			InteractionView.btn_Pass.onClick.AddListener(onPassClick);
			

			dispatcher.AddListener(ViewEvent.COMPLETE_DEAL, onCompleteDeal);
			dispatcher.AddListener(ViewEvent.COMPLETE_PLAY, onCompletePlay);
			dispatcher.AddListener(ViewEvent.RESTART_GAME, onRestartGame);
			dispatcher.AddListener(ViewEvent.GAME_OVER, onGameOver);

			// 注册静态事件
			RoundModel.PlayerHandler += ActiveButton;
		}

		public override void OnRemove()
		{
			InteractionView.btn_Deal.onClick.RemoveListener(onDealClick);
			InteractionView.btn_Play.onClick.RemoveListener(onPlayClick);
			InteractionView.btn_Pass.onClick.RemoveListener(onPassClick);

			dispatcher.RemoveListener(ViewEvent.COMPLETE_DEAL, onCompleteDeal);
			dispatcher.RemoveListener(ViewEvent.COMPLETE_PLAY, onCompletePlay);
			dispatcher.RemoveListener(ViewEvent.RESTART_GAME, onRestartGame);
			dispatcher.RemoveListener(ViewEvent.GAME_OVER, onGameOver);

			RoundModel.PlayerHandler -= ActiveButton;
		}

		#region 回调函数


		private void onDealClick()
		{
			dispatcher.Dispatch(CommandEvent.RequestDeal);
			InteractionView.DeactiveAll();
		}

		private void onCompleteDeal()
		{
			// 随机给人开始游戏
			//RoundModel.Start((CharacterType)Random.Range(1, 4));
			RoundModel.Start(CharacterType.PlayerC);
		}

		private void ActiveButton(bool canPass)
		{
			InteractionView.ActivePlay(canPass);
		}

		/// <summary> 出牌 </summary>
		private void onPlayClick()
		{
			dispatcher.Dispatch(ViewEvent.REQUEST_PLAY);
		}

		/// <summary> 不出 </summary>
		private void onPassClick()
		{
			dispatcher.Dispatch(CommandEvent.PassCard);
			InteractionView.DeactiveAll();
		}

		private void onGameOver()
		{
			InteractionView.DeactiveAll();
		}

		private void onRestartGame()
		{
			InteractionView.DeactiveAll();
			InteractionView.ActiveDeal();
		}

		private void onCompletePlay()
		{
			InteractionView.DeactiveAll();
		}

		#endregion

	}
}
