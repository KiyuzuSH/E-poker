using UnityEngine;

namespace Game
{
	/// <summary> 游戏所需的常量 </summary>
	public class Consts
	{
		/// <summary> 游戏数据的路径 </summary>
		public static readonly string DataPath = Application.persistentDataPath+@"\data.xml";
	}

	/// <summary> View 的事件类型 </summary>
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

	/// <summary> 命令事件类型 </summary>
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

	/// <summary> UI 面板的类型 </summary>
	public enum PanelType
	{
		Start,
		Background,
		Character,
		Interaction,
		GameOver,
	}

	/// <summary> 角色类型 </summary>
	public enum CharacterType
	{
		Library = 0,	// 牌库
		PlayerC = 1,	// 主视角
		PlayerR = 2,	// 左边
		PlayerL = 3,	// 右边
		Desk			// 牌桌
	}

	/// <summary> 花色 </summary>
	public enum Colours
	{
		None,
		Club,	//梅花
		Heart,	//红桃
		Spade,	//黑桃
		Square	//方片
	}

	/// <summary> 卡牌权重 </summary>
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

	/// <summary> 出牌类型 </summary>
	public enum CardType
	{
		None,
		Single,			//单张
		Double,         //对子
		Straight,		//顺子
		DoubleStraight,	//姐妹花
		TripleStraight,	//飞机
		Three,			//三张
		ThreeOne,		//三带一
		ThreeTwo,		//三带二
		Bomb,			//炸弹
		JokerBomb,
	}
}
