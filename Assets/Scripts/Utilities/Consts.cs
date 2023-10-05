using UnityEngine;

namespace Game
{
	public class Consts
	{
		/// <summary>
		/// ��Ϸ���ݵ�·��
		/// </summary>
		public static readonly string DataPath = Application.persistentDataPath+@"\data.xml";
	}

	/// <summary>
	/// UI ��������
	/// </summary>
	public enum PanelType
	{

	}

	/// <summary>
	/// ��ɫ����
	/// </summary>
	public enum CharacterType
	{
		Library = 0,
		Player1 = 1,
		Player2 = 2,
		Player3 = 3,
		Desk
	}

	/// <summary>
	/// ��ɫ
	/// </summary>
	public enum Colours
	{
		None,
		Club,//÷��
		Heart,//����
		Spade,//����
		Diamond//��Ƭ
	}

	/// <summary>
	/// ����Ȩ��
	/// </summary>
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

	/// <summary>
	/// ��������
	/// </summary>
	public enum CardType
	{
		None,
		Single,//����
		Double,//��
		Straight,//˳��
		DoubleStraight,//���û�
		TripleStraight,//���ŵ�˳��
		Three,//����
		ThreeOne,//����һ
		ThreeTwo,//������
		Plane,//�ɻ�
		Bomb,//ը��
		JokerBomb,
	}
}