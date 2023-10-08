using ObjPool;
using strange.extensions.command.impl;

namespace Game
{
	public class GameOverCommand : EventCommand
	{
		[Inject] public RoundModel RoundModel { get; set; }

		[Inject] public CardModel CardModel { get; set; }

		public override void Execute()
		{
			GameOverArgs e = evt.data as GameOverArgs;

			CardModel.InitCardLibrary();

			RoundModel.InitRound();

			PoolManager.Instance.HideAllObject("Card");
			//Show Another
			Utilities.CreateUIPanel(PanelType.GameOver);

		}
	}
}
 