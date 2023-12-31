using UnityEngine;
using System.IO;
using System.Text;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Game
{
	/// <summary> 实用项目 </summary>
	public static class Utilities
	{
		private static Transform uiRoot;

		/// <summary> UI 的根节点"RootCanvas" </summary>
		public static Transform UIRoot
		{
			get
			{
				if(uiRoot == null)
					uiRoot = GameObject.Find("Canvas").transform;
				return uiRoot;
			}
		}

		/// <summary> 创建 UI 面板 </summary>
		/// <param name="panelType"> UI 面板类型 </param>
		/// <returns> 返回 UI 实例 </returns>
		public static GameObject CreateUIPanel(PanelType panelType)
		{
			GameObject prefab=Resources.Load<GameObject>("Prefabs/"+panelType.ToString()+"Panel");
			if(null == prefab)
			{
				Debug.LogWarning("名为 " + panelType.ToString() + " 的 UI 面板不存在");
				return null;
			}
			else
			{
				GameObject panel = Object.Instantiate<GameObject>(prefab);
				panel.name = panelType.ToString();  // delete (Clone)
				panel.transform.SetParent(UIRoot, false);
				return panel;
			}
		}

		/// <summary> 用 UTF-8 保存数据 </summary>
		public static void SaveData(Data data)
		{
			string fileName=Consts.DataPath;

			Stream stream = new FileStream(fileName,FileMode.OpenOrCreate,FileAccess.Write);

			StreamWriter sw = new StreamWriter(stream,Encoding.UTF8);
			XmlSerializer xmlSerializer = new XmlSerializer(data.GetType());
			xmlSerializer.Serialize(sw, data);
			sw.Close();
			stream.Close();
		}

		/// <summary> 读取数据 </summary>
		/// <returns> 数据 </returns>
		public static Data LoadData()
		{
			Data data=new Data();
			Stream stream = new FileStream(Consts.DataPath,FileMode.Open,FileAccess.Read);
			// 忽略标记 = true
			StreamReader sr = new StreamReader(stream, true);
			XmlSerializer xmlSerializer = new XmlSerializer(data.GetType());
			data = xmlSerializer.Deserialize(sr) as Data;
			stream.Close();
			sr.Close();
			return data;
		}

		/// <summary> 卡牌排序 </summary>
		/// <param name="cards"> 选择的牌 </param>
		/// <param name="asc"> 是否升序 </param>
		public static void Sort(List<Card> cards, bool asc)
		{
			cards.Sort(
				(Card a, Card b) =>
				{
					if(asc)
						return a.CardWeight.CompareTo(b.CardWeight);
					else
						return -a.CardWeight.CompareTo(b.CardWeight);
				}
				);
		}

		public static int GetWeight(List<Card> cards, CardType cardType)
		{
			int totalWeight= 0;
			if(cardType == CardType.ThreeOne || cardType == CardType.ThreeTwo)
			{
				for(int i = 0; i < cards.Count; i++)
				{
					if(cards [i].CardWeight == cards [i + 1].CardWeight && cards [i + 1].CardWeight == cards [i + 2].CardWeight)
					{
						totalWeight += (int)cards [i].CardWeight;
						totalWeight *= 3;
						break;
					}
				}
			}
			else
			{
				for(int i = 0; i < cards.Count; i++)
				{
					totalWeight += (int)cards [i].CardWeight;
				}
			}
			return totalWeight;
		}
	}
}
