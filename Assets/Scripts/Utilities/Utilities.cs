using UnityEngine;
using System.IO;
using System.Text;
using System.Xml.Serialization;

namespace Game
{
	public static class Utilities
	{
		private static Transform uiRoot;

		/// <summary>
		/// UI 的根节点"RootCanvas"
		/// </summary>
		public static Transform UIRoot
		{
			get
			{
				if(uiRoot == null)
					uiRoot = GameObject.Find("RootCanvas").transform;
				return uiRoot;
			}
		}

		/// <summary>
		/// 创建 UI 面板
		/// </summary>
		/// <param name="panelType">UI 面板类型</param>
		/// <returns>返回 UI 实例</returns>
		public static GameObject CreateUIPanel(PanelType panelType)
		{
			GameObject prefab=Resources.Load<GameObject>(panelType.ToString());
			if(null == prefab)
			{
				Debug.LogWarning("名为" + panelType.ToString() + "的UI面板不存在");
				return null;
			}
			else
			{
				GameObject panel = Object.Instantiate<GameObject>(prefab);
				panel.name = panelType.ToString();  // delete (Clone)
				panel.transform.SetParent(uiRoot, false);
				return panel;
			}
		}

		/// <summary>
		/// 用 UTF-8 保存数据
		/// </summary>
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

		/// <summary>
		/// 读取数据
		/// </summary>
		/// <returns></returns>
		public static Data LoadData()
		{
			Data data=new Data();
			Stream stream = new FileStream(Consts.DataPath,FileMode.Open,FileAccess.Read);
			StreamReader sr = new StreamReader(stream, true);
			XmlSerializer xmlSerializer = new XmlSerializer(data.GetType());
			data = xmlSerializer.Deserialize(sr) as Data;
			stream.Close();
			sr.Close();
			return data;
		}
	}
}