using UnityEngine;
using System.IO;
using System.Text;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Game
{
	/// <summary> ʵ����Ŀ </summary>
	public static class Utilities
	{
		private static Transform uiRoot;

		/// <summary> UI �ĸ��ڵ�"RootCanvas" </summary>
		public static Transform UIRoot
		{
			get
			{
				if(uiRoot == null)
					uiRoot = GameObject.Find("Canvas").transform;
				return uiRoot;
			}
		}

		/// <summary> ���� UI ��� </summary>
		/// <param name="panelType"> UI ������� </param>
		/// <returns> ���� UI ʵ�� </returns>
		public static GameObject CreateUIPanel(PanelType panelType)
		{
			GameObject prefab=Resources.Load<GameObject>("Prefabs/"+panelType.ToString()+"Panel");
			if(null == prefab)
			{
				Debug.LogWarning("��Ϊ " + panelType.ToString() + " �� UI ��岻����");
				return null;
			}
			else
			{
				GameObject panel = Object.Instantiate<GameObject>(prefab);
				panel.name = panelType.ToString();	// delete (Clone)
				panel.transform.SetParent(UIRoot, false);
				return panel;
			}
		}

		/// <summary> �� UTF-8 �������� </summary>
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

		/// <summary> ��ȡ���� </summary>
		/// <returns> ���� </returns>
		public static Data LoadData()
		{
			Data data=new Data();
			Stream stream = new FileStream(Consts.DataPath,FileMode.Open,FileAccess.Read);
			// ���Ա�� = true
			StreamReader sr = new StreamReader(stream, true);
			XmlSerializer xmlSerializer = new XmlSerializer(data.GetType());
			data = xmlSerializer.Deserialize(sr) as Data;
			stream.Close();
			sr.Close();
			return data;
		}

		/// <summary> �������� </summary>
		/// <param name="cards"> ѡ����� </param>
		/// <param name="asc"> �Ƿ����� </param>
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
	}
}
