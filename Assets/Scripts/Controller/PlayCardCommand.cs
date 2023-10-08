using strange.extensions.command.impl;

namespace Game
{
	public class PlayCardCommand : EventCommand
	{
		[Inject] public RoundModel RoundModel { get; set; }

		public override void Execute()
		{
			PlayCardArgs e = evt.data as PlayCardArgs;

			// Legal Play?
			if(e.characterType == CharacterType.PlayerC)
			{
				if(e.cardType == RoundModel.CardType && e.Weight > RoundModel.Weight)
					dispatcher.Dispatch(ViewEvent.SUCCESS_PLAY);
				else if((e.cardType == CardType.Bomb && RoundModel.CardType != CardType.Bomb))
					dispatcher.Dispatch(ViewEvent.SUCCESS_PLAY);
				else if(e.cardType == CardType.JokerBomb)
					dispatcher.Dispatch(ViewEvent.SUCCESS_PLAY);
				else if(RoundModel.Biggest == CharacterType.PlayerC)
					dispatcher.Dispatch(ViewEvent.SUCCESS_PLAY);
				else
				{
					UnityEngine.Debug.LogWarning("非法出牌!");
					return;
				}
			}

			// 保存回合信息
			RoundModel.Length = e.Length;
			RoundModel.Weight = e.Weight;
			RoundModel.CardType = e.cardType;
			RoundModel.Biggest = e.characterType;

			// 转换出牌
			RoundModel.Turn();
		}
	}
}
