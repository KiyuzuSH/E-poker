using System;
using System.Transactions;
using UnityEngine.UI;

namespace Game
{
	/// <summary> 出牌回合类 </summary>
	public class RoundModel
	{
		/// <summary> 玩家出牌事件 </summary>
		public static Action PlayerHandler;

		/// <summary> 他人出牌事件 </summary>
		public static Action OthersHandler;
		
		private CharacterType biggestCharacter;
		private CharacterType currentCharacter;

		private CardType currentType;

		private int currentWeight;
		private int currentLength;

		/// <summary> 出牌的长度 </summary>
		public int Length
		{
			get { return currentLength; }
			set { currentLength = value; }
		}

		/// <summary> 出牌的权值 </summary>
		public int Weight
		{
			get { return currentWeight; }
			set { currentWeight = value; }
		}

		/// <summary> 出牌类型 </summary>
		public CardType CardType
		{
			get { return currentType; }
			set { currentType = value; }
		}

		/// <summary> 最大的出牌人 </summary>
		public CharacterType Biggest
		{
			get { return biggestCharacter; }
			set { biggestCharacter = value; }
		}

		/// <summary> 当前出牌者 </summary>
		public CharacterType Current
		{
			get { return currentCharacter; }
			set { currentCharacter = value; }
		}

		/// <summary> 初始化出牌回合 </summary>
		public void InitRound()
		{
			this.currentCharacter = CharacterType.Desk;
			this.biggestCharacter = CharacterType.Desk;
			this.currentType = CardType.None;
			this.currentWeight = 0;
			this.currentLength = 0;
		}

		/// <summary> 开始游戏 </summary>
		/// <param name="cType"> 玩家类型 </param>
		public void Start(CharacterType cType)
		{
			this.currentCharacter = cType;
			this.biggestCharacter = cType;
			BeginWith(cType);
		}

		/// <summary> 转换出牌 </summary>
		public void Turn()
		{
			currentCharacter++;
			if(currentCharacter == CharacterType.Library || currentCharacter == CharacterType.Desk)
				currentCharacter=CharacterType.PlayerC;

			BeginWith(currentCharacter);
		}

		/// <summary> 开始出牌 </summary>
		/// <param name="cType"> 谁 </param>
		private static void BeginWith(CharacterType cType)
		{
			if(cType == CharacterType.PlayerC)
			{
				//玩家出牌
				if(PlayerHandler != null)
					PlayerHandler();
			}
			else
			{
				//等人出牌
				if(OthersHandler != null)
					OthersHandler();
			}
		}
	}
}
