using System;

namespace Game
{
	/// <summary> ���ƻغ��� </summary>
	public class RoundModel
	{
		/// <summary> ��ҳ����¼� </summary>
		public static event Action<bool> PlayerHandler;

		/// <summary> ���˳����¼� </summary>
		public static event Action<ComputerSmartArgs> OthersHandler;

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
		private void BeginWith(CharacterType cType)
		{
			if(cType == CharacterType.PlayerC)
			{
				// ��ҳ���
				if(PlayerHandler != null)
					PlayerHandler(biggestCharacter != CharacterType.PlayerC);
			}
			else
			{
				// ���˳���
				if(OthersHandler != null)
				{
					ComputerSmartArgs e = new ComputerSmartArgs()
					{
						Biggest = this.Biggest,
						CardType = this.CardType,
						CharacterType = this.Current,
						Length = this.Length,
						Weight = this.Weight
					};
					OthersHandler(e);
				}
			}
		}
	}
}
