using strange.extensions.command.impl;

namespace Game
{
	public class PassCardCommand : Command
	{
		[Inject]public RoundModel RoundModel { get; set; }

		public override void Execute()
		{
			RoundModel.Turn();
		}
	}
}
