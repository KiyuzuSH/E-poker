﻿using UnityEngine;
using System.Collections.Generic;

namespace ObjPool
{
	/// <summary> 单个池子 </summary>
	[System.Serializable]
	public class ObjectPool
	{
		/// <summary> 池子的名字 </summary>
		public string Name;
		/// <summary> 池子的对象 </summary>
		[SerializeField]
		private GameObject Prefab;
		/// <summary> 池子的最大数量 </summary>
		[SerializeField]
		private int MaxCount;

		[System.NonSerialized]
		/// <summary> 池子内所有对象的集合 </summary>
		private List<GameObject> PrefabList = new List<GameObject>();

		/// <summary> 池内是否包含某物体 </summary>
		/// <param name="go"> Gameobject(Prefab) </param>
		/// <returns> bool </returns>
		public bool Contains(GameObject go)
		{
			return PrefabList.Contains(go);
		}

		/// <summary> 从池子内获取游戏对象 </summary>
		/// <returns> 对象本体 </returns>
		public GameObject GetObject()
		{
			GameObject go = null;
			for(int i = 0; i < PrefabList.Count; i++)
			{
				if(!PrefabList [i].activeSelf)
				{
					go = PrefabList [i];
					go.SetActive(true);
					break;
				}
			}

			if(go == null)
			{
				if(PrefabList.Count >= MaxCount)
				{
					Object.Destroy(PrefabList [0]);
					PrefabList.RemoveAt(0);
				}
				go = Object.Instantiate(Prefab);
				PrefabList.Add(go);
			}
			go.SendMessage("BeforeGetObject", SendMessageOptions.DontRequireReceiver);
			return go;
		}

		/// <summary> 隐藏指定的游戏对象 </summary>
		/// <param name="go"> 对象 </param>
		public void HideObject(GameObject go)
		{
			if(PrefabList.Contains(go))
			{
				go.SendMessage("BeforeHideObject", SendMessageOptions.DontRequireReceiver);
				go.SetActive(false);
			}
		}

		/// <summary> 隐藏该池子的全部游戏对象 </summary>
		public void HideAllObject()
		{
			for(int i = 0; i < PrefabList.Count; i++)
			{
				if(PrefabList [i].activeSelf)
					HideObject(PrefabList [i]);
			}
		}

		/// <summary> 初始化池子 </summary>
		public void InitPool()
		{
			PrefabList = new List<GameObject>();
		}
	}
}
