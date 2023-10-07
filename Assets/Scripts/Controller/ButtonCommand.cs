using strange.extensions.command.impl;
using UnityEngine;

namespace Game
{
	/// <summary> °´Å¥¹¦ÄÜ </summary>
	public class StartButtonCommand : EventCommand
	{
		public override void Execute()
		{
			Debug.Log("Run");
		}
	}

	public class QuitButtonCommand : EventCommand
	{
		public override void Execute()
		{
			Application.Quit();
		}
	}
}
