using strange.extensions.command.impl;
using System.IO;
using UnityEditor;
using UnityEngine;

namespace Game
{
	public class StartCommand : Command
	{
		[Inject]
		public CardModel CardModel { get; set; }

		[Inject]
		public RoundModel RoundModel { get; set; }
		public override void Execute()
		{
			Utilities.CreateUIPanel(PanelType.StartPanel);
			// 初始化
			CardModel.InitCardLibrary();
			RoundModel.InitRound();
			// 读取数据
			GetData();

		}

		private void GetData()
		{
			string fileName = Consts.DataPath;
			FileInfo fileInfo = new FileInfo(fileName);
			if(fileInfo.Exists)
			{
				Data oldData = Utilities.LoadData();
			}
		}
	}
}
