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
			// ��ʼ��
			CardModel.InitCardLibrary();
			RoundModel.InitRound();
			// ��ȡ����
			GetData();

		}

		/// <summary> ��ȡ����(�浵)���� </summary>
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
