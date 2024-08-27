using strange.extensions.command.impl;

namespace Game.Controller
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
