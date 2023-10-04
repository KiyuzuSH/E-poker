using UnityEngine;

namespace Game
{
	public class Consts
	{
		/// <summary>
		/// 游戏数据的路径
		/// </summary>
		public static readonly string DataPath = Application.persistentDataPath+@"\data.xml";
	}

	/// <summary>
	/// UI 面板的类型
	/// </summary>
	public enum PanelType
	{

	}

	/// <summary>
	/// 角色类型
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
	/// 花色
	/// </summary>
	public enum Colours
	{
		None,
		Club,//梅花
		Heart,//红桃
		Spade,//黑桃
		Diamond//方片
	}

	/// <summary>
	/// 卡牌权重
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
	/// 出牌类型
	/// </summary>
	public enum CardType
	{
		None,
		Single,//单张
		Double,//对
		Straight,//顺子
		DoubleStraight,//姐妹花
		TripleStraight,//三张的顺子
		Three,//三张
		ThreeOne,//三带一
		ThreeTwo,//三带二
		Plane,//飞机
		Bomb,//炸弹
		JokerBomb,
	}
}