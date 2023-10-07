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

		/// <summary> 设置个人资料 </summary>
		/// <param name="imgProfile"> 头像 </param>
		/// <param name="txtName"> 昵称 </param>
		public void SetProfile(Image imgProfile, TextMesh txtName)
		{
			//TODO: 设置
			
		}

		/// <summary> 设置剩余手牌 </summary>
		/// <param name="num"> 剩余数量 </param>
		public void SetRemain(int num)
		{
			textRemain.text = "剩：" + num.ToString();
		}
	}

}