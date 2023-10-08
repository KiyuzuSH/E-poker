using UnityEngine;

namespace Game
{
	/// <summary> ��Ϸ����ĳ��� </summary>
	public class Consts
	{
		/// <summary> ��Ϸ���ݵ�·�� </summary>
		public static readonly string DataPath = Application.persistentDataPath+@"\data.xml";
	}

	/// <summary> View ���¼����� </summary>
	public enum ViewEvent
	{
		QUIT_GAME = -63,
		GAME_OVER = -62,
		RESTART_GAME = -2,
		START_GAME = -1,
		//TEST = 0,
		COMPLETE_DEAL = 2,
		REQUEST_PLAY = 3,
		SUCCESS_PLAY = 4,
		COMPLETE_PLAY = 5,
	}

	/// <summary> �����¼����� </summary>
	public enum CommandEvent
	{
		QuitGame = -63,
		GameOver = -62,
		RestartGame = -2,
		StartGame = -1,
		//Test = 0,
		RequestDeal = 1,
		DealCard = 2,
		PlayCard = 3,
		PassCard = 6,
	}

	/// <summary> UI �������� </summary>
	public enum PanelType
	{
		Start,
		Background,
		Character,
		Interaction,
		GameOver,
	}

	/// <summary> ��ɫ���� </summary>
	public enum CharacterType
	{
		Library = 0,	// �ƿ�
		PlayerC = 1,	// ���ӽ�
		PlayerR = 2,	// ���
		PlayerL = 3,	// �ұ�
		Desk			// ����
	}

	/// <summary> ��ɫ </summary>
	public enum Colours
	{
		None,
		Club,	//÷��
		Heart,	//����
		Spade,	//����
		Square	//��Ƭ
	}

	/// <summary> ����Ȩ�� </summary>
	public enum Weight
	{
		Three,
		Four,
		Five,
		Six,
		Seven,
		Eight,
		Nine,
		Ten,
		Jack,
		Queen,
		King,
		Ace,
		Two,
		BlackJoker,
		RedJoker
	}

	/// <summary> �������� </summary>
	public enum CardType
	{
		None,
		Single,			//����
		Double,         //����
		Straight,		//˳��
		DoubleStraight,	//���û�
		TripleStraight,	//�ɻ�
		Three,			//����
		ThreeOne,		//����һ
		ThreeTwo,		//������
		Bomb,			//ը��
		JokerBomb,
	}
}
