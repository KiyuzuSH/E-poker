using strange.extensions.command.impl;
using UnityEngine;

namespace Game
{
	/// <summary> 开始按钮 </summary>
	public class StartButtonCommand : EventCommand
	{
		public override void Execute()
		{
			Debug.Log("Run");
			Utilities.CreateUIPanel(PanelType.Background);
			Utilities.CreateUIPanel(PanelType.Character);
			Utilities.CreateUIPanel(PanelType.Interaction);
		}
	}

	/// <summary> 退出按钮 </summary>
	public class QuitButtonCommand : EventCommand
	{
		public override void Execute()
		{
			Application.Quit();
		}
	}
}
