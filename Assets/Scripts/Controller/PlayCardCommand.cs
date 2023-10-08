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
					UnityEngine.Debug.LogWarning("�Ƿ�����!");
					return;
				}
			}

			// ����غ���Ϣ
			RoundModel.Length = e.Length;
			RoundModel.Weight = e.Weight;
			RoundModel.CardType = e.cardType;
			RoundModel.Biggest = e.characterType;

			// ת������
			RoundModel.Turn();
		}
	}
}
