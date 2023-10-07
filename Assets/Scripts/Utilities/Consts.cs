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
		START_GAME = -1,
		TEST = 0,
		COMPLETE_DEAL = 1,
	}

	/// <summary> �����¼����� </summary>
	public enum CommandEvent
	{
		QuitGame = -63,
		StartGame = -1,
		Test = 0,
		RequestDeal = 1,
		DealCard = 2,
	}

	/// <summary> UI �������� </summary>
	public enum PanelType
	{
		Start,
		Background,
		Character,
		Interaction,
	}

	/// <summary> ��ɫ���� </summary>
	public enum CharacterType
	{
		Library = 0,	// �ƿ�
		PlayerC = 1,	// ���ӽ�
		PlayerL = 2,	// ���
		PlayerR = 3,	// �ұ�
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
