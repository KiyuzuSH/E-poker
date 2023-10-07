using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Game
{
	public class CharacterUI : MonoBehaviour
	{
		public Image imageProfile;
		public TMP_Text textName;
		public TMP_Text textRemain;
		public Transform CreatePoint;

		/// <summary> ���ø������� </summary>
		/// <param name="imgProfile"> ͷ�� </param>
		/// <param name="txtName"> �ǳ� </param>
		public void SetProfile(Image imgProfile, TextMesh txtName)
		{
			//TODO: ����
			
		}

		/// <summary> ����ʣ������ </summary>
		/// <param name="num"> ʣ������ </param>
		public void SetRemain(int num)
		{
			textRemain.text = "ʣ��" + num.ToString();
		}
	}

}