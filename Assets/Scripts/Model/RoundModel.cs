using System;
using System.Transactions;
using UnityEngine.UI;

namespace Game
{
	/// <summary> ���ƻغ��� </summary>
	public class RoundModel
	{
		/// <summary> ��ҳ����¼� </summary>
		public static Action PlayerHandler;

		/// <summary> ���˳����¼� </summary>
		public static Action OthersHandler;
		
		private CharacterType biggestCharacter;
		private CharacterType currentCharacter;

		private CardType currentType;

		private int currentWeight;
		private int currentLength;

		/// <summary> ���Ƶĳ��� </summary>
		public int Length
		{
			get { return currentLength; }
			set { currentLength = value; }
		}

		/// <summary> ���Ƶ�Ȩֵ </summary>
		public int Weight
		{
			get { return currentWeight; }
			set { currentWeight = value; }
		}

		/// <summary> �������� </summary>
		public CardType CardType
		{
			get { return currentType; }
			set { currentType = value; }
		}

		/// <summary> ���ĳ����� </summary>
		public CharacterType Biggest
		{
			get { return biggestCharacter; }
			set { biggestCharacter = value; }
		}

		/// <summary> ��ǰ������ </summary>
		public CharacterType Current
		{
			get { return currentCharacter; }
			set { currentCharacter = value; }
		}

		/// <summary> ��ʼ�����ƻغ� </summary>
		public void InitRound()
		{
			this.currentCharacter = CharacterType.Desk;
			this.biggestCharacter = CharacterType.Desk;
			this.currentType = CardType.None;
			this.currentWeight = 0;
			this.currentLength = 0;
		}

		/// <summary> ��ʼ��Ϸ </summary>
		/// <param name="cType"> ������� </param>
		public void Start(CharacterType cType)
		{
			this.currentCharacter = cType;
			this.biggestCharacter = cType;
			BeginWith(cType);
		}

		/// <summary> ת������ </summary>
		public void Turn()
		{
			currentCharacter++;
			if(currentCharacter == CharacterType.Library || currentCharacter == CharacterType.Desk)
				currentCharacter=CharacterType.PlayerC;

			BeginWith(currentCharacter);
		}

		/// <summary> ��ʼ���� </summary>
		/// <param name="cType"> ˭ </param>
		private static void BeginWith(CharacterType cType)
		{
			if(cType == CharacterType.PlayerC)
			{
				//��ҳ���
				if(PlayerHandler != null)
					PlayerHandler();
			}
			else
			{
				//���˳���
				if(OthersHandler != null)
					OthersHandler();
			}
		}
	}
}
