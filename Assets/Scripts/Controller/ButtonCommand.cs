using strange.extensions.command.impl;
using UnityEngine;

namespace Game
{
	/// <summary> ��ť���� </summary>
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
