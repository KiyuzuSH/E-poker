using strange.extensions.command.impl;
using System.IO;

namespace Game
{
	public class StartCommand : Command
	{
		[Inject] public CardModel CardModel { get; set; }

		[Inject] public RoundModel RoundModel { get; set; }

		public override void Execute()
		{
			Utilities.CreateUIPanel(PanelType.Start);
			// 初始化
			CardModel.InitCardLibrary();
			RoundModel.InitRound();
			// 读取数据
			GetData();

		}

		/// <summary> 获取数据(存档)方法 </summary>
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
